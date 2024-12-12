using mef.Common;
using mef.Plugins;
using System.Composition.Hosting;
using System.Reflection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // Register MEF parts
        var configuration = new ContainerConfiguration()
            .WithAssemblies([Assembly.GetEntryAssembly(), Assembly.GetExecutingAssembly(), PluginsAssembly.Value]);
        var container = configuration.CreateContainer();
        services.AddSingleton(container);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
