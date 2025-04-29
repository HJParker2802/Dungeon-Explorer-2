using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2.Interfaces
{
    /// <summary>
    /// This is the ICollectable interface,
    /// it is used to be able to collect an Item
    /// This is an interface to ensure it can be used on any class in the exact way the class needs it
    /// </summary>
    interface ICollectable
    {
        void Collect(Items item);
    }
}
