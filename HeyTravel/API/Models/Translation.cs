using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Translation
    {
        public string translatedText { get; set; }
    }

    public class Data
    {
        public List<Translation> translations { get; set; }
    }

    public class RootTranslation
    {
        public Data data { get; set; }
    }
}
