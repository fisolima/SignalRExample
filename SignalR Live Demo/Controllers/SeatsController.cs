using System.Web.Http;
using Microsoft.AspNet.SignalR;
using SignalR_Live_Demo.Hubs;

namespace SignalR_Live_Demo.Controllers
{
    [RoutePrefix("api/seats")]
    public class SeatsController : ApiController
    {
        public IHttpActionResult GetSeats()
        {
            return Ok(SeatsCoordinator.SeatReservation);
        }

        [Route("size")]
        public IHttpActionResult GetSize()
        {
            return Ok(new
            {
                rows = SeatsCoordinator.RowCount,
                columns = SeatsCoordinator.ColumnCount
            });
        }

        [HttpPut]
        [Route("reset")]
        public void ResetSeats()
        {
            for (var i=0; i<SeatsCoordinator.RowCount; i++)
                for (var j=0; j<SeatsCoordinator.ColumnCount; j++)
                    SeatsCoordinator.CancelReservation( i, j);

            var seatHub = GlobalHost.ConnectionManager.GetHubContext<SeatsHub>();

            seatHub.Clients.All.reset();
        }
    }
}