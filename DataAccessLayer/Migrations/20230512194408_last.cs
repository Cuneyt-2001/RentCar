using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeling",
                columns: table => new
                {
                    FeelingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeling", x => x.FeelingID);
                });

            migrationBuilder.CreateTable(
                name: "FeelingReview",
                columns: table => new
                {
                    AllreviewsReviewID = table.Column<int>(type: "int", nullable: false),
                    FeelingsFeelingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeelingReview", x => new { x.AllreviewsReviewID, x.FeelingsFeelingID });
                    table.ForeignKey(
                        name: "FK_FeelingReview_Feeling_FeelingsFeelingID",
                        column: x => x.FeelingsFeelingID,
                        principalTable: "Feeling",
                        principalColumn: "FeelingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeelingReview_Reviews_AllreviewsReviewID",
                        column: x => x.AllreviewsReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ReviewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeelingReview_FeelingsFeelingID",
                table: "FeelingReview",
                column: "FeelingsFeelingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeelingReview");

            migrationBuilder.DropTable(
                name: "Feeling");
        }
    }
}
