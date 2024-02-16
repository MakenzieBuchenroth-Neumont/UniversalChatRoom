using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversalChatRoom.Migrations
{
    public partial class kolteninitialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomProfiles_Profile_ProfileID",
                table: "ChatroomProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profile_ProfileID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_UserID",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserID",
                table: "Profiles",
                newName: "IX_Profiles_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomProfiles_Profiles_ProfileID",
                table: "ChatroomProfiles",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_ProfileID",
                table: "Messages",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserID",
                table: "Profiles",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatroomProfiles_Profiles_ProfileID",
                table: "ChatroomProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_ProfileID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserID",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserID",
                table: "Profile",
                newName: "IX_Profile_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatroomProfiles_Profile_ProfileID",
                table: "ChatroomProfiles",
                column: "ProfileID",
                principalTable: "Profile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profile_ProfileID",
                table: "Messages",
                column: "ProfileID",
                principalTable: "Profile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_UserID",
                table: "Profile",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
