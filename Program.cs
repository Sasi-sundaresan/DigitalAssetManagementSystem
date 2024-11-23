using DigitalAssetManagementApplication.dao;
using DigitalAssetManagementApplication.Main;
using DigitalAssetManagementApplication.Model;

namespace DigitalAssetManagementApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            AssetManagementApp menu = new AssetManagementApp();
            menu.ShowMenu();
          
        }
    }
}
    