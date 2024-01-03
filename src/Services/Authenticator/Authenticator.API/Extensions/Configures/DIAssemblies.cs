using Infrastructure.Entites;
using System.Reflection;

namespace Authenticator.API.Extensions.Configures
{
    public static class DIAssemblies
    {
        internal static Assembly[] AssembliesToScan = new Assembly[0]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(CRMContext))
        }
    }
}
