using System;

namespace Migrations.Net.Model
{
    public class ColumnDefinition
    {
        public ColumnDefinition(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Type Type { get; set; }
        public bool IsIdentity { get; set; }
    }
}