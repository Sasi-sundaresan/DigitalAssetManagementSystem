
using DigitalAssetManagementApplication.Exceptions;
using DigitalAssetManagementApplication.Model;
using DigitalAssetManagementApplication.Utility;
using System.Data.SqlClient;

namespace DigitalAssetManagementApplication.dao
{
    public class AssetManagementServiceimplementation : IAssetManagementService
    {

        private  string connectionString;

        public AssetManagementServiceimplementation()
        {
            connectionString = DbConnUtil.GetConnectionString(); 
        }

    
        public bool AddAsset(Asset asset)
        {
            string checkQuery = @"SELECT COUNT(1) FROM assets WHERE serial_number = @serial_number";
            string insertQuery = @"INSERT INTO assets (asset_name, asset_type, serial_number, purchase_date, location, asset_status, owner_id)
                                   VALUES (@asset_name, @asset_type, @serial_number, @purchase_date, @location, @asset_status, @owner_id)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        Console.WriteLine("Error: Asset with this serial number already exists.");
                        return false;
                    }

                   
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@asset_name", asset.Name);
                    insertCommand.Parameters.AddWithValue("@asset_type", asset.TypeProp);
                    insertCommand.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                    insertCommand.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                    insertCommand.Parameters.AddWithValue("@location", asset.Location);
                    insertCommand.Parameters.AddWithValue("@asset_status", asset.Status);
                    insertCommand.Parameters.AddWithValue("@owner_id", asset.OwnerId);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAssetToDb: {ex.Message}");
                return false;
            }
        }


        public bool UpdateAsset(Asset asset)
        {
            string connectionString = DbConnUtil.GetConnectionString();

            string checkQuery = @"SELECT COUNT(1) FROM assets WHERE asset_id = @asset_id";

            string updateQuery = @"UPDATE assets 
                           SET asset_name = @asset_name, 
                               asset_type = @asset_type, 
                               serial_number = @serial_number, 
                               purchase_date = @purchase_date, 
                               location = @location, 
                               asset_status = @asset_status, 
                               owner_id = @owner_id
                           WHERE asset_id = @asset_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@asset_id", asset.AssetId);
                    int assetExists = (int)checkCommand.ExecuteScalar();

                    if (assetExists == 0)
                    {
                        throw new AssetNotFoundexception($"Asset with ID {asset.AssetId} does not exist.");
                    }

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@asset_name", asset.Name);
                    updateCommand.Parameters.AddWithValue("@asset_type", asset.TypeProp);
                    updateCommand.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                    updateCommand.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                    updateCommand.Parameters.AddWithValue("@location", asset.Location);
                    updateCommand.Parameters.AddWithValue("@asset_status", asset.Status);
                    updateCommand.Parameters.AddWithValue("@owner_id", asset.OwnerId);
                    updateCommand.Parameters.AddWithValue("@asset_id", asset.AssetId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }

            catch (AssetNotFoundexception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error updating asset: {ex.Message}");
                return false;
            }
        }



      
        public bool DeleteAsset(int assetId)
        {
            string checkQuery = @"SELECT COUNT(1) FROM assets WHERE asset_id = @asset_id";

            string deleteQuery = @"DELETE FROM assets WHERE asset_id = @asset_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@asset_id", assetId);
                    int assetExists = (int)checkCommand.ExecuteScalar();

                    if (assetExists == 0)
                    {
                        throw new AssetNotFoundexception($"Asset with ID {assetId} does not exist.");
                    }

                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@asset_id", assetId);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }

            catch (AssetNotFoundexception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting asset: {ex.Message}");
                return false;
            }
        }


        public bool AllocateAsset(int assetId, int employeeId, string allocationDate)
        {
            string checkAssetQuery = "SELECT COUNT(1) FROM assets WHERE asset_id = @asset_id ";
            string checkEmployeeQuery = "SELECT COUNT(1) FROM employees WHERE employee_id = @employee_id";
            string insertAllocationQuery = @"INSERT INTO asset_allocations (asset_id, employee_id, allocation_date)
                                     VALUES (@asset_id, @employee_id, @allocation_date)";
            string updateAssetStatusQuery = "UPDATE assets SET asset_status = 'in use' WHERE asset_id = @asset_id";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    SqlCommand checkAssetCommand = new SqlCommand(checkAssetQuery, connection);
                    checkAssetCommand.Parameters.AddWithValue("@asset_id", assetId);
                    int assetCount = (int)checkAssetCommand.ExecuteScalar();
                    if (assetCount == 0)
                    {
                        throw new AssetNotFoundexception($"Asset with ID {assetId} does not exist.");
                    }

                  
                    SqlCommand checkEmployeeCommand = new SqlCommand(checkEmployeeQuery, connection);
                    checkEmployeeCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    int employeeCount = (int)checkEmployeeCommand.ExecuteScalar();
                    if (employeeCount == 0)
                    {
                        Console.WriteLine("Error: Employee does not exist.");
                        return false;
                    }

                    
                    SqlCommand insertAllocationCommand = new SqlCommand(insertAllocationQuery, connection);
                    insertAllocationCommand.Parameters.AddWithValue("@asset_id", assetId);
                    insertAllocationCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    insertAllocationCommand.Parameters.AddWithValue("@allocation_date", allocationDate);

                    int rowsInserted = insertAllocationCommand.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        
                        SqlCommand updateAssetStatusCommand = new SqlCommand(updateAssetStatusQuery, connection);
                        updateAssetStatusCommand.Parameters.AddWithValue("@asset_id", assetId);
                        updateAssetStatusCommand.ExecuteNonQuery();

                        Console.WriteLine("Asset allocated successfully and status updated to 'in use'.");
                        return true;
                    }


                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error allocating asset: {ex.Message}");
                return false;
            }
        }

        public bool DeallocateAsset(int assetId, int employeeId, string returnDate)
        {
            string checkAllocationQuery = @"SELECT COUNT(1) 
                                    FROM asset_allocations 
                                    WHERE asset_id = @asset_id AND employee_id = @employee_id AND return_date IS NULL";
            string updateAllocationQuery = @"UPDATE asset_allocations 
                                     SET return_date = @return_date 
                                     WHERE asset_id = @asset_id AND employee_id = @employee_id AND return_date IS NULL";
            string updateAssetStatusQuery = @"UPDATE assets 
                                      SET asset_status = 'available' 
                                      WHERE asset_id = @asset_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkAllocationCommand = new SqlCommand(checkAllocationQuery, connection);
                    checkAllocationCommand.Parameters.AddWithValue("@asset_id", assetId);
                    checkAllocationCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    int allocationCount = (int)checkAllocationCommand.ExecuteScalar();

                    if (allocationCount == 0)
                    {
                        Console.WriteLine("Error: No active allocation found for the given asset and employee.");
                        return false;
                    }


                    SqlCommand updateAllocationCommand = new SqlCommand(updateAllocationQuery, connection);
                    updateAllocationCommand.Parameters.AddWithValue("@asset_id", assetId);
                    updateAllocationCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    updateAllocationCommand.Parameters.AddWithValue("@return_date", returnDate);

                    int rowsUpdated = updateAllocationCommand.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {

                        SqlCommand updateAssetStatusCommand = new SqlCommand(updateAssetStatusQuery, connection);
                        updateAssetStatusCommand.Parameters.AddWithValue("@asset_id", assetId);
                        updateAssetStatusCommand.ExecuteNonQuery();

                        return true; 
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deallocating asset: {ex.Message}");
                return false;
            }
        }

        public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
        {
            string connectionString = DbConnUtil.GetConnectionString();
            string checkAssetQuery = @"SELECT COUNT(1) FROM assets WHERE asset_id = @asset_id";
            string lastMaintenanceQuery = @"SELECT MAX(maintenance_date) FROM maintenance_records WHERE asset_id = @asset_id";
            string insertMaintenanceQuery = @"INSERT INTO maintenance_records (asset_id, maintenance_date, description, cost)
                                      VALUES (@asset_id, @maintenance_date, @description, @cost)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkAssetCommand = new SqlCommand(checkAssetQuery, connection);
                    checkAssetCommand.Parameters.AddWithValue("@asset_id", assetId);
                    int assetCount = (int)checkAssetCommand.ExecuteScalar();

                    if (assetCount == 0)
                    {
                        throw new AssetNotFoundexception($"Asset with ID {assetId} does not exist.");
                    }

                    
                    SqlCommand lastMaintenanceCommand = new SqlCommand(lastMaintenanceQuery, connection);
                    lastMaintenanceCommand.Parameters.AddWithValue("@asset_id", assetId);
                    object lastMaintenanceResult = lastMaintenanceCommand.ExecuteScalar();

                    if (lastMaintenanceResult != DBNull.Value)
                    {
                        DateTime lastMaintenanceDate = Convert.ToDateTime(lastMaintenanceResult);
                        DateTime maintenanceThreshold = DateTime.Now.AddYears(-2);

                        if (lastMaintenanceDate < maintenanceThreshold)
                        {
                            throw new AssetNotMaintainedexception($"Asset with ID {assetId} has not been maintained for over 2 years. Last maintenance date: {lastMaintenanceDate.ToShortDateString()}");
                        }
                    }

                    
                    SqlCommand insertMaintenanceCommand = new SqlCommand(insertMaintenanceQuery, connection);
                    insertMaintenanceCommand.Parameters.AddWithValue("@asset_id", assetId);
                    insertMaintenanceCommand.Parameters.AddWithValue("@maintenance_date", maintenanceDate);
                    insertMaintenanceCommand.Parameters.AddWithValue("@description", description);
                    insertMaintenanceCommand.Parameters.AddWithValue("@cost", cost);

                    int rowsAffected = insertMaintenanceCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (AssetNotFoundexception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (AssetNotMaintainedexception ex)
            {
               
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error performing maintenance: {ex.Message}");
                return false;
            }
        }


        public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate)
        {
            string checkAvailabilityQuery = @"SELECT asset_status FROM assets WHERE asset_id = @asset_id";

            string checkReservationQuery = @"SELECT COUNT(1) FROM reservations WHERE asset_id = @asset_id AND
                                ((start_date BETWEEN @start_date AND @end_date) OR
                                (end_date BETWEEN @start_date AND @end_date))";

            string insertReservationQuery = @"INSERT INTO reservations (asset_id, employee_id, reservation_date, start_date, end_date, reser_status)
                                  VALUES (@asset_id, @employee_id, @reservation_date, @start_date, @end_date, 'pending')";

            string updateAssetStatusQuery = @"UPDATE assets SET asset_status = 'under maintenance' WHERE asset_id = @asset_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    SqlCommand checkAvailabilityCommand = new SqlCommand(checkAvailabilityQuery, connection);
                    checkAvailabilityCommand.Parameters.AddWithValue("@asset_id", assetId);
                    string assetStatus = (string)checkAvailabilityCommand.ExecuteScalar();

                    if (assetStatus != "in use")
                    {
                        Console.WriteLine("Asset is not available for reservation.");
                        return false;
                    }

                    // check the asset is already reserved with  date range
                    SqlCommand checkReservationCommand = new SqlCommand(checkReservationQuery, connection);
                    checkReservationCommand.Parameters.AddWithValue("@asset_id", assetId);
                    checkReservationCommand.Parameters.AddWithValue("@start_date", startDate);
                    checkReservationCommand.Parameters.AddWithValue("@end_date", endDate);
                    int reservationCount = (int)checkReservationCommand.ExecuteScalar();

                    if (reservationCount > 0)
                    {
                        Console.WriteLine("Asset is already reserved for the specified dates.");
                        return false;
                    }

                    
                    SqlCommand insertCommand = new SqlCommand(insertReservationQuery, connection);
                    insertCommand.Parameters.AddWithValue("@asset_id", assetId);
                    insertCommand.Parameters.AddWithValue("@employee_id", employeeId);
                    insertCommand.Parameters.AddWithValue("@reservation_date", reservationDate);
                    insertCommand.Parameters.AddWithValue("@start_date", startDate);
                    insertCommand.Parameters.AddWithValue("@end_date", endDate);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                        SqlCommand updateAssetStatusCommand = new SqlCommand(updateAssetStatusQuery, connection);
                        updateAssetStatusCommand.Parameters.AddWithValue("@asset_id", assetId);
                        updateAssetStatusCommand.ExecuteNonQuery();
                    }

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reserving asset: {ex.Message}");
                return false;
            }
        }

        public bool WithdrawReservation(int reservationId)
        {
            string checkReservationQuery = @"SELECT COUNT(1) FROM reservations WHERE reservation_id = @reservation_id";
            string updateAssetStatusQuery = @"UPDATE assets SET asset_status = 'in use'
                                            WHERE asset_id = (SELECT asset_id FROM reservations WHERE reservation_id = @reservation_id)";
            string deleteReservationQuery = @"DELETE FROM reservations WHERE reservation_id = @reservation_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    SqlCommand checkReservationCommand = new SqlCommand(checkReservationQuery, connection);
                    checkReservationCommand.Parameters.AddWithValue("@reservation_id", reservationId);
                    int reservationCount = (int)checkReservationCommand.ExecuteScalar();

                    
                    if (reservationCount == 0)
                    {
                        Console.WriteLine("Reservation not found.");
                        return false;
                    }

                   
                    SqlCommand updateAssetStatusCommand = new SqlCommand(updateAssetStatusQuery, connection);
                    updateAssetStatusCommand.Parameters.AddWithValue("@reservation_id", reservationId);
                    updateAssetStatusCommand.ExecuteNonQuery();

                    
                    SqlCommand deleteReservationCommand = new SqlCommand(deleteReservationQuery, connection);
                    deleteReservationCommand.Parameters.AddWithValue("@reservation_id", reservationId);
                    deleteReservationCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error withdrawing reservation: {ex.Message}");
                return false;
            }
        }
    }
}
