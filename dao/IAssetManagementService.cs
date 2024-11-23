﻿

using DigitalAssetManagementApplication.Model;

namespace DigitalAssetManagementApplication.dao
{
    public interface IAssetManagementService
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);
        bool AllocateAsset(int assetId, int employeeId, string allocationDate);
        bool DeallocateAsset(int assetId, int employeeId, string returnDate);
        bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost);
        bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate);
        bool WithdrawReservation(int reservationId);
    }
}
