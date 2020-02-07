using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEF6_migrations.Interface
{
    public interface IModificationHistory
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }

        bool isDirty { get; set; }
    }
}
