using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingUI1Proj.Data.Migrations
{
    public partial class AccountsAndCustomerNoLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customers",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Customers",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessAcc",
                columns: table => new
                {
                    AccountNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Customer_Id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    OverdraftInterest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAcc", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_BusinessAcc_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAcc",
                columns: table => new
                {
                    AccountNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Customer_Id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    InteresRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAcc", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_CheckingAcc_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TermDepositAcc",
                columns: table => new
                {
                    AccountNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Customer_Id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    AccruedInterest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermDepositAcc", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_TermDepositAcc_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BizTransact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    NewBalance = table.Column<double>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    BizAccAccountNum = table.Column<int>(nullable: true),
                    CheckingAccAccountNum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizTransact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BizTransact_BusinessAcc_BizAccAccountNum",
                        column: x => x.BizAccAccountNum,
                        principalTable: "BusinessAcc",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BizTransact_CheckingAcc_CheckingAccAccountNum",
                        column: x => x.CheckingAccAccountNum,
                        principalTable: "CheckingAcc",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChkTransact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    NewBalance = table.Column<double>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    ChkAccAccountNum = table.Column<int>(nullable: true),
                    BusinessAccAccountNum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChkTransact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChkTransact_BusinessAcc_BusinessAccAccountNum",
                        column: x => x.BusinessAccAccountNum,
                        principalTable: "BusinessAcc",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChkTransact_CheckingAcc_ChkAccAccountNum",
                        column: x => x.ChkAccAccountNum,
                        principalTable: "CheckingAcc",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TdcTransact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    NewBalance = table.Column<double>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: false),
                    TdcAccAccountNum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TdcTransact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TdcTransact_TermDepositAcc_TdcAccAccountNum",
                        column: x => x.TdcAccAccountNum,
                        principalTable: "TermDepositAcc",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BizTransact_BizAccAccountNum",
                table: "BizTransact",
                column: "BizAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_BizTransact_CheckingAccAccountNum",
                table: "BizTransact",
                column: "CheckingAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAcc_CustomerId",
                table: "BusinessAcc",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAcc_CustomerId",
                table: "CheckingAcc",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChkTransact_BusinessAccAccountNum",
                table: "ChkTransact",
                column: "BusinessAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_ChkTransact_ChkAccAccountNum",
                table: "ChkTransact",
                column: "ChkAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_TdcTransact_TdcAccAccountNum",
                table: "TdcTransact",
                column: "TdcAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_TermDepositAcc_CustomerId",
                table: "TermDepositAcc",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BizTransact");

            migrationBuilder.DropTable(
                name: "ChkTransact");

            migrationBuilder.DropTable(
                name: "TdcTransact");

            migrationBuilder.DropTable(
                name: "BusinessAcc");

            migrationBuilder.DropTable(
                name: "CheckingAcc");

            migrationBuilder.DropTable(
                name: "TermDepositAcc");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
