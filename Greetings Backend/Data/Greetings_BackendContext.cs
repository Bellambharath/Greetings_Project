using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Greetings_Backend.Model;

namespace Greetings_Backend.Data
{
    public class Greetings_BackendContext : DbContext
    {
        public Greetings_BackendContext (DbContextOptions<Greetings_BackendContext> options)
            : base(options)
        {
        }

        public DbSet<Greetings_Backend.Model.Greetings> Greetings { get; set; } = default!;
    }
}
