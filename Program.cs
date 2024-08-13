using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPatients.Data;
using ConfigurationPlaceholders;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry;

var builder = WebApplication.CreateBuilder(args);

// Custom ActivitySource for the application
//var appActivitySource = new System.Diagnostics.ActivitySource("MvcPatient.App");

// Using ConfigurationPlaceholders
builder
     .AddConfigurationPlaceholders( new EnvironmentVariableResolver() ); 

builder.Services.AddDbContext<MvcPatientsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MvcPatientsContext") ?? throw new InvalidOperationException("Connection string 'MvcPatientsContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Initialize OTel builder
var otel = builder.Services.AddOpenTelemetry();

// Set OTel Resources
// Configure OpenTelemetry Resources with the application name
//otel.ConfigureResource(resource => resource
// .AddService(serviceName: builder.Environment.ApplicationName));

var otelResources = ResourceBuilder.CreateEmpty()
    .AddTelemetrySdk()
    .AddEnvironmentVariableDetector();

// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
otel.WithMetrics(metrics => metrics
    // Metrics provider from OpenTelemetry
    .AddAspNetCoreInstrumentation()
    .SetResourceBuilder(otelResources)
    // Metrics provides by ASP.NET Core in .NET 8
    .AddMeter("Microsoft.AspNetCore.Hosting")
    .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
    .AddOtlpExporter());

// Configure tracing
otel.WithTracing(tracing =>
{
   tracing.AddAspNetCoreInstrumentation();
   tracing.SetResourceBuilder(otelResources);
   tracing.AddOtlpExporter();
   // Just for troubleshooting purposes to see if spans are generated and printed out to logs.
   //tracing.AddConsoleExporter();
});

// Send Logs
otel.WithLogging(logging => logging
        .SetResourceBuilder(otelResources)
        .AddOtlpExporter());

//builder.Logging.AddOpenTelemetry(options =>
//{
//    options
//        .SetResourceBuilder(otelResources)
//        .AddOtlpExporter();
//        //.AddConsoleExporter();
//});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
