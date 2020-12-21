using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetStats.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumOfTweetsRecieved = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeRecieved = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PercentOfTweetsWithEmojis = table.Column<int>(type: "INTEGER", nullable: false),
                    TopHashtags = table.Column<string>(type: "TEXT", nullable: false),
                    PercentOfTweetsWithUrl = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentofTweetWithImageUrl = table.Column<int>(type: "INTEGER", nullable: false),
                    TopDomains = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
