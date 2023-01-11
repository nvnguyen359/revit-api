using System.Reflection;

namespace ad.res
{
    public static class ResourceAssembly
    {
        /**
         <summary>
        Gets the current resource assembly.
        </summary>
         */
        public static Assembly GetAssembly => Assembly.GetExecutingAssembly();
        public static Assembly GetAssembly1() { return Assembly.GetCallingAssembly(); }
        /// <summary>
        /// Gets the namespace of the currently running resource assembly.
        /// </summary>
        /// <returns></returns>
        public static string GetNamespace => $"{typeof(ResourceAssembly).Namespace}.";
        public static string GetNamespace1()
        {
            return typeof(ResourceAssembly).Namespace + ".";
        }
    }
}
