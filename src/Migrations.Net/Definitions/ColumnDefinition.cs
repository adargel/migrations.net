namespace Migrations.Net.Definitions
{
    public class ColumnDefinition
    {
        public ColumnDefinition(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}