using System.Data;
using Machine.Specifications;
using Migrations.Net.Definitions;

namespace Migrations.Net.Specs.Definitions
{
    public class When_creating_primary_key_column_definition
    {
        static PrimaryKeyColumnDefinition primaryKey;

        Because of = () => 
            primaryKey = new PrimaryKeyColumnDefinition("primary_key");

        It sets_name_to_name_given = () => 
            primaryKey.Name.ShouldEqual("primary_key");

        It sets_type_to_integer = () =>
            primaryKey.Type.ShouldEqual(DbType.Int32);

        It sets_identity_to_true = () => 
            primaryKey.IsIdentity.ShouldBeTrue();
    }
}