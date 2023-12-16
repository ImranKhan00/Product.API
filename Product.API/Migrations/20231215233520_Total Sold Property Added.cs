﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.API.Migrations
{
    public partial class TotalSoldPropertyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSold",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSold",
                table: "ProductCategories");
        }
    }
}
