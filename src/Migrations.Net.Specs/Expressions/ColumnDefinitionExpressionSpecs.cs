using System.Data;
using Machine.Specifications;
using Migrations.Net.Definitions;
using Migrations.Net.Expressions;

namespace Migrations.Net.Specs.Expressions
{
    public class ColumnDefinitionExpressionSpecs
    {
        protected static ColumnDefinitionExpression colExp;
        protected static CreateTableExpression tableExp;

        Establish context = () =>
            {
                tableExp = new CreateTableExpression("products");
                colExp = new ColumnDefinitionExpression(tableExp);
            };
    }

    public class When_adding_column_using_column_method_with_name_and_type : ColumnDefinitionExpressionSpecs
    {
        static ColumnDefinition column;

        Because of = () =>
            {
                colExp.Column("my_column", DbType.String);
                column = tableExp["my_column"];
            };

        It adds_the_column_to_the_table_def = () =>
            column.ShouldNotBeNull();

        It sets_the_column_type_to_value_given = () =>
            column.Type.ShouldEqual(DbType.String);

        It sets_identity_to_false = () =>
            column.IsIdentity.ShouldBeFalse();

        It sets_primary_key_to_false = () =>
            column.IsPrimaryKey.ShouldBeFalse();
    }
}