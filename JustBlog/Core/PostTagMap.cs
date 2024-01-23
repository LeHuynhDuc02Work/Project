using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PostTagMap
    {
        public int Post_id { get; set; }
        public int Tag_id { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
        

    }
}
