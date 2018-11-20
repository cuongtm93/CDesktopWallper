using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleJson;
using Ninject;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;

namespace CDesktopWallper
{
    class GoogleSearchImage : ISearch
    {
        private const string apiKey = "AIzaSyDQRK7PLtRfZ8gHC5GvQ7MknGAfyrChvVE";
        private const string searchEngineId = "003470263288780838160:ty47piyybua";

        const string template = "https://www.googleapis.com/customsearch/v1?" +
            "q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}" +
            "&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}" +
            "&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}" +
            "&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}" +
            "&excludeTerms={excludeTerms?}&linkSite={linkSite?}" +
            "&orTerms={orTerms?}&relatedSite={relatedSite?}" +
            "&dateRestrict={dateRestrict?}&lowRange={lowRange?}" +
            "&highRange={highRange?}&searchType={searchType}&fileType={fileType?}" +
            "&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}" +
            "&imgColorType={imgColorType?}" +
            "&imgDominantColor={imgDominantColor?}&alt=json";

        private readonly ISearch _search;
        private readonly ISetting _setting;
        private readonly IDownloader _downloader;
        public GoogleSearchImage()
        {
            this._search = Kernel.Resolve<ISearch>(nameof(WebSearchImage));
            this._setting = Kernel.Resolve<ISetting>();
            this._downloader = Kernel.Resolve<IDownloader>();
        }


        public List<WallperDescription> Search<T>(T keyword)
        {
            switch (keyword)
            {
                case System.Drawing.Bitmap img_keyword:

                    return SearchByImage(img_keyword);

                case string s_keyword:

                    return SearchByTextV1(s_keyword);

                default:
                    throw new NotSupportedException("Không hỗ trợ tìm kiếm");
            }
        }

        private List<WallperDescription> SearchByTextV1(string keyword)
        {
            var customSearchUrl = "www.googleapis.com/customsearch/v1";
            var Response = this._downloader.DownloadString($"https://{customSearchUrl}?q={keyword}&cx={searchEngineId}&key={apiKey}");
            var CustomSearchError = GoogleJson.GoogleCustomSearchError.FromJson(Response);
            if (CustomSearchError.Error != null)
                throw new UnauthorizedAccessException();

            var rawResult = GoogleSearchResponse.FromJson(Response);
            var SearchResult = new ConcurrentBag<WallperDescription>();

            int maxConcurrency = 20;
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
            {
                var invalids = new ConcurrentBag<WallperDescription>();
                List<Task> tasks = new List<Task>();
                foreach (var item in rawResult.Items)
                {
                    concurrencySemaphore.Wait();

                    var t = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            var images = this._search.Search(item.Link);
                            images.ForEach(url => SearchResult.Add(url));
                        }
                        finally
                        {
                            concurrencySemaphore.Release();
                        }
                    });

                    tasks.Add(t);
                }
                Task.WaitAll(tasks.ToArray());
                return SearchResult.ToList();
            }
        }
        private List<WallperDescription> SearchByTextV2(string keyword)
        {
            var url = $"https://www.google.com.vn/search?q={keyword}&tbs=isz:l,itp:photo&tbm=isch&source=lnt&sa=X&ved=0ahUKEwjM576g8ZrdAhUGTI8KHe1LAc0QpwUIGg&biw=1093&bih=530&dpr=1.25#imgrc=_";
            return this._search.Search(url);
        }
        public List<WallperDescription> SearchByImage(System.Drawing.Bitmap keyword)
        {
            throw new NotImplementedException();
        }
    }
}
