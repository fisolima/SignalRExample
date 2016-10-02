using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Live_Demo.Hubs
{
    public class SeatsHub : Hub
    {
        public void ReserveSeat(string userId, int row, int column)
        {
            try
            {
                SeatsCoordinator.Reserve(userId, row, column);
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);

                return;
            }

            Clients.All.notifyReservation(userId, row, column);
        }
    }
}