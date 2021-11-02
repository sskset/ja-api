using System;
using System.Collections.Generic;
using System.Linq;

namespace JA.Candidates.API.Entities
{
    public class MatchingCandidate : Candidate
    {
        public int Scores => MatchingSkillTags?.Count() ?? 0;
        public IEnumerable<string> MatchingSkillTags { get; }

        public MatchingCandidate(Candidate candidate, IEnumerable<string> matchingSkillTags)
        {
            if(candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }

            this.Id = candidate.Id;
            this.Name = candidate.Name;
            this.SkillTags = candidate.SkillTags;
            this.MatchingSkillTags = matchingSkillTags;
        }
    }
}
