using Interfaces.DB;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
