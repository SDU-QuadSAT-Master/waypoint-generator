using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<BaseScanPlan> ScanPlans { get; set; }
    public DbSet<BaseCalibrationPlan> CalibrationPlans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseNpgsql("Host=postgres; Database=waypoints; Username=usr_waypoints; Password=waypoints");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure TPH mapping for BaseScanPlan
        modelBuilder.Entity<BaseScanPlan>(entity =>
        {
            entity.ToTable("ScanPlans");
            entity.HasDiscriminator<string>("ScanPlanType")
                .HasValue<PrincipalPlan>("Principal")
                .HasValue<RasterPlan>("Raster")
                .HasValue<SinglePointPlan>("SinglePoint");
        });

        // Configure TPH mapping for BaseCalibrationPlan
        modelBuilder.Entity<BaseCalibrationPlan>(entity =>
        {
            entity.ToTable("CalibrationPlans");
            entity.HasDiscriminator<string>("CalibrationPlanType")
                .HasValue<BeamFindingPlan>("BeamFinding")
                .HasValue<RollAlignmentPlan>("RollAlignment");
        });
    }

}