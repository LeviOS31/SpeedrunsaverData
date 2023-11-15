using Interfaces.DB.DAL;
using Interfaces.DTO;

namespace Test.Mock
{
    public class RuleMock: IRuleDAL
    {
        List<RuleDTO> rules = new List<RuleDTO>
        {
            new RuleDTO { Id = 1, RuleDescription = "Rule 1", CategoryId = 1 },
            new RuleDTO { Id = 2, RuleDescription = "Rule 2", CategoryId = 1 },
            new RuleDTO { Id = 3, RuleDescription = "Rule 3", CategoryId = 2 },
        };

        public async Task<List<RuleDTO>> GetRules()
        {
            return rules;
        }

        public async Task<RuleDTO> GetRule(int id)
        {
            return rules.FirstOrDefault(r => r.Id == id);
        }

        public async Task CreateRule(RuleDTO ruleDTO)
        {
            ruleDTO.Id = rules.Count + 1;
            rules.Add(ruleDTO);
        }

        public async Task UpdateRule(RuleDTO ruleDTO)
        {
            rules.Remove(rules.Find(x => x.Id == ruleDTO.Id));
            rules.Add(ruleDTO);
        }

        public async Task DeleteRule(int id)
        {
            rules.Remove(rules.Find(x => x.Id == id));
        }
    }
}
