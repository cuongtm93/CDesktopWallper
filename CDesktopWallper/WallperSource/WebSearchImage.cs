using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using GoogleJson;
using Ninject;
using System.Net;
using System.Text.RegularExpressions;
using CDesktopWallper.Frontend;

namespace CDesktopWallper
{
    class WebSearchImage : ISearch
    {
        private readonly ISetting _setting;
        private readonly ITag _tag;
        private readonly IDownloader _downloader;
        private readonly IWsServer wsServer;
        public WebSearchImage()
        {
            this._setting = Kernel.Resolve<ISetting>();
            this._tag = Kernel.Resolve<ITag>();
            this._downloader = Kernel.Resolve<IDownloader>();
            this.wsServer = Kernel.Resolve<IWsServer>();
        }


        public List<WallperDescription> Search<T>(T keyword)
        {
            switch (keyword)
            {
                case string url:
                    
                    this.wsServer.SendToPath("/InternetWallperWebViewWS", $"Downloading from {url}");
                    return GetImageUrls(url).Select(_url => new WallperDescription()
                    {
                        Url = _url,
                        ThumbUrl = _url,
                    }).ToList();
                default:
                    return SearchBySubscriptions();
            }
        }

        /// <summary>
        ///  Tìm kiếm ảnh theo danh sách url mà người dùng đã subscribe, trong setting
        /// </summary>
        /// <returns></returns>
        public List<WallperDescription> SearchBySubscriptions()
        {
            var Result = new List<WallperDescription>();
            foreach (var url in this._setting.Data.UrlSubscriptions)
            {
                var ListImageUrlFromUrl = GetImageUrls(url);
                var ListWallpersFromUrl = ListImageUrlFromUrl.Select(imageUrl => new WallperDescription()
                {
                    Url = imageUrl,
                    Size = new Size()
                    {
                        Width = 0,
                        Height = 0
                    },
                    Tags = this._tag.Reveal(imageUrl)
                });

                Result.AddRange(ListWallpersFromUrl);
            }
            return Result;
        }

        /// <summary>
        ///  Lấy danh sách url ảnh trên một source html từ một url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private IEnumerable<string> GetImageUrls(string url)
        {
            try
            {
                var doc = new HtmlDocument();
                var html = string.Empty;
                html = this._downloader.DownloadString(url);
                var baseUri = new Uri(url);
                var pattern = @"(?<name>src|href)=""(?<value>/[^""]*)""";
                var matchEvaluator = new MatchEvaluator(
                    match =>
                    {
                        var value = match.Groups["value"].Value;
                        if (Uri.TryCreate(baseUri, value, out Uri uri))
                        {
                            var name = match.Groups["name"].Value;
                            return string.Format("{0}=\"{1}\"", name, uri.AbsoluteUri);
                        }
                        return null;
                    });
                var adjustedHtml = Regex.Replace(html, pattern, matchEvaluator);

                doc.LoadHtml(adjustedHtml);
                var imageNodes = doc.DocumentNode.SelectNodes("//img");
                //TODO
                var allValidTags = imageNodes.Where(r => r.Attributes["src"] != null || r.Attributes["srcset"] != null);
                var urls = new List<string>();
                foreach (var tag in allValidTags)
                {
                    //if (tag.Attributes["srcset"] != null)
                    //{
                    //    urls.Add(tag.Attributes["srcset"].Value);
                    //    continue;
                    //}

                    if (tag.Attributes["src"] != null)
                    {
                        urls.Add(tag.Attributes["src"].Value);
                        continue;
                    }
                }

                return urls;
            }
            catch
            {
                return new List<string>();
            }
            
        }
    }
}
