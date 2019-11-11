using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingUI1Proj.Data.Migrations
{
    public partial class ModelsEvaluatedRe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BizTransacts");

            migrationBuilder.DropTable(
                name: "ChkTransacts");

            migrationBuilder.DropTable(
                name: "TdcTransacts");

            migrationBuilder.DropTable(
                name: "BusinessAccs");

            migrationBuilder.DropTable(
                name: "CheckingAccs");

            migrationBuilder.DropTable(
                name: "TermDepositAccs");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccName = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    Customer_Id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanName = table.Column<string>(nullable: true),
                    Principal = table.Column<double>(nullable: false),
                    BalanceAmount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    MonthlyPayment = table.Column<double>(nullable: false),
                    Customer_id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TDCAdditionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    AccruedInterest = table.Column<double>(nullable: false),
                    AccountNum = table.Column<int>(nullable: false),
                    AccountNum1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDCAdditionInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TDCAdditionInfos_Accounts_AccountNum1",
                        column: x => x.AccountNum1,
                        principalTable: "Accounts",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    NewBalance = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    AccountNum = table.Column<int>(nullable: false),
                    AccountNum1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNum1",
                        column: x => x.AccountNum1,
                        principalTable: "Accounts",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TDCAdditionInfos_AccountNum1",
                table: "TDCAdditionInfos",
                column: "AccountNum1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNum1",
                table: "Transactions",
                column: "AccountNum1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "TDCAdditionInfos");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "BusinessAccs",
                columns: table => new
                {
                    AccountNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OverdraftInterest = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAccs", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_BusinessAccs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAccs",
                columns: table => new
                {
                    AccountNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InteresRate = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccs", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_CheckingAccs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TermDepositAccs",
                columns: table => new
                {
                    AccountNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccruedInterest = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermDepositAccs", x => x.AccountNum);
                    table.ForeignKey(
                        name: "FK_TermDepositAccs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BizTransacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    BizAccAccountNum = table.Column<int>(type: "int", nullable: true),
                    CheckingAccAccountNum = table.Column<int>(type: "int", nullable: true),
                    NewBalance = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BizTransacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BizTransacts_BusinessAccs_BizAccAccountNum",
                        column: x => x.BizAccAccountNum,
                        principalTable: "BusinessAccs",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BizTransacts_CheckingAccs_CheckingAccAccountNum",
                        column: x => x.CheckingAccAccountNum,
                        principalTable: "CheckingAccs",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChkTransacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    BusinessAccAccountNum = table.Column<int>(type: "int", nullable: true),
                    ChkAccAccountNum = table.Column<int>(type: "int", nullable: true),
                    NewBalance = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChkTransacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChkTransacts_BusinessAccs_BusinessAccAccountNum",
                        column: x => x.BusinessAccAccountNum,
                        principalTable: "BusinessAccs",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChkTransacts_CheckingAccs_ChkAccAccountNum",
                        column: x => x.ChkAccAccountNum,
                        principalTable: "CheckingAccs",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TdcTransacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewBalance = table.Column<double>(type: "float", nullable: false),
                    TdcAccAccountNum = table.Column<int>(type: "int", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TdcTransacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TdcTransacts_TermDepositAccs_TdcAccAccountNum",
                        column: x => x.TdcAccAccountNum,
                        principalTable: "TermDepositAccs",
                        principalColumn: "AccountNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BizTransacts_BizAccAccountNum",
                table: "BizTransacts",
                column: "BizAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_BizTransacts_CheckingAccAccountNum",
                table: "BizTransacts",
                column: "CheckingAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAccs_CustomerId",
                table: "BusinessAccs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccs_CustomerId",
                table: "CheckingAccs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChkTransacts_BusinessAccAccountNum",
                table: "ChkTransacts",
                column: "BusinessAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_ChkTransacts_ChkAccAccountNum",
                table: "ChkTransacts",
                column: "ChkAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_TdcTransacts_TdcAccAccountNum",
                table: "TdcTransacts",
                column: "TdcAccAccountNum");

            migrationBuilder.CreateIndex(
                name: "IX_TermDepositAccs_CustomerId",
                table: "TermDepositAccs",
                column: "CustomerId");
        }
    }
}
