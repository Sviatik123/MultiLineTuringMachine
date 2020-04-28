using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLineTuringMachine
{
    class Command
    {
        public string OldState { get; set; }
        public string NewState { get; set; }
        public List<SubCommand> SubCommands { get; set; }
        public Command()
        {
            SubCommands = new List<SubCommand>();
        }
        public Command(string data)
        {
            SubCommands = new List<SubCommand>();
            string[] command = data.Split();
            OldState = command[1];
            NewState = command[4];
            for (int i = 0; i < command[0].Length; i++)
            {
                SubCommands.Add(new SubCommand(command[0][i], command[3][i], command[5][i]));
            }
        }
    }
}
