using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPatients.Models;

namespace MvcPatients.Data
{
    public class MvcPatientsContext : DbContext
    {
        public MvcPatientsContext (DbContextOptions<MvcPatientsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPatients.Models.Patient> Patient { get; set; } = default!;
    }
}
