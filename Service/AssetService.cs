using DigitalAssetManagementApplication.dao;
using DigitalAssetManagementApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagementApplication.Service
{
        internal class AssetService : AssetManagementServiceimplementation
        {
            private AssetManagementServiceimplementation dbService;

            public AssetService()
            {
                dbService = new AssetManagementServiceimplementation();
            }

            public bool AddAsset(Asset asset)
            {

                if (string.IsNullOrEmpty(asset.Name) || string.IsNullOrEmpty(asset.SerialNumber))
                {
                    Console.WriteLine("Validation Error: Asset Name or Serial Number cannot be empty.");
                    return false;
                }


                return dbService.AddAsset(asset);
            }

            public bool UpdateAsset(Asset asset)
            {

                if (string.IsNullOrEmpty(asset.Name) || string.IsNullOrEmpty(asset.SerialNumber))
                {
                    Console.WriteLine("Invalid input. Asset name and serial number cannot be empty.");
                    return false;
                }


                return dbService.UpdateAsset(asset);
            }

            public bool DeleteAsset(int assetId)
            {

                if (assetId <= 0)
                {
                    Console.WriteLine("Validation Error: Asset ID must be a positive integer.");
                    return false;
                }

                return dbService.DeleteAsset(assetId);
            }

            public bool AllocateAsset(int assetId, int employeeId, string allocationDate)
            {

                if (assetId <= 0 || employeeId <= 0 || string.IsNullOrEmpty(allocationDate))
                {
                    Console.WriteLine("Invalid input. Please provide valid asset ID, employee ID, and allocation date.");
                    return false;
                }


                return dbService.AllocateAsset(assetId, employeeId, allocationDate);
            }

            public bool DeallocateAsset(int assetId, int employeeId, string returnDate)
            {

                if (assetId <= 0 || employeeId <= 0 || string.IsNullOrEmpty(returnDate))
                {
                    Console.WriteLine("Invalid input. Please provide valid asset ID, employee ID, and return date.");
                    return false;
                }


                return dbService.DeallocateAsset(assetId, employeeId, returnDate);
            }

            public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
            {

                if (string.IsNullOrEmpty(description))
                {
                    Console.WriteLine("Validation Error: Maintenance description cannot be empty.");
                    return false;
                }

                if (cost <= 0)
                {
                    Console.WriteLine("Validation Error: Maintenance cost must be greater than zero.");
                    return false;
                }

                return dbService.PerformMaintenance(assetId, maintenanceDate, description, cost);
            }

            public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate)
            {

                if (DateTime.Parse(startDate) >= DateTime.Parse(endDate))
                {
                    Console.WriteLine("Error: The start date must be before the end date.");
                    return false;
                }


                return dbService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate);
            }

            public bool WithdrawReservation(int reservationId)
            {

                if (reservationId <= 0)
                {
                    Console.WriteLine("Validation Error: Reservation ID must be a positive integer.");
                    return false;
                }

                return dbService.WithdrawReservation(reservationId);
            }


        }
    }
