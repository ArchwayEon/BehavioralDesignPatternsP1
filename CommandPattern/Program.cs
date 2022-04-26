using CommandPattern.GOF;
using System;
using System.Collections.Generic;

namespace CommandPattern
{
   class Program
   {
      private Dictionary<string, Command> _commands;

      static void Main(string[] args)
      {
         Program program = new Program();
         Application app = new Application();
         program.CreateCommands(app);
         string command = program.ShowMenu();
         while(command != "X")
         {
            program.DoCommand(command);
            command = program.ShowMenu();
         }
      }

      void CreateCommands(Application app)
      {
         _commands = new Dictionary<string, Command>
         {
            ["1"] = new OpenCommand(app),
            ["2"] = new DeleteCommand(app),
            ["3"] = new ShowAllCommand(app)
         };
      }

      string ShowMenu()
      {
         Console.WriteLine("1. Open Document");
         Console.WriteLine("2. Delete Document");
         Console.WriteLine("3. Show all");
         Console.WriteLine("X. Exit");
         Console.Write("Enter choice: ");
         return Console.ReadLine();
      }

      void DoCommand(string option)
      {
         if (!_commands.ContainsKey(option)) return;
         _commands[option].Execute();
      }
   }
}
