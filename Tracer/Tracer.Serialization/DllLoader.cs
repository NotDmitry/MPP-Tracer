using System.Reflection;
using Tracer.Core;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization;

public class DllLoader
{

    private static IEnumerable<Type> GetAllTypesThatImplementInterface<T>(Assembly assembly)
    {
        return assembly.GetTypes().Where(type => typeof(T).IsAssignableFrom(type) 
        && !type.IsInterface);
    }

    public static IEnumerable<T> LoadPlugins<T>(string path)
    {

        var pluginsList = new List<T>();

        DirectoryInfo searchDirectory = new(path);
        if (!searchDirectory.Exists)
            return pluginsList;

        FileInfo[] files = searchDirectory.GetFiles("*.dll");
        foreach (FileInfo file in files)
        {

            var assembly = Assembly.LoadFrom(file.FullName);
            foreach (var type in GetAllTypesThatImplementInterface<T>(assembly))
            {
                var pluginInstance = Activator.CreateInstance(type);
                if (pluginInstance is not null)
                    pluginsList.Add((T)pluginInstance);
            }

        }

        return pluginsList;

    }

    public static void PrintSerializeResult(IEnumerable<ITraceResultSerializer> pluginList, 
        TraceResult traceResult)
    {
        foreach (var plugin in pluginList)
        {
            using (FileStream fstream = new FileStream($"Output{plugin.Format}", FileMode.Create))
            {
                plugin.Serialize(traceResult, fstream);
                
            }
        }
    }
}
