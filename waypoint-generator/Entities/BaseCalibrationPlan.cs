public abstract class BaseCalibrationPlan
{
    public int? Id { get; set; }
    public int? MissionID { get; set; }
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public CalibrationType Type { get; set; }

    public enum CalibrationType
    {
        BeamFinding,
        RollAlignment,
    }


}