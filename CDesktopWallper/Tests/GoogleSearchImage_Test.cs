using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static System.Diagnostics.Debug;
using CDesktopWallper.Extensions;
namespace CDesktopWallper.Tests
{

    [TestFixture]
    public class GoogleSearchImage_Test
    {
        private ISearch _search;
        [SetUp]
        public void Setup()
        {
            this._search = Kernel.Resolve<GoogleSearchImage>();
        }

        [Test]
        public void Test1()
        {
            var L = this._search.Search("hình nền ngôi nhà");
            var invalids = L.GetInvalids();
            L.RemoveAll(w => invalids.Contains(w));
            foreach (var item in L)
            {
                Console.WriteLine(item.Url);
            }
        }

        [Test]
        public void Test2()
        {
            var L = this._search.Search("hình nền");
            foreach (var item in L)
            {
                Console.WriteLine(item.Url);
            }
        }

        [Test]
        public void Test3()
        {
            var L = this._search.Search("money");
            foreach (var item in L)
            {
                Console.WriteLine(item.Url);
            }
        }

    }
}
