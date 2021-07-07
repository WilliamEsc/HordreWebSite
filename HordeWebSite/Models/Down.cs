using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Models
{
    public class Down
    {
        [Key]
        public int Id { get; set; }
        public string imageName { get; set; }
        public string member1 { get; set; }
        public string job1 { get; set; }
        public string member2 { get; set; }
        public string job2 { get; set; }
        public string member3 { get; set; }
        public string job3 { get; set; }
        public string member4 { get; set; }
        public string job4 { get; set; }
        public string member5 { get; set; }
        public string job5 { get; set; }
        public string member6 { get; set; }
        public string job6 { get; set; }
        public string member7 { get; set; }
        public string job7 { get; set; }
        public string member8 { get; set; }
        public string job8 { get; set; }
    }
}
