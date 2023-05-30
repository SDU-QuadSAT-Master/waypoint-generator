using AutoMapper;
using Microsoft.EntityFrameworkCore;
using waypoint_generator.Models.ScanPlan;

public interface IScanPlanService
{
    IEnumerable<Object> GetAll();
    BaseScanPlan GetById(int id);
    IEnumerable<Object> GetAllByMissionId(int missionId);
    BaseScanPlan Create(ScanPlanCreateRequest model);
    BaseScanPlan Update(int id, ScanPlanUpdateRequest model);
    void Delete(int id);
}

public class ScanPlanService : IScanPlanService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ScanPlanService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Object> GetAll()
    {
        var single_point = _context.ScanPlans.OfType<SinglePointPlan>().ToList();
        var principal = _context.ScanPlans.OfType<PrincipalPlan>().ToList();
        var raster = _context.ScanPlans.OfType<RasterPlan>().ToList();


        var list = new List<object>();
        list.AddRange(single_point);
        list.AddRange(principal);
        list.AddRange(raster);

        return list;

    }

    public BaseScanPlan GetById(int id)
    {
        var scanPlan = _context.ScanPlans.Find(id);
        if (scanPlan == null) throw new KeyNotFoundException("Scan plan not found");
        return scanPlan;
    }
    public IEnumerable<Object> GetAllByMissionId(int missionId)
    {
        var single_point = _context.ScanPlans.Where(Plan => Plan.MissionID == missionId).OfType<SinglePointPlan>().ToList();
        var principal = _context.ScanPlans.Where(Plan => Plan.MissionID == missionId).OfType<PrincipalPlan>().ToList();
        var raster = _context.ScanPlans.Where(Plan => Plan.MissionID == missionId).OfType<RasterPlan>().ToList();

        var list  = new List<object>();
        list.AddRange(single_point);
        list.AddRange(principal);
        list.AddRange(raster);


        return list;
    }
    public BaseScanPlan Create(ScanPlanCreateRequest model)
    {
        BaseScanPlan baseplan;

        switch (model.Type)
        {
            case 0:
                baseplan = _mapper.Map<SinglePointPlan>(model);
                _context.ScanPlans.Add(baseplan);
                _context.SaveChanges();
                return baseplan;
            case 1:
                baseplan = _mapper.Map<PrincipalPlan>(model);
                _context.ScanPlans.Add(baseplan);
                _context.SaveChanges();
                return baseplan;
            case 2:
                baseplan = _mapper.Map<RasterPlan>(model);
                _context.ScanPlans.Add(baseplan);
                _context.SaveChanges();
                return baseplan;

            default:
                throw new KeyNotFoundException();
        }

        
    }

    public BaseScanPlan Update(int id, ScanPlanUpdateRequest model)
    {
        var scanPlan = GetById(id);

        _mapper.Map(model, scanPlan);
        _context.Entry(scanPlan).State = EntityState.Modified;
        _context.SaveChanges();

        return scanPlan;
    }

    public void Delete(int id)
    {
        var scanPlan = GetById(id);
        _context.ScanPlans.Remove(scanPlan);
        _context.SaveChanges();
    }
}