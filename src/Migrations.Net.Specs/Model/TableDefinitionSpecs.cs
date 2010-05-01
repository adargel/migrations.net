using System;
using Machine.Specifications;
using Migrations.Net.Model;

namespace Migrations.Net.Specs.Model
{
    public class TableDefinitionSpecs
    {
        protected static string tableName = "products";
        protected static TableDefinition table;
        protected static Exception result;
    }

    public class TableColumnDefinitionSpecs : TableDefinitionSpecs
    {
        Establish context = () =>
            table = new TableDefinition(tableName);
    }

    public class When_instantiating_table_definition_with_null_name : TableDefinitionSpecs
    {
        Establish context = () => tableName = null;

        Because of = () => result = Catch.Exception(() => new TableDefinition(tableName));

        It does_not_create_the_table_definition = () =>
            result.GetType().ShouldEqual(typeof(ArgumentException));
    }

    public class When_instantiating_table_definition_with_empty_name : TableDefinitionSpecs
    {
        Establish context = () => tableName = string.Empty;

        Because of = () => result = Catch.Exception(() => new TableDefinition(tableName));

        It does_not_create_the_table_definition = () =>
            result.GetType().ShouldEqual(typeof(ArgumentException));
    }

    public class When_instantiating_table_definition : TableDefinitionSpecs
    {
        Because of = () => table = new TableDefinition(tableName);

        It sets_the_definition_name_to_table_name_given = () =>
            table.Name.ShouldEqual(tableName);

        It has_no_columns = () =>
            table.Columns.Count.ShouldEqual(0);
    }

    public class When_adding_primary_key_to_table_definition : TableColumnDefinitionSpecs
    {
        Because of = () =>
            table.PrimaryKey("id");

        It should_add_id_as_primary_key = () =>
            table["id"].ShouldBePrimaryKey();
    }

    public class When_adding_column_to_table : TableColumnDefinitionSpecs
    {
        Because of = () =>
            table.Column("new_column", typeof(int));

        It adds_the_column_to_the_table = () =>
            table["new_column"].ShouldBeColumnOfType(typeof(int));
    }

    public class When_getting_column_by_name : TableColumnDefinitionSpecs
    {
        Because of = () =>
            table.Column("find_me", typeof(Int32));

        It returns_column_with_given_name = () =>
            table["find_me"].ShouldNotBeNull();
    }
}