using Machine.Specifications;

namespace Migrations.Net.Specs.Model
{
    public class ColumnDefinitionSpecs
    {
        public class When_instantiating_column_definition_with_name_set_to_null
        {
            It does_not_create_column_definition;
        }

        public class When_instantiating_column_definition_with_name_set_to_blank
        {
            It does_not_create_column_definition;
        }

        public class When_instantiating_column_definition
        {
            It creates_column_definition_with_given_name;
        }
    }
}