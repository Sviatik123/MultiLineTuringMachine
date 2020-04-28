using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLineTuringMachine
{
    class SubCommand
    {
        public char OldSymb { get; set; }
        public char NewSymb { get; set; }
        public char Direction { get; set; }
        public SubCommand(char oldSymb, char newSymb, char direction)
        {
            OldSymb = oldSymb;
            NewSymb = newSymb;
            Direction = direction;
        }
        public SubCommand()
        {

        }
    }
}
