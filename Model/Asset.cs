

namespace DigitalAssetManagementApplication.Model
{
    public class Asset
    {
        private int assetId;
        private string assetName;
        private string assetType;
        private string serialNumber;
        private DateTime purchaseDate;
        private string location;
        private string assetStatus;
        private int ownerId;

      
        public Asset() {
        }


        public Asset(int assetId, string name, string type, string serialNumber, DateTime purchaseDate,
                     string location, string status, int ownerId)
        {
            this.assetId = assetId;
            this.assetName = name;
            this.assetType = type;
            this.serialNumber = serialNumber;
            this.purchaseDate = purchaseDate;
            this.location = location;
            this.assetStatus = status;
            this.ownerId = ownerId;
        }

        public int AssetId
        {
            get { return assetId; }
            set { assetId = value; }
        }

        public string Name
        {
            get { return assetName; }
            set { assetName = value; }
        }

        public string TypeProp
        {
            get { return assetType; }
            set { assetType = value; }
        }

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Status
        {
            get { return assetStatus; }
            set { assetStatus = value; }
        }

        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }
    }
}
