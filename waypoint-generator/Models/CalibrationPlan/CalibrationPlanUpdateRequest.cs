using System.ComponentModel.DataAnnotations;

namespace waypoint_generator.Models.CalibrationPlan
{
    public class CalibrationPlanUpdateRequest
    {
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public int? MissionID { get; set; }
        public int? Type { get; set; }

        // BeamFinding
        public double? StartAzimuth { get; set; }
        public double? StepAzimuth { get; set; }
        public double? StopAzimuth { get; set; }
        public double? StartElevation { get; set; }
        public double? StepElevation { get; set; }
        public double? StopElevation { get; set; }
        public double? Buffer { get; set; }
        public double? Speed { get; set; }

        // RollAlignment
        public int Duration { get; set; }
        public float OffsetAzimuth { get; set; }
        public float OffsetElevation { get; set; }
        public bool Zenith { get; set; }

        // Shared
        public double? Radius { get; set; }
    }
}
