public class SinglePointPlan : BaseScanPlan
{
    public double Duration { get; set; }
    public double OffsetAzimuth { get; set; }
    public double OffsetElevation { get; set; }
    public double Radius { get; set; }
    public PolarizationEnum Polarization { get; set; }
    public enum PolarizationEnum
    {
        Co,
        Cross
    }


}


