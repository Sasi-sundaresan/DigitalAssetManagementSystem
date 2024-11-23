using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagementApplication.Model
{
    public class AssetAllocation
    {
        private int allocationId;
        private int assetId;
        private int employeeId;
        private DateTime allocationDate;
        private DateTime? returnDate; 

        
        public AssetAllocation() {
        }

     
        public AssetAllocation(int allocationId, int assetId, int employeeId, DateTime allocationDate, DateTime? returnDate)
        {
            this.allocationId = allocationId;
            this.assetId = assetId;
            this.employeeId = employeeId;
            this.allocationDate = allocationDate;
            this.returnDate = returnDate;
        }

        public int AllocationId
        {
            get { return allocationId; }
            set { allocationId = value; }
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

        public DateTime AllocationDate
        {
            get { return allocationDate; }
            set { allocationDate = value; }
        }

        public DateTime? ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
    }
}
