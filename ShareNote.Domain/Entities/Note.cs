using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareNote.Domain.Entities
{
    public class Note
    {
        public string Uuid { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

}
