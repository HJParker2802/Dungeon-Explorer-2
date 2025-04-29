using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2.Interfaces
{
    /// <summary>
    /// This is the IUsable interface,
    /// it is used to allow for Players to use Items from the Items class
    /// This is an interface to ensure it can be used on any class in the exact way the class needs it
    /// </summary>
    interface IUsable
    {
        void Use(Player Player1);
    }
}
