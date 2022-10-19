namespace Centralita.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAliasInIncidence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidences", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidences", "Alias");
        }
    }
}
