using System;
using Machine.Specifications;
using Migrations.Net.Model;

namespace Migrations.Net.Specs.Model
{
    public static class SpecExtensions
    {
        public static void ShouldBePrimaryKey(this ColumnDefinition source)
        {
            source.ShouldBeColumnOfType(typeof(Int32));
            source.IsIdentity.ShouldBeTrue();
        }

        public static void ShouldBeColumnOfType(this ColumnDefinition source, Type expectedType)
        {
            source.ShouldNotBeNull();
            source.Type.ShouldEqual(typeof(Int32));
        }
    }
}