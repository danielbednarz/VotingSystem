using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingSystem.Domain
{
    public class Voting
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Voter")]
        public int VoterId { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
    }
}
