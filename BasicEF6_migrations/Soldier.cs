using BasicEF6_migrations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations
{
    public class Soldier : IModificationHistory
    {
      
            public Soldier()
            {
                EquipmentOwned = new List<SoliderEquipment>();
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public bool ServerdInSpecial { get; set; }
            public Clan Clan { get; set; }
            public int ClanId { get; set; }
            public List<SoliderEquipment> EquipmentOwned { get; set; }

            public DateTime BirthDate { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
            public bool isDirty { get; set; }
    }
}
