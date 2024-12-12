using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRecommenderIA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JdmCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Of_Cyl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aspiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horsepower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Torque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Top_Speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drive_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curb_Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel_Economy_MPG = table.Column<float>(type: "real", nullable: true),
                    Price_USD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JdmCars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JdmCars");
        }
    }
}
