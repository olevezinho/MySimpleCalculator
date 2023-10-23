namespace MyCalculatorWebApp
{
    using System.Runtime.CompilerServices;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using MyCalculatorWebApp.NDepend;
    //using NDepend;

    /// <summary>Class program</summary>
    public static class Program
    {
        private const string Path = @"/home/filipe/ndepend/Lib";

        // ************************** IMPORTANT ***********************************
        // All programs using NDepend.API.dll should have this type AssemblyResolver
        // parametrized with the relative path to the dir "$NDependInstallDir$\Lib".
        // Since  NDepend.PowerTool.exe  is in the dir "$NDependInstallDir$"
        // the relative path is @".\Lib"
        //private static readonly AssemblyResolver s_AssemblyResolver = new AssemblyResolver(Path);

        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            if(!Directory.Exists(Path))
                return;

            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>Creates the web host builder.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
