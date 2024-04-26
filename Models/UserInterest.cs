using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class UserInterest
    {
        [Key]
        public int UserInterestID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int InterestID { get; set; }
        public Interest Interest { get; set; }
        public List<Link> Links { get; set; }
    }
}
