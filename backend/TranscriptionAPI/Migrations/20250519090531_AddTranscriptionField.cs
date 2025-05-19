using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranscriptionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTranscriptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranscriptionText",
                table: "Audios");

            migrationBuilder.AddColumn<string>(
                name: "Transcription",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transcription",
                table: "Audios");

            migrationBuilder.AddColumn<string>(
                name: "TranscriptionText",
                table: "Audios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
