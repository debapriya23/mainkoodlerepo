using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KOODLE.Models
{

    [Table("posts")]
    public class posts
    {
        [Key]
        public int post_id { get; set; }

        public string post_titel { get; set; } 
        public string post_txt { get; set; }
        public DateTime post_date { get; set; } = DateTime.Now;
        public int post_like { get; set; }



    }
}
