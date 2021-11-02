using JA.Jobs.API.Services;
using System;
using System.Collections.Generic;

namespace JA.Jobs.API.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public List<string> SkillTags { get; set; } = new List<string>();

        public Job()
        {

        }

        public Job(JobDto dto)
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            Id = dto.JobId;
            Name = dto.Name;
            Company = dto.Company;

            if (!string.IsNullOrEmpty(dto.Skills))
            {
                foreach (var skillTag in dto.Skills.Split(','))
                {
                    if (!string.IsNullOrEmpty(skillTag))
                    {
                        SkillTags.Add(skillTag.Trim().ToLower());
                    }
                }
            }
        }
    }
}
