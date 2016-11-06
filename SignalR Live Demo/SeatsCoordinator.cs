using System;
namespace SignalR_Live_Demo
{
    public static class SeatsCoordinator
    {
        public static readonly int RowCount = 15;
        public static readonly int ColumnCount = 7;

        public static string[,] SeatReservation { get; private set; }

        public static int UserIdSeed = 0;

        static SeatsCoordinator()
        {
            SeatReservation = new string[RowCount,ColumnCount];

            for (var i=0; i<RowCount; i++)
                for (var j = 0; j < ColumnCount; j++)
                    SeatReservation[i, j] = String.Empty;
        }

        public static void Reserve(string userId, int row, int column)
        {
            if (String.IsNullOrEmpty(userId))
                throw new ArgumentNullException("Missing userId");

            var currentUser = SeatReservation[row, column];

            if (!String.IsNullOrEmpty(currentUser) && currentUser != userId)
                throw new InvalidOperationException(string.Format("Seat {0}, {1} already reserved", row, column));

            SeatReservation[row, column] = userId;
        }

        public static void CancelReservation(int row, int column)
        {
            SeatReservation[row, column] = String.Empty;
        }
    }
}