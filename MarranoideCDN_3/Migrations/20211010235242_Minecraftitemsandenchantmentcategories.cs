using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarranoideCDN_3.Migrations
{
    public partial class Minecraftitemsandenchantmentcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinecraftEnchantCategories",
                columns: table => new
                {
                    IDEnchantCategory = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinecraftEnchantCategories", x => x.IDEnchantCategory);
                });

            migrationBuilder.CreateTable(
                name: "MinecraftItems",
                columns: table => new
                {
                    IDItem = table.Column<string>(type: "varchar(767)", nullable: false),
                    ItemIndex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(767)", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Stacksize = table.Column<int>(type: "int", nullable: false),
                    ItemIDItem = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinecraftItems", x => x.IDItem);
                    table.ForeignKey(
                        name: "FK_MinecraftItems_MinecraftItems_ItemIDItem",
                        column: x => x.ItemIDItem,
                        principalTable: "MinecraftItems",
                        principalColumn: "IDItem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    IDSession = table.Column<string>(type: "varchar(767)", nullable: false),
                    IDAccount = table.Column<string>(type: "text", nullable: false),
                    SessionToken = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.IDSession);
                });

            migrationBuilder.CreateTable(
                name: "UserRols",
                columns: table => new
                {
                    IDUserRol = table.Column<string>(type: "varchar(767)", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    UserRolName = table.Column<string>(type: "text", nullable: false),
                    UserRolPermisions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRols", x => x.IDUserRol);
                });

            migrationBuilder.CreateTable(
                name: "EnchantCategoryItem",
                columns: table => new
                {
                    EnchantCategoriesIDEnchantCategory = table.Column<string>(type: "varchar(767)", nullable: false),
                    ItemsIDItem = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnchantCategoryItem", x => new { x.EnchantCategoriesIDEnchantCategory, x.ItemsIDItem });
                    table.ForeignKey(
                        name: "FK_EnchantCategoryItem_MinecraftEnchantCategories_EnchantCatego~",
                        column: x => x.EnchantCategoriesIDEnchantCategory,
                        principalTable: "MinecraftEnchantCategories",
                        principalColumn: "IDEnchantCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnchantCategoryItem_MinecraftItems_ItemsIDItem",
                        column: x => x.ItemsIDItem,
                        principalTable: "MinecraftItems",
                        principalColumn: "IDItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IDAccount = table.Column<string>(type: "varchar(767)", nullable: false),
                    Email = table.Column<string>(type: "varchar(767)", nullable: false),
                    Username = table.Column<string>(type: "varchar(767)", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IDUserRol = table.Column<string>(type: "varchar(767)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IDAccount);
                    table.ForeignKey(
                        name: "FK_Accounts_UserRols_IDUserRol",
                        column: x => x.IDUserRol,
                        principalTable: "UserRols",
                        principalColumn: "IDUserRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "IDUserRol", "UserLevel", "UserRolName", "UserRolPermisions" },
                values: new object[] { "25DF3DC8-E441-443C-BDBB-EB8199FA7FFA", 1, "User", "+ Acceso a funciones GET del API" });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "IDUserRol", "UserLevel", "UserRolName", "UserRolPermisions" },
                values: new object[] { "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", 2, "Developer", "+ Acceso a funciones GET del API\n+ Acceso a funciones POST del API" });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "IDUserRol", "UserLevel", "UserRolName", "UserRolPermisions" },
                values: new object[] { "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", 10, "SuperU", "+ Acceso a funciones GET del API\n+ Acceso a funciones POST del API\n+ Acceso a consola de administracion del CDN" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "IDAccount", "CreatedAt", "Email", "IDUserRol", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { "62F36B2A-F1F8-4399-942F-4190771F9FCD", new DateTime(2021, 10, 10, 18, 52, 41, 646, DateTimeKind.Local).AddTicks(2939), "example2@email.com", "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", "01539fb331b8a8bd631f701705d382aebfa1230feff3b3b35084b3a4938b6f70", "User2" },
                    { "8A5AC66A-C705-471F-B508-66D4A036176D", new DateTime(2021, 10, 10, 18, 52, 41, 646, DateTimeKind.Local).AddTicks(3044), "example3@email.com", "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", "13267d10aec9b7f71b7546275f106c7dfdc83fc1a55035811c056323dda021ea", "User3" },
                    { "66CA7A17-E182-498F-AC3C-7AC25AD7ACD1", new DateTime(2021, 10, 10, 18, 52, 41, 643, DateTimeKind.Local).AddTicks(6775), "example1@email.com", "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", "01539fb331b8a8bd631f701705d382aebfa1230feff3b3b35084b3a4938b6f70", "User1" },
                    { "513E4F4B-2360-40EC-B342-33A043AB02EA", new DateTime(2021, 10, 10, 18, 52, 41, 646, DateTimeKind.Local).AddTicks(3085), "angel.g.j.reyes@gmail.com", "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", "7de7815844734a12679628fb3a3335223311c4adc74a623f72f8c89e6cb7bcc3", "Mithyck" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IDUserRol",
                table: "Accounts",
                column: "IDUserRol");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnchantCategoryItem_ItemsIDItem",
                table: "EnchantCategoryItem",
                column: "ItemsIDItem");

            migrationBuilder.CreateIndex(
                name: "IX_MinecraftEnchantCategories_Name",
                table: "MinecraftEnchantCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MinecraftItems_ItemIDItem",
                table: "MinecraftItems",
                column: "ItemIDItem");

            migrationBuilder.CreateIndex(
                name: "IX_MinecraftItems_ItemIndex",
                table: "MinecraftItems",
                column: "ItemIndex",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MinecraftItems_Name",
                table: "MinecraftItems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRols_UserLevel",
                table: "UserRols",
                column: "UserLevel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "EnchantCategoryItem");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserRols");

            migrationBuilder.DropTable(
                name: "MinecraftEnchantCategories");

            migrationBuilder.DropTable(
                name: "MinecraftItems");
        }
    }
}
