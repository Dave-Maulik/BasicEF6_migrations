using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BasicEF6_migrations.DataBaseClasses;

namespace DataModels
{
    public class SoldierContext : DbContext
    {
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<SoliderEquipment> Equipments { get; set; }

    }
}
