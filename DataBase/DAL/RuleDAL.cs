using DataBase.Data;
using DataBase.Models;
using Interfaces.DB.DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DAL
{
    public class RuleDAL: IRuleDAL
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public RuleDAL(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public async Task<List<RuleDTO>> GetRules()
        {
            List<Rule> dbrules = await dbcontext.Rules.ToListAsync();
            List<RuleDTO> rules = new List<RuleDTO>();
            foreach (Rule rule in dbrules)
            {
                rules.Add(new RuleDTO
                {
                    Id = rule.Id,
                    RuleDescription = rule.RuleDescription,
                    CategoryId = rule.CategoryId,
                });
            }
            return rules;
        }

        public async Task<RuleDTO> GetRule(int id)
        {
            Rule rule = await dbcontext.Rules.FindAsync(id);
            RuleDTO ruleDTO = new RuleDTO
            {
                Id = rule.Id,
                RuleDescription = rule.RuleDescription,
                CategoryId = rule.CategoryId,
            };
            return ruleDTO;
        }

        public async Task CreateRule(RuleDTO ruleDTO)
        {
            Rule rule = new Rule
            {
                RuleDescription = ruleDTO.RuleDescription,
                CategoryId = ruleDTO.CategoryId
            };
            dbcontext.Rules.Add(rule);
            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateRule(RuleDTO ruleDTO)
        {
            Rule rule = await dbcontext.Rules.FindAsync(ruleDTO.Id);

            rule.RuleDescription = ruleDTO.RuleDescription;
            rule.CategoryId = ruleDTO.CategoryId;

            dbcontext.Rules.Update(rule);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteRule(int id)
        {
            Rule rule = await dbcontext.Rules.FindAsync(id);
            dbcontext.Rules.Remove(rule);
            await dbcontext.SaveChangesAsync();
        }
    }
}
