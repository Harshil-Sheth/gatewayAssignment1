namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'92a632bf-7502-40aa-aad0-32a2b9b74f09', N'guest@1.com', 0, N'ACnUz41ONW+oPVaFBPF6T6WpswwrZK7UGJ5DtLgygzlVJ9OX7WFsWU6lYF+WHtnRcg==', N'973793e9-9717-4d38-9bd0-d150be7becf4', NULL, 0, 0, NULL, 1, 0, N'guest@1.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aab51426-b009-4ea5-8cbc-32ed515ac5fa', N'admin@1.com', 0, N'AMwNUQdDw90v8iu2Y4K6Cpz9lsclYx6EV+VoXWPUOjnoCYfwR7OfhTeokAcweZywsA==', N'25ab0ca5-2821-4405-8e97-40ef32f8ed04', NULL, 0, 0, NULL, 1, 0, N'admin@1.com') 
                
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f1e2f40d-0f2b-4447-be48-9e5ef0b2aaba', N'CanManageProducts')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aab51426-b009-4ea5-8cbc-32ed515ac5fa', N'f1e2f40d-0f2b-4447-be48-9e5ef0b2aaba')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
