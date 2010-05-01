using Machine.Specifications;
using Migrations.Net.Model;

namespace Migrations.Net.Specs.Model
{
    public class When_creating_a_table_with_no_options : MigrationSpecs
    {
        Because of = () =>
            {
                migration.CreateTable("products");
                definition = (TableDefinition)engine.Definition;
            };

        It sets_table_name_to_name_given = () => definition.Name.ShouldEqual("products");
        It sets_primary_key_to_id = () => definition["id"].ShouldBePrimaryKey();
    }

    public class When_creating_a_table_with_primary_key_given : MigrationSpecs
    {
        Because of = () =>
            {
                migration.CreateTable("products", primarykey: "product_id");
                definition = (TableDefinition) engine.Definition;
            };

        It sets_primary_key_to_value_given = () => definition["product_id"].ShouldBePrimaryKey();
    }

    public class MigrationSpecs
    {
        protected static Migration migration;
        protected static MockEngine engine;
        protected static TableDefinition definition;

        Establish context = () =>
            {
                engine = new MockEngine();
                migration = new Migration(engine);
            };
    }
}