using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.EF
{
    [Table("UserGroup")]
    public partial class UserGroup
    {
        [Key]
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

    }
}
