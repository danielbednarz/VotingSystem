using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Domain
{
    public class Voter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }
    }
}