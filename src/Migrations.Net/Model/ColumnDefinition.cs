using System;

namespace Migrations.Net.Model
{
    public class ColumnDefinition
    {
        public ColumnDefinition(string name, Type columnType)
        {
            Name = name;
            Type = columnType;
        }

        public string Name { get; private set; }
        public Type Type { get; set; }
        public bool IsIdentity { get; set; }
        protected bool IsPrimaryKey { get; set; }
    }
}