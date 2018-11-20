using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CDesktopWallper.Tests
{
    
    [TestFixture]
    public class WebImageSearch_Test
    {
        private ISearch search;
        [SetUp]
        public void Setup()
        {
            this.search = Kernel.Resolve<WebSearchImage>();
        }

        [Test]
        public void Test1()
        {
           var L = this.search.Search("https://doisong.vnexpress.net/tin-tuc/to-am/chu-re-bi-nhan-tinh-boc-phot-chi-vai-gio-truoc-dam-cuoi-xa-hoa-3802057.html");
            foreach (var item in L)
            {
                Console.WriteLine(item.Url);
            }
        }
    }
}
