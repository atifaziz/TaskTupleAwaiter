using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RazorLight;

namespace Generator
{
    static class Program
    {
        const int DefaultMaxArity = 10;

        static async Task<int> Main(string[] args)
        {
            try
            {
                var maxArity
                    = args.FirstOrDefault() is string arg
                      ? int.TryParse(arg, NumberStyles.None, CultureInfo.InvariantCulture, out var n) && n > 1 ? n
                      : throw new Exception($"Invalid arity ({arg}). It must be a positive integer equal or greater than 2.")
                    : DefaultMaxArity;

                var engine = new RazorLightEngineBuilder()
                                .UseEmbeddedResourcesProject(typeof(Program))
                                .UseMemoryCachingProvider()
                                .Build();

                var result = await engine.CompileRenderAsync("TaskTupleExtensions.cshtml", maxArity);
                await Console.Out.WriteLineAsync(result);

                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.GetBaseException().Message);
                return 0xbad;
            }
        }
    }
}
