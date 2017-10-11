using System.Data.Entity.Migrations;

namespace CicekSepeti.Web.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Bouquets",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.BouquetSizes",
                    c => new
                    {
                        Id = c.Int(false, true),
                        BouquetId = c.Int(false),
                        SizeId = c.Int(false),
                        Price = c.Decimal(false, 18, 2)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bouquets", t => t.BouquetId, true)
                .Index(t => t.BouquetId);

            CreateTable(
                    "dbo.Flowers",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        IsFlowering = c.Boolean(false),
                        IsThorny = c.Boolean(false),
                        IsLeafy = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.FlowersInBouquets",
                    c => new
                    {
                        FlowerId = c.Int(false),
                        BouquetSizeId = c.Int(false),
                        FlowerCount = c.Int(false),
                        Id = c.Int(false)
                    })
                .PrimaryKey(t => t.FlowerId)
                .ForeignKey("dbo.Flowers", t => t.FlowerId)
                .Index(t => t.FlowerId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.FlowersInBouquets", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.BouquetSizes", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.FlowersInBouquets", new[] {"FlowerId"});
            DropIndex("dbo.BouquetSizes", new[] {"BouquetId"});
            DropTable("dbo.FlowersInBouquets");
            DropTable("dbo.Flowers");
            DropTable("dbo.BouquetSizes");
            DropTable("dbo.Bouquets");
        }
    }
}