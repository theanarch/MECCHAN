using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MECCHAN.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Color { get; set; }
                

    }
}
