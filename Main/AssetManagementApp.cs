

using DigitalAssetManagementApplication.Model;
using DigitalAssetManagementApplication.Service;
using DigitalAssetManagementApplication.Utility;
using System.Data.SqlClient;

namespace DigitalAssetManagementApplication.Main
{
    internal class AssetManagementApp
    {

        private readonly AssetService assetService;
        

        public AssetManagementApp()
        {
            assetService = new AssetService();
           
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAsset Management System");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("4. Allocate Asset");
                Console.WriteLine("5. Deallocate Asset");
                Console.WriteLine("6. Perform Maintenance");
                Console.WriteLine("7. Reserve Asset");
                Console.WriteLine("8. Withdraw Reservation");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddAsset();
                        break;
                    case "2":
                        UpdateAsset();
                        break;
                    case "3":
                        DeleteAsset();
                        break;
                    case "4":
                        AllocateAsset();
                        break;
                    case "5":
                        DeallocateAsset();
                        break;
                    case "6":
                        PerformMaintenance();
                        break;
                    case "7":
                        ReserveAsset();
                        break;
                    case "8":
                        WithdrawReservation();
                        break;
                    case "9":
                        return; 
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddAsset()
        {
            Console.WriteLine("\n--- Add Asset ---");
            Console.Write("Enter Asset Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Asset Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter Serial Number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter Purchase Date (yyyy-mm-dd): ");
            DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Location: ");
            string location = Console.ReadLine();

            Console.Write("Enter Status (in use, under maintenance, decommissioned): ");
            string status = Console.ReadLine();

            Console.Write("Enter Owner ID: ");
            int ownerId = int.Parse(Console.ReadLine());

            var newAsset = new Asset(0, name, type, serialNumber, purchaseDate, location, status, ownerId);

            bool isAdded = assetService.AddAsset(newAsset);
            Console.WriteLine(isAdded ? "Asset added successfully." : "Failed to add asset.");
        }


        private void UpdateAsset()
        {
            Console.WriteLine("\n--- Update Asset ---");
            Console.Write("Enter Asset ID to Update: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Asset Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Asset Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter New Serial Number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter New Purchase Date (yyyy-mm-dd): ");
            DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter New Location: ");
            string location = Console.ReadLine();

            Console.Write("Enter New Status (in use, under maintenance, decommissioned): ");
            string status = Console.ReadLine();

            Console.Write("Enter New Owner ID: ");
            int ownerId = int.Parse(Console.ReadLine());

            var asset = new Asset(assetId, name, type, serialNumber, purchaseDate, location, status, ownerId);

            bool isUpdated = assetService.UpdateAsset(asset);
            Console.WriteLine(isUpdated ? "Asset updated successfully." : "Failed to update asset.");
        }

        private void DeleteAsset()
        {
            Console.WriteLine("\n--- Delete Asset ---");
            Console.Write("Enter Asset ID to Delete: ");
            int assetId = int.Parse(Console.ReadLine());

            bool isDeleted = assetService.DeleteAsset(assetId);
            Console.WriteLine(isDeleted ? "Asset deleted successfully." : "Failed to delete asset.");
        }

        private void AllocateAsset()
        {
            Console.WriteLine("\n--- Allocate Asset ---");
            Console.Write("Enter Asset ID: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter Allocation Date (yyyy-mm-dd): ");
            string allocationDate = Console.ReadLine();

            bool isAllocated = assetService.AllocateAsset(assetId, employeeId, allocationDate);
            Console.WriteLine(isAllocated ? "Asset allocated successfully." : "Failed to allocate asset.");
        }

        private void DeallocateAsset()
        {

          

            Console.WriteLine("\n--- Deallocate Asset ---");
            Console.Write("Enter Asset ID: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter Return Date (yyyy-mm-dd): ");
            string returnDate = Console.ReadLine();

            bool isDeallocated = assetService.DeallocateAsset(assetId, employeeId, returnDate);
            Console.WriteLine(isDeallocated ? "Asset deallocated successfully." : "Failed to deallocate asset.");
        }

        
        private void PerformMaintenance()
        {
            Console.WriteLine("\n--- Perform Maintenance ---");
            Console.Write("Enter Asset ID: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            string maintenanceDate = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Cost: ");
            double cost = double.Parse(Console.ReadLine());

            bool isMaintained = assetService.PerformMaintenance(assetId, maintenanceDate, description, cost);
            Console.WriteLine(isMaintained ? "Maintenance performed successfully." : "Failed to perform maintenance.");
        }

        private void ReserveAsset()
        {
            Console.WriteLine("\n--- Reserve Asset ---");
            Console.Write("Enter Asset ID: ");
            int assetId = int.Parse(Console.ReadLine());

            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
            string reservationDate = Console.ReadLine();

            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            string startDate = Console.ReadLine();

            Console.Write("Enter End Date (yyyy-mm-dd): ");
            string endDate = Console.ReadLine();

            bool isReserved = assetService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate);
            Console.WriteLine(isReserved ? "Asset reserved successfully." : "Failed to reserve asset.");
        }

        private void WithdrawReservation()
        {
            Console.WriteLine("\n--- Withdraw Reservation ---");
            Console.Write("Enter Reservation ID: ");
            int reservationId = int.Parse(Console.ReadLine());

            bool isWithdrawn = assetService.WithdrawReservation(reservationId);
            Console.WriteLine(isWithdrawn ? "Reservation withdrawn successfully." : "Failed to withdraw reservation.");
        }
    }
}
