using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }
        public string URL { get; set; }
        public int UserInterestID { get; set; } //FK
        [JsonIgnore]
        public UserInterest UserInterest { get; set; }
    }
}
