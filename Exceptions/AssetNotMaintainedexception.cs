using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagementApplication.Exceptions
{
    internal class AssetNotMaintainedexception : ApplicationException
    {

        public AssetNotMaintainedexception()
        {

        }
        public AssetNotMaintainedexception(string message) : base(message) 
        {
            
        }

     
     
    }
}
