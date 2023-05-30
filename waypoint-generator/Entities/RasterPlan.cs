public class RasterPlan : BaseScanPlan
{
    public double AzimuthStart { get; set; }
    public double AzimuthStep { get; set; }
    public double AzimuthStop { get; set; }

    public double ElevationStart { get; set; }
    public double ElevationStep { get; set; }
    public double ElevationStop { get; set; }

    public double Speed { get; set; }
    public double Radius { get; set; }

    public PlaneEnum Plane { get; set; }
    public PolarizationEnum Polarization { get; set; }
    public DirectionEnum Direction { get; set; }

    public enum PolarizationEnum
    {
        Co,
        Cross
    }

    public enum DirectionEnum
    {
        Increasing,
        Decreasing,
    }
    public enum PlaneEnum
    {
        Azimuth,
        Elevation,
        Diagonal
    }
}


