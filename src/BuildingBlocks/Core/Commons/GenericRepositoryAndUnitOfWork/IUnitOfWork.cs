using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace Core.Commons
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task Dispose();
        //IRepository<TEntity, TContext> GetRepository<TEntity>() where TEntity : class;

        Task<List<T>> RawSqlQueryAsync<T>(TContext context, string querySql, SqlParameter[] parameters);

        Task<DataSet> GetDataSet(TContext context, string querySql, SqlParameter[] parameters, string[] tableNames);
    }

    public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        private readonly TContext _context = context;
        private bool disposed = false;

        public int SaveChanges()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        private async Task Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }
            }
            disposed = true;
        }

        public async Task Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public IRepository<TEntity, TContext> GetRepository<TEntity>() where TEntity : class
        //{
        //    return new Repository<TEntity, TContext>(_context);
        //}

        public async Task<List<T>> RawSqlQueryAsync<T>(TContext context, string querySql, SqlParameter[] parameters)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = querySql;
            command.CommandType = CommandType.Text;

            command.Parameters.AddRange(parameters);

            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            var lstResultEntities = new List<T>();

            var dataTable = new DataTable();
            dataTable.Load(result);

            if (dataTable.Rows.Count > 0)
            {
                var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                lstResultEntities = (List<T>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<T>));
            }

            context.Database.CloseConnection();

            return lstResultEntities;
        }

        public async Task<DataSet> GetDataSet(TContext context, string querySql, SqlParameter[] parameters, string[] tableNames)
        {
            try
            {
                DataSet ds = new();
                using (SqlDataAdapter sda = new(querySql, context.Database.GetConnectionString()))
                {
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddRange(parameters);

                    sda.Fill(ds);

                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        ds.Tables[i].TableName = tableNames[i];

                    }
                }

                await context.Database.CloseConnectionAsync();
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
