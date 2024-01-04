using Core.Commons;
using Infrastructure.Entites;
using System.Reflection;

namespace Authenticator.API.Extensions.Configures
{
    public static class DIAssemblies
    {
        internal static Assembly[] AssembliesToScan = new Assembly[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(CRMContext)),
            //Assembly.GetAssembly(typeof(ISerializeService)),
            //Assembly.GetAssembly(typeof(CreateEmployeeCommand)),
            Assembly.GetAssembly(typeof(Program)),
            Assembly.GetAssembly(typeof(ApiResponse))
        };
    }
}
