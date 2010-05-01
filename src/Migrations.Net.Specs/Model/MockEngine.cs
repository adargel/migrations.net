using Migrations.Net.Model;

namespace Migrations.Net.Specs.Model
{
    public class MockEngine : IMigrationEngine
    {
        public MigrationDefinition Definition { get; private set; }
        public void Execute(MigrationDefinition definition)
        {
            Definition = definition;
        }
    }
}