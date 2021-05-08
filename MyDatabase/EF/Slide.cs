namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int id { get; set; }

        [StringLength(500)]
        public string imageLocation { get; set; }

        public int? displayOrder { get; set; }

        [StringLength(250)]
        public string link { get; set; }

        [StringLength(250)]
        public string descriptions { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(100)]
        public string modifyBy { get; set; }

        public bool status { get; set; }
    }
}
