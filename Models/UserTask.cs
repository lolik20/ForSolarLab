using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Models
{
    public class UserTask
    {   
       
        public int id { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        
        public string text { get; set; }
    }
}
