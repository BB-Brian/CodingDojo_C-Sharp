

using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter
{
    public class Rest
    {
        public int id { get; set; }
        
        [MinLength(2)]
        public string name { get; set; }
        public string restaurant { get; set; }
        public string review { get; set; }
        public DateTime date { get; set; }
        public int star { get; set; }
    }
}

