using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyDatabase.EF
{
    [Table("Roles")]
    public partial class Roles
    {
        [Key]
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
