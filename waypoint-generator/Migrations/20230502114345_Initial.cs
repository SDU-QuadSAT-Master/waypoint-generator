using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace waypoint_generator.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalibrationPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionID = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CalibrationPlanType = table.Column<string>(type: "text", nullable: false),
                    StartAzimuth = table.Column<double>(type: "double precision", nullable: true),
                    StepAzimuth = table.Column<double>(type: "double precision", nullable: true),
                    StopAzimuth = table.Column<double>(type: "double precision", nullable: true),
                    StartElevation = table.Column<double>(type: "double precision", nullable: true),
                    StepElevation = table.Column<double>(type: "double precision", nullable: true),
                    StopElevation = table.Column<double>(type: "double precision", nullable: true),
                    Buffer = table.Column<double>(type: "double precision", nullable: true),
                    Radius = table.Column<double>(type: "double precision", nullable: true),
                    Speed = table.Column<double>(type: "double precision", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    OffsetAzimuth = table.Column<float>(type: "real", nullable: true),
                    OffsetElevation = table.Column<float>(type: "real", nullable: true),
                    RollAlignmentPlan_Radius = table.Column<float>(type: "real", nullable: true),
                    Zenith = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScanPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ScanPlanType = table.Column<string>(type: "text", nullable: false),
                    Start = table.Column<double>(type: "double precision", nullable: true),
                    Step = table.Column<double>(type: "double precision", nullable: true),
                    Stop = table.Column<double>(type: "double precision", nullable: true),
                    Speed = table.Column<double>(type: "double precision", nullable: true),
                    Radius = table.Column<double>(type: "double precision", nullable: true),
                    Roll = table.Column<double>(type: "double precision", nullable: true),
                    Plane = table.Column<int>(type: "integer", nullable: true),
                    Direction = table.Column<int>(type: "integer", nullable: true),
                    Polarization = table.Column<int>(type: "integer", nullable: true),
                    AzimuthStart = table.Column<double>(type: "double precision", nullable: true),
                    AzimuthStep = table.Column<double>(type: "double precision", nullable: true),
                    AzimuthStop = table.Column<double>(type: "double precision", nullable: true),
                    ElevationStart = table.Column<double>(type: "double precision", nullable: true),
                    ElevationStep = table.Column<double>(type: "double precision", nullable: true),
                    ElevationStop = table.Column<double>(type: "double precision", nullable: true),
                    RasterPlan_Speed = table.Column<double>(type: "double precision", nullable: true),
                    RasterPlan_Radius = table.Column<double>(type: "double precision", nullable: true),
                    RasterPlan_Plane = table.Column<int>(type: "integer", nullable: true),
                    RasterPlan_Polarization = table.Column<int>(type: "integer", nullable: true),
                    RasterPlan_Direction = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    OffsetAzimuth = table.Column<double>(type: "double precision", nullable: true),
                    OffsetElevation = table.Column<double>(type: "double precision", nullable: true),
                    SinglePointPlan_Radius = table.Column<double>(type: "double precision", nullable: true),
                    SinglePointPlan_Polarization = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanPlans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalibrationPlans");

            migrationBuilder.DropTable(
                name: "ScanPlans");
        }
    }
}
