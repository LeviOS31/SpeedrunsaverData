using Interfaces.DB.DAL;
using Interfaces.DTO;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class RuleContainer
    {
        private readonly IRuleDAL rulesDAL;

        public RuleContainer(IRuleDAL _rulesDAL)
        {
            rulesDAL = _rulesDAL;
        }

        public async Task<List<RuleDTO>> GetRules()
        {
            return await rulesDAL.GetRules();
        }

        public async Task<RuleDTO> GetRule(int id)
        {
            return await rulesDAL.GetRule(id);
        }

        public async Task CreateRule(RuleBody ruleBody)
        {
            RuleDTO ruleDTO = new RuleDTO
            {
                RuleDescription = ruleBody.RuleDescription,
                CategoryId = ruleBody.CategoryId
            };
            await rulesDAL.CreateRule(ruleDTO);
        }

        public async Task UpdateRule(int id, RuleBody ruleBody)
        {
            RuleDTO ruleDTO = new RuleDTO
            {
                Id = id,
                RuleDescription = ruleBody.RuleDescription,
                CategoryId = ruleBody.CategoryId
            };
            await rulesDAL.UpdateRule(ruleDTO);
        }

        public async Task DeleteRule(int id)
        {
            await rulesDAL.DeleteRule(id);
        }
    }
}
