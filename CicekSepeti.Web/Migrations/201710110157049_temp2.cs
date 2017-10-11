using System.Data.Entity.Migrations;

namespace CicekSepeti.Web.Migrations
{
    public partial class temp2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false, true));
            AddPrimaryKey("dbo.FlowersInBouquets", "Id");
            CreateIndex("dbo.FlowersInBouquets", "BouquetSizeId");
            AddForeignKey("dbo.FlowersInBouquets", "BouquetSizeId", "dbo.BouquetSizes", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.FlowersInBouquets", "BouquetSizeId", "dbo.BouquetSizes");
            DropIndex("dbo.FlowersInBouquets", new[] {"BouquetSizeId"});
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false));
            AddPrimaryKey("dbo.FlowersInBouquets", "Id");
        }
    }
}