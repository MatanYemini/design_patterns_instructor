using System;
using System.Net;
using System.Threading.Tasks;

namespace AsyncFactory
{
    class Program
    {
        class Foo
        {
            private Foo() { } // Make it private so the constructor will be only the async one

            private async Task<Foo> InitAsync()
            {
                await Task.Delay(1000);
                return this;
            }

            public static Task<Foo> CreateAsync()
            {
                var res = new Foo();
                return res.InitAsync();
            }
        }
        static async Task Main(string[] args)
        {
            Foo x = await Foo.CreateAsync(); // Pay attention it is like our factory !! (ze lma asiti et ze cosemek)
        }
    }
}
