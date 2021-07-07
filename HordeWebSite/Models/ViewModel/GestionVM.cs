using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models.ViewModel
{
    public class GestionVM
    {
        public string UserName { get; set; }
        public string newRole { get; set; }

        public List<ApplicationUser> listItem { get; set; }
    }
}
