using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;

namespace VulnerableWebAPI.Controllers
{
    [RoutePrefix("api/insecure")]
    public class InsecureController : ApiController
    {
        // Hardcoded Database Connection String (Vulnerability #3)
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureDB"].ConnectionString;
        [HttpGet]
        [Route("getUserData")]
        public IHttpActionResult GetUserData(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Use parameterized query to prevent SQL injection
                    string query = "SELECT * FROM Users WHERE UserId = @UserId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return Ok(new
                        {
                            UserId = reader["UserId"],
                            Name = reader["Name"],
                            Email = reader["Email"]
                        });
                    }

                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error message
                // LogException(ex); // Implement a logging mechanism
                return InternalServerError(new Exception("An error occurred while processing your request."));
            }
        }

        // Secure endpoint to access files
        [HttpGet]
        [Route("getFile")]
        public IHttpActionResult GetFile(string fileName)
        {
            try
            {
                // Validate and sanitize the file name
                if (string.IsNullOrWhiteSpace(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    return BadRequest("Invalid file name.");
                }

                string secureDirectory = "C:\\SecureFiles\\";
                string filePath = Path.Combine(secureDirectory, fileName);

                // Ensure the file is within the secure directory
                if (!filePath.StartsWith(secureDirectory))
                {
                    return BadRequest("Invalid file path.");
                }

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    return Ok(new { FileName = fileName, Content = content });
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error message
                // LogException(ex); // Implement a logging mechanism
                return InternalServerError(new Exception("An error occurred while processing your request."));
            }
        }

        // Secure debug endpoint
        [HttpGet]
        [Route("debug")]
        public IHttpActionResult Debug()
        {
            // Avoid exposing sensitive information
            return Ok(new
            {
                Environment = "Debug"
                // Remove sensitive information
            });
        }
    }
}
