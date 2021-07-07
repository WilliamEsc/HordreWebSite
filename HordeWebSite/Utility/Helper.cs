using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Utility
{
    public class Helper
    {
        public static string Admin = "Admin";
        public static string Chef = "Chef";
        public static string Redacteur = "Redacteur";
        public static string Membre = "Membre";
        public static string Invite = "Invité";

        public static List<SelectListItem> GetRolesForDropdown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
            {
                    new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                new SelectListItem{Value=Helper.Chef,Text=Helper.Chef},
                new SelectListItem{Value=Helper.Redacteur,Text=Helper.Redacteur},
                new SelectListItem{Value=Helper.Membre,Text=Helper.Membre},
                new SelectListItem{Value=Helper.Invite,Text=Helper.Invite}
            };
            }
            else
            {
                return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Chef,Text=Helper.Chef},
                new SelectListItem{Value=Helper.Redacteur,Text=Helper.Redacteur},
                new SelectListItem{Value=Helper.Membre,Text=Helper.Membre},
                new SelectListItem{Value=Helper.Invite,Text=Helper.Invite}
            };
            }
        }
    }
}
