using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Thumbnail
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Foto
    {
        public string title { get; set; }
        public string type { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public Image image { get; set; }
        public string page { get; set; }
        public string proxyImage { get; set; }
    }
}
