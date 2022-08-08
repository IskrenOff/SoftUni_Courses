using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    using CommandPattern.Core.Commands;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputInfo = args.Split(' ');

            string commandName = inputInfo[0] + "Command";
            string[] parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            ICommand command = Activator.CreateInstance(type) as ICommand;
            string result = command.Execute(parameters);

            return result;
        }
    }
}
