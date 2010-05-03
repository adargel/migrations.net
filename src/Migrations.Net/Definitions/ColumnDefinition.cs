using System.Data;

namespace Migrations.Net.Definitions
{
    public class ColumnDefinition
    {
        public ColumnDefinition(string name, DbType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }
        public DbType Type { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsPrimaryKey { get; set; }
    }
}