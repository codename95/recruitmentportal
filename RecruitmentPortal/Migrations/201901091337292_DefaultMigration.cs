namespace RecruitmentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        StateID = c.Short(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        GenderID = c.Byte(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsActiveAccount = c.Boolean(nullable: false),
                        State_StateID = c.Int(),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.State_StateID)
                .Index(t => t.GenderID)
                .Index(t => t.State_StateID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Byte(nullable: false),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationID = c.Long(nullable: false, identity: true),
                        AccountID = c.Long(nullable: false),
                        JobID = c.Long(nullable: false),
                        DateApplied = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ApplicationID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Long(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobDescription = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        JobCategoryID = c.Byte(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Views = c.Int(nullable: false),
                        JobCategory_JobCategoryID = c.Short(),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.JobCategories", t => t.JobCategory_JobCategoryID)
                .Index(t => t.JobCategory_JobCategoryID);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        JobCategoryID = c.Short(nullable: false, identity: true),
                        JobCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.JobCategoryID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Long(nullable: false, identity: true),
                        DocumentTypeID = c.String(),
                        DocumentName = c.String(),
                        DocumentPath = c.String(),
                        DateCreated = c.String(),
                        AccountID = c.Long(nullable: false),
                        ApplicationID = c.Long(nullable: false),
                        GetDocumentType_DocumentTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypes", t => t.GetDocumentType_DocumentTypeID)
                .Index(t => t.ApplicationID)
                .Index(t => t.GetDocumentType_DocumentTypeID);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        DocumentTypeID = c.Int(nullable: false, identity: true),
                        DocumentTypeName = c.String(),
                    })
                .PrimaryKey(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Account_AccountID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Account_AccountID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Documents", "GetDocumentType_DocumentTypeID", "dbo.DocumentTypes");
            DropForeignKey("dbo.Documents", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Applications", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "JobCategory_JobCategoryID", "dbo.JobCategories");
            DropForeignKey("dbo.Applications", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "State_StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Accounts", "GenderID", "dbo.Genders");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Account_AccountID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Documents", new[] { "GetDocumentType_DocumentTypeID" });
            DropIndex("dbo.Documents", new[] { "ApplicationID" });
            DropIndex("dbo.Jobs", new[] { "JobCategory_JobCategoryID" });
            DropIndex("dbo.Applications", new[] { "JobID" });
            DropIndex("dbo.Applications", new[] { "AccountID" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.Accounts", new[] { "State_StateID" });
            DropIndex("dbo.Accounts", new[] { "GenderID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
            DropTable("dbo.JobCategories");
            DropTable("dbo.Jobs");
            DropTable("dbo.Applications");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Genders");
            DropTable("dbo.Accounts");
        }
    }
}
