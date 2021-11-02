using JA.Jobs.API.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JA.Jobs.API.Services
{

    public class SimpleSkillTagMatchingService : ISkillTagMatchService
    {
        public IEnumerable<string> Match(IEnumerable<string> skillTags1, IEnumerable<string> skillTags2)
        {
            if (skillTags1.IsNullOrEmpty() || skillTags2.IsNullOrEmpty())
            {
                return null;
            }

            return skillTags1.Intersect(skillTags2, StringComparer.OrdinalIgnoreCase);
        }
    }
}
