using System;
using System.Collections.Generic;
using System.Linq;

namespace Migrations.Net.Model
{
    public class TableDefinition : MigrationDefinition
    {
        public TableDefinition(string tableName)
        {
            Name = tableName;
            Columns = new List<ColumnDefinition>();
        }

        public ColumnDefinition this[string colName]
        {
            get
            {
                return Columns.Where(c => c.Name.Equals(colName)).FirstOrDefault();
            }
        }
        public List<ColumnDefinition> Columns { get; private set; }
        public string Name { get; private set; }

        public void PrimaryKey(string name)
        {
            Column(name, integer, identity: true);
        }

        public void Column(string name, Type type, bool identity = false)
        {
            Columns.Add(new ColumnDefinition(name) { IsIdentity = identity, Type = type });
        }
    }
}