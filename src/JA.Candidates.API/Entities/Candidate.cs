using System.Collections.Generic;

namespace JA.Candidates.API.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> SkillTags { get; set; } = new List<string>();

        public Candidate()
        {

        }

        public Candidate(int id, string name, string skillTags)
        {
            Id = id;
            Name = name;

            if (!string.IsNullOrEmpty(skillTags))
            {
                foreach(var skillTag in skillTags.Split(','))
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
