﻿using System.Collections.Generic;

namespace JA.Candidates.API.Services
{
    public interface ISkillTagMatchService
    {
        IEnumerable<string> Match(IEnumerable<string> skillTags1, IEnumerable<string> skillTags2);
    }
}
