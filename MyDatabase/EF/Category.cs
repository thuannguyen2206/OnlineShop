namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int id { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_Name", ResourceType = typeof(StaticResources.Resource))]
        [Required(ErrorMessageResourceName = "Category_RequiredName", ErrorMessageResourceType = typeof(StaticResources.Resource))]
        public string name { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_Metatitle", ResourceType = typeof(StaticResources.Resource))]
        public string metaTitle { get; set; }

        [Display(Name = "Category_ParentID", ResourceType = typeof(StaticResources.Resource))]
        public int? parentID { get; set; }

        [Display(Name = "Category_DisplayOrder", ResourceType = typeof(StaticResources.Resource))]
        public int? displayOrder { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_SeoTitile", ResourceType = typeof(StaticResources.Resource))]
        public string seoTitle { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(100)]
        public string modifyBy { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_MetaKeyword", ResourceType = typeof(StaticResources.Resource))]
        public string metaKeyword { get; set; }

        [StringLength(300)]
        [Display(Name = "Category_MetaDecription", ResourceType = typeof(StaticResources.Resource))]
        public string metaDecription { get; set; }

        [Display(Name = "Category_Status", ResourceType = typeof(StaticResources.Resource))]
        public bool status { get; set; }

        [Display(Name = "Category_ShowOnHome", ResourceType = typeof(StaticResources.Resource))]
        public int? showOnHome { get; set; }

        [StringLength(2)]
        public string languages { get; set; }
    }
}
