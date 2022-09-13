using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDiaryRazor.Migrations
{
    public partial class DiaryEntryToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sentiment = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.EntryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");
        }
    }
}
