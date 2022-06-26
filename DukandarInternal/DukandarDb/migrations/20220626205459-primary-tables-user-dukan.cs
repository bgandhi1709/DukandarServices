
using FluentMigrator;

namespace DukandarDb
{    
    [Migration(20220626205459)]
    public class PrimaryTablesUserDukan20220626205459 : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IsOwner").AsBoolean().WithDefaultValue(true);


            Create.Table("Establishment")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Address").AsString(500)
                .WithColumn("Longitude").AsDouble().NotNullable()
                .WithColumn("Latitude").AsDouble().NotNullable()
                .WithColumn("City").AsString(100)
                .WithColumn("State").AsString(100)
                .WithColumn("EstablishmentType").AsString(100)
                .WithColumn("RegistrationNumber").AsString(100);
        }

        public override void Down()
        {
            // migration rollback goes here 
        }
    }
}
