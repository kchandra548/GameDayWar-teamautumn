public void DeleteOrder(int orderId)
{
    // SQL injection vulnerability
    string connectionString = "YourConnectionStringHere";
    string query = $"DELETE FROM Orders WHERE Id = @OrderId";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            // Use parameterized query to prevent SQL injection
            command.Parameters.AddWithValue("@OrderId", orderId);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Deleted {rowsAffected} rows.");
        }
    }
}
