using BasicEF6_migrations;
using BasicEF6_migrations.Interface;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataModels
{
    public class SoldierContext : DbContext
    {
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<SoliderEquipment> Equipments { get; set; }


        //After Added DateCreated, DateModified and isDirty
        //Just tell EF to ignore the isDirty property.
        //For that using Fluat API.


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(x => x.Ignore("isDirty"));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var Attribute in this.ChangeTracker.Entries()
                .Where(e=> e.Entity is IModificationHistory
                && (e.State == EntityState.Added) || (e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory))
            {
                Attribute.DateModified = DateTime.Now;
                if (Attribute.DateCreated == DateTime.MinValue)
                {
                    Attribute.DateCreated = DateTime.Now;
                }
            }

            int result = base.SaveChanges();

            foreach (var Attribute in this.ChangeTracker.Entries()
            .Where(e=>e.Entity is IModificationHistory).Select(e=>e.Entity as IModificationHistory))
            {
                Attribute.isDirty = false;
            }
            return result;
        }
    }
}
