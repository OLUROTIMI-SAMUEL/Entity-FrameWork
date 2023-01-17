using Microsoft.AspNetCore.Mvc;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Implementations
{
    public class Repostory : IRepostory
    {
        private readonly ActivityContexts _context;

        public Repostory(ActivityContexts contexts)
        {
            _context = contexts;
        }
        public async Task<string> AddActivity(Activity act)
        {
            _context.Add(act);
            _context.SaveChanges();
            return "Activity successfully added";

        }

        
        public async Task<ActivityDto > GetActivityEmail(string Email)
        {
            var activity = _context.Activitives.Where(x =>
            x.Email.ToLower().Trim() == Email.ToLower().Trim()).FirstOrDefault();

            var user = new ActivityDto
            {
                Description = activity.Description,
                Starttime = activity.Starttime,
                Duration = activity.Duration,
                Email = activity.Email
            };
            return user;
            
        }

        public async Task<ActivityDto> DeleteActivityId(int id)
        {
            var activity = _context.Activitives.Where(x=> x.id == id).FirstOrDefault();
            _context.Remove(activity);
            _context.SaveChanges();
            return new ActivityDto
            {
                Description = activity.Description,
                Starttime = activity.Starttime,
                Duration = activity.Duration,
                Email = activity.Email
            };

        }

        public async Task<List<ActivityDto>> GetActivities()
        {
            var activities = _context.Activitives.Select(x =>
            new ActivityDto
            {
                Description=x.Description,
                Starttime=x.Starttime,
                Duration=x.Duration,
                Email=x.Email
            }).ToList();

            return activities;
        }

        public async  Task<ActivityDto> GetActivityId(int id)
        {
            var activity = _context.Activitives.Where(x => x.id == id).FirstOrDefault();
            return new ActivityDto
            {
                Description = activity.Description,
                Starttime = activity.Starttime,
                Duration = activity.Duration,
                Email = activity.Email
            };
        }

        public async  Task<ActivityDto> SearchByKeyword(string keyword)
        {
           var result =  _context.Activitives.Where(x =>
            x.Description.Contains(keyword)).FirstOrDefault();
            return new ActivityDto
            {
                Description = result.Description,
                Starttime = result.Starttime,
                Duration = result.Duration,
                Email = result.Email
            };
        }

        public async Task<string> UpdateActivity(Activity act)
        {
            _context.Update(act);
            _context.SaveChanges();
            return "Data update successfully";
        }
    }
}
