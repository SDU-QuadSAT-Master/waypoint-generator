public abstract class BaseScanPlan
{
    public int Id { get; set; }
    public int MissionID { get; set; }
    public string? Name { get; set; }
	public string? Comment { get; set; }

    public ScanType Type { get; set; }
}
public enum ScanType
{
    SinglePoint,
    Principal,
    Raster,

}