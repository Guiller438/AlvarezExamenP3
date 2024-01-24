using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvarezExamenProgreso3.AlvarezViewModels
{
    public class Breed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string life_span { get; set; }
        public string breed_group { get; set; }
    }

    public class Root
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string mime_type { get; set; }
        public List<Breed> breeds { get; set; }
        public List<object> categories { get; set; }
    }
}
