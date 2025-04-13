using ControlBelleza.ControlBelleza.Persitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBelleza.infrastructure.Repositories
{
    class ClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            this._context = context;
        }
    }
}
