using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public ICollection<UserInterest> UserInterests { get; set; }
    }
}
