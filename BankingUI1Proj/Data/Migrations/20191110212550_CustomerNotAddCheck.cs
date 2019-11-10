using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingUI1Proj.Data.Migrations
{
    public partial class CustomerNotAddCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BizTransact_BusinessAcc_BizAccAccountNum",
                table: "BizTransact");

            migrationBuilder.DropForeignKey(
                name: "FK_BizTransact_CheckingAcc_CheckingAccAccountNum",
                table: "BizTransact");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessAcc_Customer_CustomerId",
                table: "BusinessAcc");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingAcc_Customer_CustomerId",
                table: "CheckingAcc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChkTransact_BusinessAcc_BusinessAccAccountNum",
                table: "ChkTransact");

            migrationBuilder.DropForeignKey(
                name: "FK_ChkTransact_CheckingAcc_ChkAccAccountNum",
                table: "ChkTransact");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_TdcTransact_TermDepositAcc_TdcAccAccountNum",
                table: "TdcTransact");

            migrationBuilder.DropForeignKey(
                name: "FK_TermDepositAcc_Customer_CustomerId",
                table: "TermDepositAcc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TermDepositAcc",
                table: "TermDepositAcc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TdcTransact",
                table: "TdcTransact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChkTransact",
                table: "ChkTransact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingAcc",
                table: "CheckingAcc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessAcc",
                table: "BusinessAcc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BizTransact",
                table: "BizTransact");

            migrationBuilder.RenameTable(
                name: "TermDepositAcc",
                newName: "TermDepositAccs");

            migrationBuilder.RenameTable(
                name: "TdcTransact",
                newName: "TdcTransacts");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "ChkTransact",
                newName: "ChkTransacts");

            migrationBuilder.RenameTable(
                name: "CheckingAcc",
                newName: "CheckingAccs");

            migrationBuilder.RenameTable(
                name: "BusinessAcc",
                newName: "BusinessAccs");

            migrationBuilder.RenameTable(
                name: "BizTransact",
                newName: "BizTransacts");

            migrationBuilder.RenameIndex(
                name: "IX_TermDepositAcc_CustomerId",
                table: "TermDepositAccs",
                newName: "IX_TermDepositAccs_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TdcTransact_TdcAccAccountNum",
                table: "TdcTransacts",
                newName: "IX_TdcTransacts_TdcAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_ApplicationUserId",
                table: "Customers",
                newName: "IX_Customers_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChkTransact_ChkAccAccountNum",
                table: "ChkTransacts",
                newName: "IX_ChkTransacts_ChkAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_ChkTransact_BusinessAccAccountNum",
                table: "ChkTransacts",
                newName: "IX_ChkTransacts_BusinessAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_CheckingAcc_CustomerId",
                table: "CheckingAccs",
                newName: "IX_CheckingAccs_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessAcc_CustomerId",
                table: "BusinessAccs",
                newName: "IX_BusinessAccs_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BizTransact_CheckingAccAccountNum",
                table: "BizTransacts",
                newName: "IX_BizTransacts_CheckingAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_BizTransact_BizAccAccountNum",
                table: "BizTransacts",
                newName: "IX_BizTransacts_BizAccAccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TermDepositAccs",
                table: "TermDepositAccs",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TdcTransacts",
                table: "TdcTransacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChkTransacts",
                table: "ChkTransacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingAccs",
                table: "CheckingAccs",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessAccs",
                table: "BusinessAccs",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BizTransacts",
                table: "BizTransacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BizTransacts_BusinessAccs_BizAccAccountNum",
                table: "BizTransacts",
                column: "BizAccAccountNum",
                principalTable: "BusinessAccs",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BizTransacts_CheckingAccs_CheckingAccAccountNum",
                table: "BizTransacts",
                column: "CheckingAccAccountNum",
                principalTable: "CheckingAccs",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessAccs_Customers_CustomerId",
                table: "BusinessAccs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingAccs_Customers_CustomerId",
                table: "CheckingAccs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkTransacts_BusinessAccs_BusinessAccAccountNum",
                table: "ChkTransacts",
                column: "BusinessAccAccountNum",
                principalTable: "BusinessAccs",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkTransacts_CheckingAccs_ChkAccAccountNum",
                table: "ChkTransacts",
                column: "ChkAccAccountNum",
                principalTable: "CheckingAccs",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TdcTransacts_TermDepositAccs_TdcAccAccountNum",
                table: "TdcTransacts",
                column: "TdcAccAccountNum",
                principalTable: "TermDepositAccs",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TermDepositAccs_Customers_CustomerId",
                table: "TermDepositAccs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BizTransacts_BusinessAccs_BizAccAccountNum",
                table: "BizTransacts");

            migrationBuilder.DropForeignKey(
                name: "FK_BizTransacts_CheckingAccs_CheckingAccAccountNum",
                table: "BizTransacts");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessAccs_Customers_CustomerId",
                table: "BusinessAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckingAccs_Customers_CustomerId",
                table: "CheckingAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChkTransacts_BusinessAccs_BusinessAccAccountNum",
                table: "ChkTransacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ChkTransacts_CheckingAccs_ChkAccAccountNum",
                table: "ChkTransacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_TdcTransacts_TermDepositAccs_TdcAccAccountNum",
                table: "TdcTransacts");

            migrationBuilder.DropForeignKey(
                name: "FK_TermDepositAccs_Customers_CustomerId",
                table: "TermDepositAccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TermDepositAccs",
                table: "TermDepositAccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TdcTransacts",
                table: "TdcTransacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChkTransacts",
                table: "ChkTransacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckingAccs",
                table: "CheckingAccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessAccs",
                table: "BusinessAccs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BizTransacts",
                table: "BizTransacts");

            migrationBuilder.RenameTable(
                name: "TermDepositAccs",
                newName: "TermDepositAcc");

            migrationBuilder.RenameTable(
                name: "TdcTransacts",
                newName: "TdcTransact");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "ChkTransacts",
                newName: "ChkTransact");

            migrationBuilder.RenameTable(
                name: "CheckingAccs",
                newName: "CheckingAcc");

            migrationBuilder.RenameTable(
                name: "BusinessAccs",
                newName: "BusinessAcc");

            migrationBuilder.RenameTable(
                name: "BizTransacts",
                newName: "BizTransact");

            migrationBuilder.RenameIndex(
                name: "IX_TermDepositAccs_CustomerId",
                table: "TermDepositAcc",
                newName: "IX_TermDepositAcc_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TdcTransacts_TdcAccAccountNum",
                table: "TdcTransact",
                newName: "IX_TdcTransact_TdcAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customer",
                newName: "IX_Customer_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChkTransacts_ChkAccAccountNum",
                table: "ChkTransact",
                newName: "IX_ChkTransact_ChkAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_ChkTransacts_BusinessAccAccountNum",
                table: "ChkTransact",
                newName: "IX_ChkTransact_BusinessAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_CheckingAccs_CustomerId",
                table: "CheckingAcc",
                newName: "IX_CheckingAcc_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BusinessAccs_CustomerId",
                table: "BusinessAcc",
                newName: "IX_BusinessAcc_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BizTransacts_CheckingAccAccountNum",
                table: "BizTransact",
                newName: "IX_BizTransact_CheckingAccAccountNum");

            migrationBuilder.RenameIndex(
                name: "IX_BizTransacts_BizAccAccountNum",
                table: "BizTransact",
                newName: "IX_BizTransact_BizAccAccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TermDepositAcc",
                table: "TermDepositAcc",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TdcTransact",
                table: "TdcTransact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChkTransact",
                table: "ChkTransact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckingAcc",
                table: "CheckingAcc",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessAcc",
                table: "BusinessAcc",
                column: "AccountNum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BizTransact",
                table: "BizTransact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BizTransact_BusinessAcc_BizAccAccountNum",
                table: "BizTransact",
                column: "BizAccAccountNum",
                principalTable: "BusinessAcc",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BizTransact_CheckingAcc_CheckingAccAccountNum",
                table: "BizTransact",
                column: "CheckingAccAccountNum",
                principalTable: "CheckingAcc",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessAcc_Customer_CustomerId",
                table: "BusinessAcc",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckingAcc_Customer_CustomerId",
                table: "CheckingAcc",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkTransact_BusinessAcc_BusinessAccAccountNum",
                table: "ChkTransact",
                column: "BusinessAccAccountNum",
                principalTable: "BusinessAcc",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkTransact_CheckingAcc_ChkAccAccountNum",
                table: "ChkTransact",
                column: "ChkAccAccountNum",
                principalTable: "CheckingAcc",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationUserId",
                table: "Customer",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TdcTransact_TermDepositAcc_TdcAccAccountNum",
                table: "TdcTransact",
                column: "TdcAccAccountNum",
                principalTable: "TermDepositAcc",
                principalColumn: "AccountNum",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TermDepositAcc_Customer_CustomerId",
                table: "TermDepositAcc",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
