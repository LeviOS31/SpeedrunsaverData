using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DB.DAL
{
    public interface IRuleDAL
    {
        public Task<List<RuleDTO>> GetRules();
        public Task<RuleDTO> GetRule(int id);
        public Task CreateRule(RuleDTO ruleDTO);
        public Task UpdateRule(RuleDTO ruleDTO);
        public Task DeleteRule(int id);
    }
}
