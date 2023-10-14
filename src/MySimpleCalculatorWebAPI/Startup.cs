namespace MyCalculatorWebApp
{
    using global::NDepend;
    using global::NDepend.Analysis;
    using global::NDepend.Path;
    using global::NDepend.Project;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MySimpleCalculator.Extensions;

    /// <summary>Class startup</summary>
    public class Startup
    {
        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration">The configuration.</param>
        private readonly IWebHostEnvironment hosting;
        private readonly string url = "http://localhost";

        /// <summary>
        /// Constructor for startup class
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="_hosting"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment _hosting)
        {
            Configuration = configuration;
            hosting = _hosting;
        }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>Configures the services.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true)
                .AddMvcOptions(options => options.EnableEndpointRouting = false);

            services.AddCalculatorService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Calculator Web App, " + hosting.EnvironmentName,
                    Version = "v1",
                    Description = "Web API example, created with .NET CORE 6",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Filipe Costa",
                        Url = new System.Uri(url)
                    }
                });
            });

            var ndependServicesProvider = new NDependServicesProvider();
 
            // Example of using the NDepend.API
            var projectManager = ndependServicesProvider.ProjectManager;
            IProject project = projectManager.LoadProject(
                @"C:\YourPathToYourNDependProjectFile\File.ndproj".ToAbsoluteFilePath());
    
            // Try to load the most recent analysis result
            var refs = project.GetAvailableAnalysisResultsRefs();
            if (!refs.Any()) { return; }
            IAnalysisResult result = refs[0].Load();
    
            // Obtain source files paths from the analysis result code base model 
            // For example this can be done this way:
            var sourceFiles = result.CodeBase.Application.CodeElements
                .Where(c => c.SourceFileDeclAvailable)
                .SelectMany(c => c.SourceDecls)
                .Select(c => c.SourceFile.FilePath)
                .Distinct()
                .ToList();
    
            // Print all source files paths
            foreach (IAbsoluteFilePath sourceFilePath in sourceFiles) 
            {
                Console.WriteLine(sourceFilePath.ToString());
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>Configures the specified application.</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator App"));
        }
    }
}
