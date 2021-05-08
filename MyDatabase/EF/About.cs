namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string metaTitle { get; set; }

        [StringLength(250)]
        public string descriptions { get; set; }

        [StringLength(500)]
        public string imageLocation { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(100)]
        public string modifyBy { get; set; }

        [StringLength(250)]
        public string metaKeyword { get; set; }

        public int? status { get; set; }
    }
}
