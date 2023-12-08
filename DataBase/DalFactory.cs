using DataBase.Data;
using DataBase.DAL;
using Interfaces.DB;
using Interfaces.DB.DAL;

namespace DataBase
{
    public class DalFactory: IDalFactory
    {
        private readonly DBSpeedrunsaverContext dbcontext;
        public DalFactory(DBSpeedrunsaverContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public ICategoryDAL GetCategoryDAL()
        {
            return new CategoryDAL(dbcontext);
        }
        public ICommentDAL GetCommentDAL()
        {
            return new CommentDAL(dbcontext);
        }
        public IGameDAL GetGameDAL()
        {
            return new GameDAL(dbcontext);
        }
        public IPlatformDAL GetPlatformDAL()
        {
            return new PlaformDAL(dbcontext);
        }
        public IRuleDAL GetRuleDAL()
        {
            return new RuleDAL(dbcontext);
        }
        public ISpeedrunDAL GetSpeedrunDAL()
        {
            return new SpeedrunDAL(dbcontext);
        }
        public IUserDAL GetUserDAL()
        {
            return new UserDAL(dbcontext);
        }
        public IUserTokenDAL GetUserTokenDAL()
        {
            return new UserTokenDAL(dbcontext);
        }
    }
}
