using AutoMapper;
using Microsoft.EntityFrameworkCore;
using waypoint_generator.Models.CalibrationPlan;


public interface ICalibrationPlanService
{
    IEnumerable<Object> GetAll();
    BaseCalibrationPlan GetById(int id);
    IEnumerable<Object> GetAllByMissionId(int missionId);
    BaseCalibrationPlan Create(CalibrationPlanCreateRequest model);
    BaseCalibrationPlan Update(int id, CalibrationPlanUpdateRequest model);
    void Delete(int id);
}

public class CalibrationPlanService : ICalibrationPlanService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CalibrationPlanService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Object> GetAll()
    {
        var beam_finding = _context.CalibrationPlans.OfType<BeamFindingPlan>().ToList();
        var roll_alignment = _context.CalibrationPlans.OfType<RollAlignmentPlan>().ToList();

        var list = new List<object>();
        list.AddRange(beam_finding);
        list.AddRange(roll_alignment);

        return list;
    }

    public BaseCalibrationPlan GetById(int id)
    {
        var calibrationPlan = _context.CalibrationPlans.Find(id);
        if (calibrationPlan == null) throw new KeyNotFoundException("Calibration plan not found");
        return calibrationPlan;
    }
    public IEnumerable<Object> GetAllByMissionId(int missionId)
    {
        var beam_finding = _context.CalibrationPlans.Where(Plan => Plan.MissionID == missionId).OfType<BeamFindingPlan>().ToList();
        var roll_alignment = _context.CalibrationPlans.Where(Plan => Plan.MissionID == missionId).OfType<RollAlignmentPlan>().ToList();

        var list = new List<object>();
        list.AddRange(beam_finding);
        list.AddRange(roll_alignment);

        return list;
    }
    public BaseCalibrationPlan Create(CalibrationPlanCreateRequest model)
    {
        BaseCalibrationPlan baseplan;

        switch (model.Type)
        {
            case 0:
                baseplan = _mapper.Map<BeamFindingPlan>(model);
                _context.CalibrationPlans.Add(baseplan);
                _context.SaveChanges();
                return baseplan;
            case 1:
                baseplan = _mapper.Map<RollAlignmentPlan>(model);
                _context.CalibrationPlans.Add(baseplan);
                _context.SaveChanges();
                return baseplan;

            default:
                throw new KeyNotFoundException();
        }
    }

    public BaseCalibrationPlan Update(int id, CalibrationPlanUpdateRequest model)
    {
        var calibrationPlan = GetById(id);

        _mapper.Map(model, calibrationPlan);
        _context.Entry(calibrationPlan).State = EntityState.Modified;
        _context.SaveChanges();

        return calibrationPlan;
    }

    public void Delete(int id)
    {
        var calibrationPlan = GetById(id);
        _context.CalibrationPlans.Remove(calibrationPlan);
        _context.SaveChanges();
    }
}