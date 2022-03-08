using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWeatherApi.Migrations
{
    public partial class addedforecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForecastId",
                table: "WeatherEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherEvent_ForecastId",
                table: "WeatherEvent",
                column: "ForecastId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherEvent_WeatherForecast_ForecastId",
                table: "WeatherEvent",
                column: "ForecastId",
                principalTable: "WeatherForecast",
                principalColumn: "WeatherForecastID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherEvent_WeatherForecast_ForecastId",
                table: "WeatherEvent");

            migrationBuilder.DropIndex(
                name: "IX_WeatherEvent_ForecastId",
                table: "WeatherEvent");

            migrationBuilder.DropColumn(
                name: "ForecastId",
                table: "WeatherEvent");
        }
    }
}
