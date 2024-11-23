

namespace DigitalAssetManagementApplication.Model
{
    public class MaintenanceRecord
    {
        private int maintenanceId;
        private int assetId;
        private DateTime maintenanceDate;
        private string description;
        private double cost;

        
        public MaintenanceRecord() {
        }

 
        public MaintenanceRecord(int maintenanceId, int assetId, DateTime maintenanceDate, string description, double cost)
        {
            this.maintenanceId = maintenanceId;
            this.assetId = assetId;
            this.maintenanceDate = maintenanceDate;
            this.description = description;
            this.cost = cost;
        }

        public int MaintenanceId
        {
            get { return maintenanceId; }
            set { maintenanceId = value; }
        }

        public int AssetId
        {
            get { return assetId; }
            set { assetId = value; }
        }

        public DateTime MaintenanceDate
        {
            get { return maintenanceDate; }
            set { maintenanceDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
