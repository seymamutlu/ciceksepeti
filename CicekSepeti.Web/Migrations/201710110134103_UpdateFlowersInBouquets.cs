using System.Data.Entity.Migrations;

namespace CicekSepeti.Web.Migrations
{
    public partial class UpdateFlowersInBouquets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FlowersInBouquets", "FlowerId", "dbo.Flowers");
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.Bouquets", "Name", c => c.String(false));
            AlterColumn("dbo.Flowers", "Name", c => c.String(false));
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false, true));
            AddPrimaryKey("dbo.FlowersInBouquets", "Id");
            AddForeignKey("dbo.FlowersInBouquets", "FlowerId", "dbo.Flowers", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.FlowersInBouquets", "FlowerId", "dbo.Flowers");
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false));
            AlterColumn("dbo.Flowers", "Name", c => c.String());
            AlterColumn("dbo.Bouquets", "Name", c => c.String());
            AddPrimaryKey("dbo.FlowersInBouquets", "FlowerId");
            AddForeignKey("dbo.FlowersInBouquets", "FlowerId", "dbo.Flowers", "Id");
        }
    }
}