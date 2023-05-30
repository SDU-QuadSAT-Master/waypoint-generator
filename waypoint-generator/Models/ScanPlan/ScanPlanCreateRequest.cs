using System.ComponentModel.DataAnnotations;

namespace waypoint_generator.Models.ScanPlan
{
	public class ScanPlanCreateRequest
	{
        public string? Name { get; set; }

        public string? Comment { get; set; }

        public int? MissionID { get; set; }

        public int? Type { get; set; }
        // PrincipalPlan properties
        public double? Start { get; set; }
        public double? Step { get; set; }
        public double? Stop { get; set; }
        public double? Roll { get; set; }

        // RasterPlan properties
        public double? AzimuthStart { get; set; }
        public double? AzimuthStep { get; set; }
        public double? AzimuthStop { get; set; }
        public double? ElevationStart { get; set; }
        public double? ElevationStep { get; set; }
        public double? ElevationStop { get; set; }
        public int? Direction { get; set; }


        // SinglePointPlan properties
        public double? OffsetAzimuth { get; set; }
        public double? OffsetElevation { get; set; }
        public double? Duration { get; set; }

        // PrincipalPlan+RasterPlan properties
        public double? Speed { get; set; }
        public int? Plane { get; set; }

        // Shared properties
        public int Polarization { get; set; }
        public double? Radius { get; set; }

    }
}
