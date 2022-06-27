
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
                .WithColumn("IsOwner").AsBoolean().WithDefaultValue(true)
                .WithColumn("auth0UserId").AsString(100).Nullable()
                .WithColumn("CreatedAt").AsDateTime2().WithDefault(SystemMethods.CurrentUTCDateTime)
                .WithColumn("FirstName").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("LastName").AsString(100).Nullable();


            Create.Table("Establishments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CreatorUserId").AsInt32()
                    .ForeignKey()
                    .ReferencedBy("Id","Users")
                    .Nullable()
                .WithColumn("CreatedAt").AsDateTime2().WithDefault(SystemMethods.CurrentUTCDateTime)
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
            if (Schema.Table("Establishments").Exists())
            {
                Delete.ForeignKey().FromTable("Establishments")
                    .ForeignColumn("CreatorUserId")
                    .ToTable("Users")
                    .PrimaryColumn("Id");

                Delete.Table("Establishments");
            }

            if (Schema.Table("Users").Exists())
                Delete.Table("Users");

        }
    }
}
