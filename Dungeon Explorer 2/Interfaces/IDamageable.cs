using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// This is the IDamageable interface,
    /// it is used to damage a creature 
    /// This is an interface to ensure it can be used on any class in the exact way the class needs it
    /// </summary>
    interface IDamageable
    {
        void Damageable(int DamageAmount);
    }
}
