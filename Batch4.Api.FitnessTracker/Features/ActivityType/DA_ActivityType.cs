using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.FitnessTracker.Features.ActivityType;

public class DA_ActivityType
{
    private readonly AppDbContext _context;

    public DA_ActivityType(AppDbContext context)
    {
        _context = context;
    }

    public List<Tbl_ActivityType> GetActivityTypes()
    {
        var lst = _context.ActivityTypes.ToList();
        return lst;
    }

    public async Task<Tbl_ActivityType> GetActivityTypeByIdAsyn(int activityTypeId)
    {
        var item = await _context.ActivityTypes.FirstOrDefaultAsync(x =>
            x.ActivityTypeId == activityTypeId
        );

        if (item is null)
            return new Tbl_ActivityType() { ActivityTypeId = -1 };

        return item;
    }

    public Tbl_ActivityType CreateActivityType(string activityTypeName)
    {
        Tbl_ActivityType activityType = new Tbl_ActivityType();
        activityType.ActivityTypeName = activityTypeName;

        var entry = _context.ActivityTypes.Add(activityType);
        var result = _context.SaveChanges();
        if (result > 0)
        {
            activityType.ActivityTypeId = entry.Entity.ActivityTypeId;
        }
        return activityType;
    }
}
