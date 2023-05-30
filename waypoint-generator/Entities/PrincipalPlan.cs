public class PrincipalPlan : BaseScanPlan
{
	public double Start { get; set; }
	public double Step { get; set; }
	public double Stop { get; set; }

	public double Speed { get; set; }
	public double Radius { get; set; }
	public double Roll { get; set; }
    public PlaneEnum Plane { get; set; }
    public DirectionEnum Direction { get; set; }
    public PolarizationEnum Polarization { get; set; }
    public enum DirectionEnum
    {
        Increasing,
        Decreasing
    }
    public enum PolarizationEnum
    {
        Co,
        Cross
    }
    public enum PlaneEnum
    {
        Azimuth,
        Elevation,
        Diagonal
    }


}

