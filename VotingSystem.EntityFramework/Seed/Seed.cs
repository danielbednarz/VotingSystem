using VotingSystem.Domain;

namespace VotingSystem.EntityFramework.Seed
{
    public class Seed
    {
        public static void AddExampleData(MainDatabaseContext context)
        {
            AddVoters(context);
            AddCandidates(context);
        }

        private static void AddVoters(MainDatabaseContext context)
        {
            if (context.Voters.Any())
            {
                return;
            }

            List<Voter> voters = new()
            {
                new Voter
                {
                    Name = "Peppa"
                },
                new Voter
                {
                    Name = "Rumcajs"
                }
            };

            context.Voters.AddRange(voters);
            context.SaveChanges();
        }

        private static void AddCandidates(MainDatabaseContext context)
        {
            if (context.Candidates.Any())
            {
                return;
            }

            List<Candidate> candidates = new()
            {
                new Candidate
                {
                    Name = "Johnny Bravo"
                },
                new Candidate
                {
                    Name = "Pluto"
                }
            };

            context.Candidates.AddRange(candidates);
            context.SaveChanges();
        }

    }
}
