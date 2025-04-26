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
    /// </summary>
    interface IDamageable
    {
        void Damageable(int DamageAmount);
    }
}
