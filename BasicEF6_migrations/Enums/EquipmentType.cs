using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations
{
   public enum EquipmentType
    {
        [Description("Machine Gun")]
        MachineGun= 1,
        SMG,
        Snipers
    }
}
