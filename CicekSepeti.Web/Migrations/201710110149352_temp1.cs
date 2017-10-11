using System.Data.Entity.Migrations;

namespace CicekSepeti.Web.Migrations
{
    public partial class temp1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false));
            AddPrimaryKey("dbo.FlowersInBouquets", "Id");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.FlowersInBouquets");
            AlterColumn("dbo.FlowersInBouquets", "Id", c => c.Int(false, true));
            AddPrimaryKey("dbo.FlowersInBouquets", "Id");
        }
    }
}