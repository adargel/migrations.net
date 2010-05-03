using System;
using System.Data;
using Migrations.Net.Definitions;

namespace Migrations.Net.Expressions
{
    public class ColumnDefinitionExpression
    {
        readonly CreateTableExpression _tableExp;

        public ColumnDefinitionExpression(CreateTableExpression tableExp)
        {
            _tableExp = tableExp;
        }

        public void Column(string colName, DbType colType)
        {
            _tableExp.Columns.Add(new ColumnDefinition(colName, colType));
        }
    }
}