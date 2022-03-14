using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data
{
    public class TCG_CollectionGameContext : DbContext
    {
        public TCG_CollectionGameContext(DbContextOptions<TCG_CollectionGameContext> options)
            : base(options)
        {
        }
        public DbSet<TCG_CollectionGame.Models.User> User { get; set; }
        public DbSet<TCG_CollectionGame.Models.Pokecard> Pokecard { get; set; }
    }
}
