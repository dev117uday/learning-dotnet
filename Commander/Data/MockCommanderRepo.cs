using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {Id = 0, HowTo = "Create new dotnet app", Line = "dotnet new", Platform = "All"},
                new Command {Id = 0, HowTo = "Create new dotnet app", Line = "dotnet new", Platform = "All"},
                new Command {Id = 0, HowTo = "Create new dotnet app", Line = "dotnet new", Platform = "All"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command {Id = id, HowTo = "Create new dotnet app", Line = "dotnet new", Platform = "All"};
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}