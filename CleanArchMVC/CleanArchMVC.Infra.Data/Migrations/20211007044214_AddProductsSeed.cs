using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class AddProductsSeed : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('RAM Memory 8GB', 'RAM Memory DDR4 8GB Corsain', 500.00, 19, 'memoria-ram-ddr4-8gb-corsain.png', 2)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Mouse RedDragon', 'Mouse RedDragon M608 Inquisitor', 120.00, 18, 'mouse-reddragon-m608-inquisitor.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Notebook Avell', 'Notebook Avell A52 MOB', 12000.00, 6, 'notebook-avell-a52-mob.jpg', 3)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('SSD Kingston 550GB', 'SSD M2 500GB Kingston', 700.00, 50, 'ssd-m2-550gb-kingston.jpg', 2)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('HeadSet RedDragon Zeus', 'HeadSet RedDragon Zeus', 90.00, 20, 'headset-reddragon-zeus.jpg', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
