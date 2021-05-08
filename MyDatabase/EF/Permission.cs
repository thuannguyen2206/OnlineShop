using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyDatabase.EF
{
    [Table("Permission")]
    [Serializable]
    public partial class Permission
    {
        [Key]
        [StringLength(20)]
        public string userGroupID { get; set; }
 
        [StringLength(50)]
        public string roleID { get; set; }
    }
}
