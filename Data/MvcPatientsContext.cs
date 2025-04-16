using Azure.Core;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MvcPatients.Models;
using Npgsql;

namespace MvcPatients.Data
{
    public class MvcPatientsContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MvcPatientsContext(DbContextOptions<MvcPatientsContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Patient> Patient { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("MvcPatientsContextAzure");

                var dataSource = new NpgsqlDataSourceBuilder(connectionString)
                    .UsePeriodicPasswordProvider(async (_, ct) =>
                    {
                        var credentials = new DefaultAzureCredential();
                        var token = await credentials.GetTokenAsync(
                            new TokenRequestContext(["https://ossrdbms-aad.database.windows.net/.default"]), ct);
                        return token.Token;
                    }, TimeSpan.FromHours(4), TimeSpan.FromSeconds(10))
                    .Build();

                optionsBuilder.UseNpgsql(dataSource);
            }
        }
    }
}