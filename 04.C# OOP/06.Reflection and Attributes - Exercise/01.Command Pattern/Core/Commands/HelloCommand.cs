using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
