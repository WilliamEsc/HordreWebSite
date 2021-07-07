using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models.ViewModel
{
    public class GazetteForm
    {
            public string date { get; set; }
            public IFormFile[] image { get; set; }
    }
}
