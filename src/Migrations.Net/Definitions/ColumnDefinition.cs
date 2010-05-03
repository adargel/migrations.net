using System.Data;

namespace Migrations.Net.Definitions
{
    public class ColumnDefinition
    {
        public ColumnDefinition(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public DbType Type { get; set; }
        public bool IsIdentity { get; set; }
    }
}