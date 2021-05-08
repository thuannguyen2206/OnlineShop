namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductsCategory")]
    public partial class ProductsCategory
    {
        public int id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string metaTitle { get; set; }

        public int? parentID { get; set; }

        public int? displayOrder { get; set; }

        [StringLength(250)]
        public string seoTitle { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(100)]
        public string modifyBy { get; set; }

        [StringLength(250)]
        public string metaKeyword { get; set; }

        public bool status { get; set; }

        public int? showOnHome { get; set; }
    }
}
