using BasicEF6_migrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class ForMVCRepo
    {
        public List<Soldier> GetSoldiersWithClan()
        {
            using (var context = new SoldierContext())
            {
                return context.Soldiers.AsNoTracking().Include(e=>e.Clan).ToList();
            }
        }

        public Soldier GetSoldierWithEquipment(int id)
        {
            using (var context = new SoldierContext())
            {
                return context.Soldiers.AsNoTracking().Include(s => s.EquipmentOwned).FirstOrDefault(s => s.Id == id);
            }
        }

        public Soldier GetSoldierWithClanAndEquipment(int id)
        {
            using (var context = new SoldierContext())
            {
                return context.Soldiers.AsNoTracking().Include(s => s.Clan).Include(s => s.EquipmentOwned).FirstOrDefault(s => s.Id == id);

            }
        }

        public IEnumerable GetListOfClan()
        {
            using (var context = new SoldierContext())
            {
                return context.Clans.AsNoTracking().OrderBy(d => d.ClanName).Select(c => new { c.Id, c.ClanName }).ToList();
                    
            }
        }

        public Soldier GetSoldierById(int id)
        {
            using (var context = new SoldierContext())
            {
                //You cannot Add AsNoTracking to Find Method....
                //return context.Soldiers.Find(id);
                //Performance Enhancement Below Line
                return context.Soldiers.AsNoTracking().FirstOrDefault(s=>s.Id==id);
            }
        }

        public void UpdateSoldier(Soldier soldier)
        {
            using (var context = new SoldierContext())
            {
                context.Entry(soldier).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SaveNewSoldier(Soldier nwSoldier)
        {
            using (var context = new SoldierContext())
            {
                context.Soldiers.Add(nwSoldier);
                context.SaveChanges();
            }
        }

        public  void DeleteSoldier(int id)
        {
            using (var context = new SoldierContext())
            {
                context.Entry(context).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
