using WEEK7APIFINALSOULTION.Dto;

namespace WEEK7APIFINALSOULTION.Service
{
    public interface IRepostory
    {
        Task<string> AddActivity(Activity act);
        Task<ActivityDto> GetActivityEmail(string Email );
        Task<ActivityDto> DeleteActivityId(int id);
        Task<string> UpdateActivity(Activity act);
        Task<ActivityDto> SearchByKeyword(string keyword);
        Task<ActivityDto> GetActivityId(int id);
        
        Task<List<ActivityDto>> GetActivities();
    }
}
