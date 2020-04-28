using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiLineTuringMachine
{
    class Machine
    {
        public List<Command> Commands { get; set; }
        public List<int> CurrPositions { get; set; }
        public string CurrState { get; set; }
        public List<string> Strings { get; set; }
        public List<string> Protocol { get; set; }

        public Machine()
        {
            Commands = new List<Command>();
            CurrPositions = new List<int>();
            CurrState = "q0";
            Strings = new List<string>();
            Protocol = new List<string>();
        }
        public void ParseCommands(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Commands.Add(new Command(line));
                }
            }
        }

        public string Run(params string[] inputWords)
        {
            ResetMachine();
            foreach (var el in inputWords)
            {
                Strings.Add($"__{el}__");
            }
            Strings.Add("______");
            while (true)
            {
                for (int i = 0; i < Strings.Count; i++)
                {
                    Protocol.Add($"Line{i}: {Strings[i]}");
                }
                Protocol.Add("\n");
                if (CurrState == "qf")
                {
                    break;
                }
                foreach (var el in Commands)
                {
                    if (el.OldState == CurrState && CheckCurSymb(el.SubCommands))
                    {
                        ChangeSymb(el.SubCommands);
                        CurrState = el.NewState;
                        break;
                    }
                }
                AddLambda();
            }
            return Strings.Last().Replace("_", "");
        }
        public void PrintProtocol(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var el in Protocol)
                {
                    sw.WriteLine(el);
                }
            }
        }

        // Функція додавання пустих комірок по краях (імітація нескінченної стрічки)
        // як порожній символ я використовував _
        private void AddLambda()
        {
            for (int i = 0; i < Strings.Count; i++)
            {
                if (Strings[i].Substring(0, 3) != "___")
                {
                    Strings[i] = "___" + Strings[i];
                    CurrPositions[i] += 3;
                }
                if (Strings[i].Substring(Strings[i].Length - 4, 3) != "___")
                {
                    Strings[i] += "___";
                }
            }
        }

        bool CheckCurSymb(List<SubCommand> subCommands)
        {
            for (int i = 0; i < Strings.Count; i++)
            {
                if(subCommands[i].OldSymb != Strings[i][CurrPositions[i]])
                {
                    return false;
                }
            }
            return true;
        }

        void ChangeSymb(List<SubCommand> subCommands)
        {
            for (int i = 0; i < Strings.Count; i++)
            {
                Strings[i] = Strings[i].Substring(0, CurrPositions[i]) + subCommands[i].NewSymb + Strings[i].Substring(CurrPositions[i] + 1, Strings[i].Length - CurrPositions[i] - 1);
                if (subCommands[i].Direction == 'R')
                {
                    CurrPositions[i]++;
                }
                else if (subCommands[i].Direction == 'L')
                {
                    CurrPositions[i]--;
                }
            }
        }

        void ResetMachine()
        {
            CurrState = "q0";
            Strings.Clear();
            CurrPositions.Clear();
            Protocol.Clear();
            for (int i = 0; i < Commands.FirstOrDefault().SubCommands.Count; i++)
            {
                CurrPositions.Add(2);
            }
        }
    }
}
