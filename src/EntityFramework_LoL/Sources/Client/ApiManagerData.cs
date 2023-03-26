using Model;

namespace ApiManager
{
    public partial class ApiManagerData : IDataManager
    {
        public ApiManagerData(HttpClient httpClient)
        {
            ChampionsMgr = new ChampionsManager(httpClient);
            SkinsMgr = new SkinsManager(httpClient);
            RunesMgr = new RunesManager(httpClient);
            RunePagesMgr = new RunePagesManager(httpClient);

        }

        public IChampionsManager ChampionsMgr { get; set; }

        public ISkinsManager SkinsMgr { get; set; }

        public IRunesManager RunesMgr { get; set; }

        public IRunePagesManager RunePagesMgr { get; set; }
    }
}
