using System.Data;

namespace Migrations.Net.Definitions
{
    public class PrimaryKeyColumnDefinition : ColumnDefinition
    {
        public PrimaryKeyColumnDefinition(string keyColName)
            : base(keyColName, DbType.Int32)
        {
            IsIdentity = true;
            IsPrimaryKey = true;
        }
    }
}