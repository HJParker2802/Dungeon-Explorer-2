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
    /// </summary>
    interface IUsable
    {
        void Use(Player Player1);
    }
}
