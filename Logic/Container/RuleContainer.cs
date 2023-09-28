using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Interfaces.RequestBody;

namespace Logic.Container
{
    public class RuleContainer
    {
        private readonly IDBContext _dbContext;

        public RuleContainer(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Rule>> GetRules()
        {
            return await _dbContext.Rules.ToListAsync();
        }

        public async Task<Rule> GetRule(int id)
        {
            return await _dbContext.Rules.FindAsync(id);
        }

        public async Task CreateRule(RuleBody body)
        {
            Rule rule = new Rule
            {
                RuleDescription = body.RuleDescription,
                CategoryId = body.CategoryId
            };

            await _dbContext.Rules.AddAsync(rule);
            await _dbContext.SaveChangesAsync();
        }
    }
}
