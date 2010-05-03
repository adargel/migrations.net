using System;
using System.Collections.Generic;
using System.Linq;
using Migrations.Net.Definitions;

namespace Migrations.Net.Expressions
{
    public class CreateTableExpression
    {
        public string Name { get; private set; }
        public bool IsTemporary { get; private set; }
        public bool IsForce { get; private set; }
        public List<ColumnDefinition> Columns { get; private set; }
        public string Options { get; private set; }
        public ColumnDefinition this[string colName]
        {
            get { return Columns.Where(c => c.Name.Equals(colName)).FirstOrDefault(); }
        }

        public CreateTableExpression(
            string name,
            bool force = false,
            bool temporary = false,
            bool id = true,
            string primaryKey = "id",
            string options = "",
            Action<ColumnDefinitionExpression> with = null)
        {
            Columns = new List<ColumnDefinition>();

            Name = name;
            IsTemporary = temporary;
            IsForce = force;
            Options = options;

            if (id) AddPrimaryKeyColumn(primaryKey);
            if (with != null) with(new ColumnDefinitionExpression(this));
        }

        void AddPrimaryKeyColumn(string keyColName)
        {
            Columns.Add(new PrimaryKeyColumnDefinition(keyColName));
        }
    }
}