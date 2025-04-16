using Azure.Core;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using MvcPatients.Models;
using Npgsql;

namespace MvcPatients.Data
{
    public class MvcPatientsContext : DbContext
    {
        public MvcPatientsContext(DbContextOptions<MvcPatientsContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; } = default!;
    }
}