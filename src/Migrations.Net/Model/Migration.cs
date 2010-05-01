namespace Migrations.Net.Model
{
    public class Migration : ColumnTypes
    {
        readonly IMigrationEngine _engine;

        public Migration(IMigrationEngine engine)
        {
            _engine = engine;
        }

        public void CreateTable(string tableName, string primarykey="id")
        {
            var table = new TableDefinition(tableName);
            table.PrimaryKey(primarykey);
            _engine.Execute(table);
        }
    }
}