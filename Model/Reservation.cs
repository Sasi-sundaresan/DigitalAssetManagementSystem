using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagementApplication.Model
{
    public class Reservation
    {
        private int reservationId;
        private int assetId;
        private int employeeId;
        private DateTime reservationDate;
        private DateTime startDate;
        private DateTime endDate;
        private string reservationStatus;

       
        public Reservation() {
        }

       
        public Reservation(int reservationId, int assetId, int employeeId, DateTime reservationDate,
                           DateTime startDate, DateTime endDate, string status)
        {
            this.reservationId = reservationId;
            this.assetId = assetId;
            this.employeeId = employeeId;
            this.reservationDate = reservationDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.reservationStatus = status;
        }

        public int ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; }
        }

        public int AssetId
        {
            get { return assetId; }
            set { assetId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public DateTime ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string ReservationStatus
        {
            get { return reservationStatus; }
            set { reservationStatus = value; }
        }
    }
}
