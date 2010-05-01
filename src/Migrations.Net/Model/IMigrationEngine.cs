namespace Migrations.Net.Model
{
    public interface IMigrationEngine
    {
        void Execute(MigrationDefinition definition);
    }
}