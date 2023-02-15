﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BillSplit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "billsplit");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "billsplit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    IsSuperUser = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "User_Created_By_User_Id_fk",
                        column: x => x.CreatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "User_Deleted_By_User__fk",
                        column: x => x.DeletedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "User_Updated_By_User__fk",
                        column: x => x.UpdatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillGroup",
                schema: "billsplit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillGroup", x => x.Id);
                    table.ForeignKey(
                        name: "BillGroup_Created_By_User_Id_fk",
                        column: x => x.CreatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "BillGroup_Deleted_By_User_Id_fk",
                        column: x => x.DeletedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "BillGroup_Updated_By_User_Id_fk",
                        column: x => x.UpdatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                schema: "billsplit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    BillGroupId = table.Column<long>(type: "bigint", nullable: false),
                    PaidBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "Bill_BillGroup_Id_fk",
                        column: x => x.BillGroupId,
                        principalSchema: "billsplit",
                        principalTable: "BillGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Bill_Created_By_User_Id_fk",
                        column: x => x.CreatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Bill_Deleted_By_User__fk",
                        column: x => x.DeletedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Bill_Paid_By_User_Id_fk",
                        column: x => x.PaidBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Bill_Updated_By_User__fk",
                        column: x => x.UpdatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserBillGroup",
                schema: "billsplit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BillGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBillGroup", x => x.Id);
                    table.ForeignKey(
                        name: "UserBillGroup_Bill_Group_Id_fk",
                        column: x => x.BillGroupId,
                        principalSchema: "billsplit",
                        principalTable: "BillGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserBillGroup_Created_By_User_Id_fk",
                        column: x => x.CreatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "UserBillGroup_Deleted_By_User_Id_fk",
                        column: x => x.DeletedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserBillGroup_User_Id_fk",
                        column: x => x.UserId,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillAllocation",
                schema: "billsplit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "BillAllocation_Bill_Id_fk",
                        column: x => x.BillId,
                        principalSchema: "billsplit",
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "BillAllocation_Created_By_User_Id_fk",
                        column: x => x.CreatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "BillAllocation_Deleted_By_User__fk",
                        column: x => x.DeletedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "BillAllocation_Updated_By_User__fk",
                        column: x => x.UpdatedBy,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "BillAllocation_User_Id_fk",
                        column: x => x.UserId,
                        principalSchema: "billsplit",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_BillGroupId",
                schema: "billsplit",
                table: "Bill",
                column: "BillGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CreatedBy",
                schema: "billsplit",
                table: "Bill",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_DeletedBy",
                schema: "billsplit",
                table: "Bill",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PaidBy",
                schema: "billsplit",
                table: "Bill",
                column: "PaidBy");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UpdatedBy",
                schema: "billsplit",
                table: "Bill",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillAllocation_BillId",
                schema: "billsplit",
                table: "BillAllocation",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillAllocation_CreatedBy",
                schema: "billsplit",
                table: "BillAllocation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillAllocation_DeletedBy",
                schema: "billsplit",
                table: "BillAllocation",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillAllocation_UpdatedBy",
                schema: "billsplit",
                table: "BillAllocation",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillAllocation_UserId",
                schema: "billsplit",
                table: "BillAllocation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillGroup_CreatedBy",
                schema: "billsplit",
                table: "BillGroup",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillGroup_DeletedBy",
                schema: "billsplit",
                table: "BillGroup",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillGroup_UpdatedBy",
                schema: "billsplit",
                table: "BillGroup",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                schema: "billsplit",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_DeletedBy",
                schema: "billsplit",
                table: "User",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedBy",
                schema: "billsplit",
                table: "User",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserBillGroup_BillGroupId",
                schema: "billsplit",
                table: "UserBillGroup",
                column: "BillGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBillGroup_CreatedBy",
                schema: "billsplit",
                table: "UserBillGroup",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserBillGroup_DeletedBy",
                schema: "billsplit",
                table: "UserBillGroup",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "UserBillGroup_UserId_BillGroupId_uindex",
                schema: "billsplit",
                table: "UserBillGroup",
                columns: new[] { "UserId", "BillGroupId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillAllocation",
                schema: "billsplit");

            migrationBuilder.DropTable(
                name: "UserBillGroup",
                schema: "billsplit");

            migrationBuilder.DropTable(
                name: "Bill",
                schema: "billsplit");

            migrationBuilder.DropTable(
                name: "BillGroup",
                schema: "billsplit");

            migrationBuilder.DropTable(
                name: "User",
                schema: "billsplit");
        }
    }
}
