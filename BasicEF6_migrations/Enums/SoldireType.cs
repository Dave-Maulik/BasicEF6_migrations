using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations
{
    public enum SoldireType
    {
        Army=1,
        Navy,
        [Description("Air Force")]
        AirForce
    }
}
