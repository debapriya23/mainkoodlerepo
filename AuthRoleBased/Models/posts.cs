using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOODLE.Models
{
    public class posts
    {
        public int post_id { get; set; }
        public string post_txt { get; set; }
        public DateTime post_date { get; set; }
        public int post_like { get; set; }
    }
}
