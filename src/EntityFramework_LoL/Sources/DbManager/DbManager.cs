using Model;
using MyFlib;

namespace DbManager
{
    public partial class DbManager : IDataManager
    {
        protected LolDbContext DbContext { get; set; }

        public DbManager(LolDbContext dbContext)
        {
            DbContext = dbContext;
            ChampionsMgr = new ChampionsManager(this);
            SkinsMgr = new SkinsManager(this);
            RunesMgr = new RunesManager(this);
            RunePagesMgr = new RunePagesManager(this);
        }

        public IChampionsManager ChampionsMgr { get; set; }

        public ISkinsManager SkinsMgr { get; set; }

        public IRunesManager RunesMgr { get; set; }

        public IRunePagesManager RunePagesMgr { get; set; }
    }
}
