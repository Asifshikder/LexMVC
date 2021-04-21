namespace LexMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfsdnkjgvfsda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        AboutUsId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.AboutUsId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(),
                        BlogImage = c.String(),
                        Content = c.String(),
                        PostTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        MapUrl = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
            CreateTable(
                "dbo.EmailSettings",
                c => new
                    {
                        EmailSettingsId = c.Int(nullable: false, identity: true),
                        SenderEmail = c.String(),
                        HostName = c.String(),
                        PortName = c.String(),
                        DisplayName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmailSettingsId);
            
            CreateTable(
                "dbo.MailBodyContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GreetingHeader = c.String(),
                        MiddleContent = c.String(),
                        FooterContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NavlinkSetups",
                c => new
                    {
                        SetupId = c.Int(nullable: false, identity: true),
                        BasicProductId = c.Int(),
                        AdvanceProductId = c.Int(),
                        UltimateProductId = c.Int(),
                    })
                .PrimaryKey(t => t.SetupId);
            
            CreateTable(
                "dbo.Privacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CartDescription = c.String(),
                        Description = c.String(),
                        OtherDescription = c.String(),
                        ProfileImage = c.String(),
                        ProfileImage1 = c.String(),
                        ProfileImage2 = c.String(),
                        VideoName = c.String(),
                        VideoUrl = c.String(),
                        ShortDescription = c.String(),
                        Amazonlink = c.String(),
                        IsFeature = c.Boolean(nullable: false),
                        FeatureImage1 = c.String(),
                        FeatureImage2 = c.String(),
                        FeatureImage3 = c.String(),
                        FeatureImage4 = c.String(),
                        FeatureImage5 = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
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
                "dbo.SiteSettings",
                c => new
                    {
                        SettingsId = c.Int(nullable: false, identity: true),
                        IsBlogEnabled = c.Boolean(nullable: false),
                        UseSmallFooter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SettingsId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
            CreateTable(
                "dbo.Warranties",
                c => new
                    {
                        WarrantyId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        OrderCode = c.String(),
                        IsLikePurchase = c.Boolean(),
                        AvailDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.WarrantyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Warranties");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Privacies");
            DropTable("dbo.NavlinkSetups");
            DropTable("dbo.MailBodyContents");
            DropTable("dbo.EmailSettings");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Categories");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.AboutUs");
        }
    }
}
