using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.ControlBelleza.Persitence;
using ControlBelleza.Domain.Entities;

namespace ControlBelleza.ControlBelleza.Persitence
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Estilista> Estilista { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Citas> Citas { get; set; }
    }
}
