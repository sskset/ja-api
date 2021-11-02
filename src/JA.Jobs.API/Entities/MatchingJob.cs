using System;
using System.Collections.Generic;
using System.Linq;

namespace JA.Jobs.API.Entities
{

    public class MatchingJob : Job
    {
        public int Score => MatchingSkillTags?.Count() ?? 0;
        public IEnumerable<string> MatchingSkillTags { get; }

        public MatchingJob(Job job, IEnumerable<string> matchingSkillTags)
        {
            if(job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            Id = job.Id;
            Name = job.Name;
            Company = job.Company;
            SkillTags = job.SkillTags;
            MatchingSkillTags = matchingSkillTags;
        }
    }
}
