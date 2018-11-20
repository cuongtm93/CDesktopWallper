using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    public class LocalWallperSource : IWallperSource
    {
        private readonly ITag _tag;

        public string[] imageDirectories = new string[]  {
            System.IO.Directory.GetCurrentDirectory() + "\\Frontend\\wallpers"
        };

        string[] extensions = { ".jpg", ".jpeg", ".png", ".gif" };

        public LocalWallperSource()
        {
            this._tag = Kernel.Resolve<ITag>();

        }
        public List<WallperDescription> GetWallpers(int page, int perPage)
        {
            var wallpers = new List<WallperDescription>();

            List<WallperDescription> PagingResult()
            {
                var result = new List<WallperDescription>();
                var index = -1;
                foreach (var wallper in wallpers)
                {
                    if (wallper.IsNotValid() == false)
                    {
                        index++;
                        if (index >= (page - 1) * perPage && index < page * perPage)
                            result.Add(wallper);
                    }
                }
                return result;
            }

            foreach (var dir in this.imageDirectories)
            {
                var images = new List<string>();
                foreach (string file in Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where(s => this.extensions.Any(ext => ext == Path.GetExtension(s))))
                {
                    images.Add(file);
                }

                wallpers = images.ConvertAll(filePath => new WallperDescription()
                {
                    LocalPath = filePath,
                    Tags = this._tag.Reveal(filePath)
                });
            }

            if (page <= 0 || perPage <= 0)
            {
                wallpers.RemoveAll(w => w.IsNotValid());
                return wallpers;
            }
            else
                return PagingResult();
        }
    }
}
