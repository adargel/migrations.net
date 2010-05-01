using System;
using Machine.Specifications;
using Migrations.Net.Model;

namespace Migrations.Net.Specs.Model
{
    public static class SpecExtensions
    {
        public static ColumnDefinition ShouldBePrimaryKey(this ColumnDefinition source)
        {
            source.ShouldNotBeNull();
            source.Type.ShouldEqual(typeof(Int32));
            source.IsIdentity.ShouldBeTrue();
            return source;
        }
    }
}