using Interfaces.DB.DAL;

namespace Interfaces.DB
{
    public interface IDalFactory
    {
        public ICategoryDAL GetCategoryDAL();
        public ICommentDAL GetCommentDAL();
        public IGameDAL GetGameDAL();
        public IPlatformDAL GetPlatformDAL();
        public IRuleDAL GetRuleDAL();
        public ISpeedrunDAL GetSpeedrunDAL();
        public IUserDAL GetUserDAL();
        public IUserTokenDAL GetUserTokenDAL();
    }
}
