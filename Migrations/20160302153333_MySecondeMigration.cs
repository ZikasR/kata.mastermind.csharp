using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Mastermind.Migrations
{
    public partial class MySecondeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "trialsNumber",
                table: "Game",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "trialsNumber", table: "Game");
        }
    }
}
