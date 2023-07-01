using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

       [HttpGet] //api/activities
       public async Task<ActionResult<List<Activity>>> GetActivities()
       {
        return await Mediator.Send(new List.Query());
       }


       [HttpGet("{id}")] //api/activities/id
       public async Task<ActionResult<Activity>> GetActivity(Guid id)
       {
            return await Mediator.Send(new Details.Query{Id=id});
       }


       [HttpPost]
       public async Task<ActionResult> CreateActivity(Activity activity)
       {
            return Ok(await Mediator.Send(new Create.Command{Activity=activity}));
       }


       [HttpPut("{id}")] //api/activities/id
       public async Task<ActionResult<Activity>> EditActivity(Guid id, Activity activity)
       {
            activity.Id=id;
            return Ok(await Mediator.Send(new Edit.Command{Activity=activity}));
       }


       [HttpDelete("{id}")] //api/activities/id
       public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
       {
            return Ok(await Mediator.Send(new Delete.Command{Id=id}));
       }

    }
}