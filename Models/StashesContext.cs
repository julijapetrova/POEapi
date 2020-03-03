using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POEapi.Models;

namespace POEapi
{
    public class StashesContext : DbContext
    {
        public StashesContext(DbContextOptions<StashesContext> options)
            : base(options)
        {
        }

        public DbSet<Stash> Stashes { get; set; }
    }
}