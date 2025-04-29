using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Explorer_2
{
    /// <summary>
    /// This is the IOutable interface,
    /// it is used to OutputText across all the program
    /// This is an interface to ensure it can be used on any class in the exact way the class needs it
    /// </summary>
    interface IOutable
    {
        void OutputText(string Message);

    }
}
