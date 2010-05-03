using Migrations.Net.Model;

namespace Migrations.Net.Definitions
{
    public class PrimaryKeyColumnDefinition : ColumnDefinition
    {
        public PrimaryKeyColumnDefinition(string keyColName)
            : base(keyColName, typeof(int))
        {
            IsIdentity = true;
            IsPrimaryKey = true;
        }
    }
}