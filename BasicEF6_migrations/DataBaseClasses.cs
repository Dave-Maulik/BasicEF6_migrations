using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations
{
    public class DataBaseClasses
    {
        public class Soldier
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
        }

        public class Clan
        {
            public Clan()
            {
                Soldiers = new List<Soldier>();
            }
            public int Id { get; set; }
            public string ClanName { get; set; }
            public List<Soldier> Soldiers { get; set; }
        }

        public class SoliderEquipment
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public EquipmentType Type { get; set; }
            [Required]
            public Soldier Solider { get; set; }
        }
    }
}
