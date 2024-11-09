﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatedRelationsBetweenProductsAndTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductsId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagsId",
                table: "ProductTags");

            migrationBuilder.DropColumn(
                name: "IsBestSeller",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "ProductTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductTags",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagsId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "ProductTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductTags",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagsId");

            migrationBuilder.AddColumn<bool>(
                name: "IsBestSeller",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductsId",
                table: "ProductTags",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagsId",
                table: "ProductTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
