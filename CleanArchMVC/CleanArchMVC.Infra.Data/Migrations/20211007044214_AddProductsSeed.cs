using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class AddProductsSeed : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caderno Hotweels', 'Caderno da Hotweels 10 materias', 23.99, 50, 'caderno.jpg', 3)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caneta Bic Color', 'Caneta Bic Color Vermelha', 3.50, 700, 'caneta-bic-red.jpg', 3)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
