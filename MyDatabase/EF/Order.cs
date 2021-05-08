namespace MyDatabase.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public long id { get; set; }

        public long? customerID { get; set; }

        public DateTime? createDate { get; set; }

        [StringLength(50)]
        public string shipName { get; set; }

        [StringLength(50)]
        public string shipMobile { get; set; }

        [StringLength(50)]
        public string shipAddress { get; set; }

        [StringLength(50)]
        public string shipEmail { get; set; }

        public int? status { get; set; }
    }
}
