using BasicEF6_migrations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations
{
    public class Clan : IModificationHistory
    {
        public Clan()
        {
            Soldiers = new List<Soldier>();
        }
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Soldier> Soldiers { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool isDirty { get; set; }
    }
}
