using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranscriptionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTranscriptionTextToAudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TranscriptionText",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranscriptionText",
                table: "Audios");
        }
    }
}
