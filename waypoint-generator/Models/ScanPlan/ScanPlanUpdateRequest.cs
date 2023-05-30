using System.ComponentModel.DataAnnotations;

namespace waypoint_generator.Models.ScanPlan
{
    public class ScanPlanUpdateRequest
    {
        public string? Name { get; set; }

        public string? Comment { get; set; }

        public int? Type { get; set; }
        // PrincipalPlan properties

        public double? Start { get; set; }

        // RasterPlan properties
        public double? AzimuthStart { get; set; }
        public double? AzimuthStep { get; set; }
        public double? AzimuthStop { get; set; }
        public double? ElevationStart { get; set; }
        public double? ElevationStep { get; set; }
        public double? ElevationStop { get; set; }
        public double? Speed { get; set; }
        public double? Radius { get; set; }
        public int? Polarization { get; set; }
        public int? Direction { get; set; }
        public int? Plane { get; set; }

        // SinglePointPlan properties
        public double? Duration { get; set; }
    }
}
