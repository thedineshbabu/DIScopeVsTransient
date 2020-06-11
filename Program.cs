using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ScopeVsTransient
{
    public class ScopedClass{}
    public class TransientClass{}
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ScopedClass>();
            collection.AddTransient<TransientClass>();

            var builder = collection.BuildServiceProvider();

            Console.Clear();

            Parallel.For(1, 10, i=>{
                Console.WriteLine("ScopedId: " + builder.GetService<ScopedClass>().GetHashCode().ToString());
                Console.WriteLine("TransientId: " + builder.GetService<TransientClass>().GetHashCode().ToString());
            });
        }
    }
}
