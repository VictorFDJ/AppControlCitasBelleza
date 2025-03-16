using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.Frontend.Models;

namespace ControlBelleza.Frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Estilista> Estilista { get; set; }
        //ControlBelleza.Frontend.Models.
    }
}
