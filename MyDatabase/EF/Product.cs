namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public long id { get; set; }

        [StringLength(250)]
        public string name { get; set; }

        [StringLength(20)]
        public string code { get; set; }

        [StringLength(250)]
        public string metaTitle { get; set; }

        [StringLength(250)]
        public string descriptions { get; set; }

        [StringLength(500)]
        public string imageLocation { get; set; }

        [Column(TypeName = "xml")]
        public string moreImages { get; set; }

        public double? price { get; set; }

        public double? discountPrice { get; set; }

        public int? includeVAT { get; set; }

        public int? quantity { get; set; }

        public int categoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public int? guarantee { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(100)]
        public string modifyBy { get; set; }

        [StringLength(250)]
        public string metaKeyword { get; set; }

        public bool status { get; set; }

        public DateTime? topHot { get; set; }

        public int? viewCount { get; set; }
    }
}
