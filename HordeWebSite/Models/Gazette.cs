using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models
{
    public class Gazette
    {
        [Key]
        public int Id { get; set; }
        public string date { get; set; }
        public int page { get; set; }
        public byte[] image { get; set; }
    }
}
