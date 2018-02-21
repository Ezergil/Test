using System.Reflection;

namespace TestProject.WebFramework.References
{
    internal static class ReferencedAssemblies
    {
        public static Assembly Web => Assembly.Load("TestProject.Web");
        public static Assembly Services => Assembly.Load("TestProject.Services");

    }
}