using Machine.Specifications;
using Migrations.Net.Definitions;
using Migrations.Net.Expressions;

namespace Migrations.Net.Specs.Expressions
{
    public class CreateTableExpressionSpecs
    {
        protected static CreateTableExpression expression;
    }

    public class When_creating_a_table_with_no_options : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers");

        It sets_the_table_name_to_name_given = () =>
            expression.Name.ShouldEqual("customers");

        It sets_primary_key_to_id = () =>
            expression["id"].ShouldBeOfType(typeof(PrimaryKeyColumnDefinition));

        It does_not_create_a_temp_table = () =>
            expression.IsTemporary.ShouldBeFalse();

        It does_not_force_creation = () =>
            expression.IsForce.ShouldBeFalse();

        It does_not_add_options = () =>
            expression.Options.ShouldBeEmpty();
    }

    public class When_creating_a_temporary_table : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers", temporary: true);

        It creates_a_temp_table = () =>
            expression.IsTemporary.ShouldBeTrue();
    }

    public class When_forcing_table_creation : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers", force: true);

        It forces_table_creation = () =>
            expression.IsForce.ShouldBeTrue();
    }

    public class When_creating_table_with_no_id : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers", id: false);

        It does_not_create_id_column = () => expression["id"].ShouldBeNull();
    }

    public class When_creating_a_table_with_primary_key_set : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers", primaryKey: "customer_id");

        It creates_table_with_primary_key_customer_id = () =>
            expression["customer_id"].ShouldBeOfType(typeof(PrimaryKeyColumnDefinition));
    }

    public class When_creating_a_table_with_options : CreateTableExpressionSpecs
    {
        Because of = () =>
            expression = new CreateTableExpression("customers", options: "My Options");

        It creates_table_with_options_given = () =>
            expression.Options.ShouldEqual("My Options");
    }

    public class When_creating_a_table_with_column_definitions : CreateTableExpressionSpecs
    {
        static int callCount = 0;
        static ColumnDefinitionExpression cols;

        Because of = () =>
            expression = new CreateTableExpression("customers", with:
                t =>
                {
                    cols = t;
                    callCount++;
                });

        It calls_column_definition_expression = () =>
            callCount.ShouldEqual(1);

        It passes_column_definition_expression = () =>
            cols.ShouldBeOfType(typeof(ColumnDefinitionExpression));

    }
}