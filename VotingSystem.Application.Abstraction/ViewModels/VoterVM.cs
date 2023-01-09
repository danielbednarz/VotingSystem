namespace VotingSystem.Application.Abstraction
{
    public class VoterVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
