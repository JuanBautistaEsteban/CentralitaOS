namespace Centralita.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAliasInIncidence : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Incidences", "Alias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidences", "Alias", c => c.String());
        }
    }
}
