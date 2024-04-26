using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<UserInterest> UserInterests { get; set; }
    }
}
