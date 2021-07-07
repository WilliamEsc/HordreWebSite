using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models.ViewModel
{
    public class viewGazette
    {
        public int page { get; set; }

        public int maxPage { get; set; }

        public string date { get; set; }

        public byte[] image { get; set; }
    }
}
