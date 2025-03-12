using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TQMS_Admin_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Org_Id",
                table: "Department",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Org_Id",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Department_Org_Id",
                table: "Department",
                column: "Org_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Org_Id",
                table: "Branches",
                column: "Org_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Organizations_Org_Id",
                table: "Branches",
                column: "Org_Id",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Organizations_Org_Id",
                table: "Department",
                column: "Org_Id",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Organizations_Org_Id",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Organizations_Org_Id",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_Org_Id",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Org_Id",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Org_Id",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Org_Id",
                table: "Branches");
        }
    }
}
