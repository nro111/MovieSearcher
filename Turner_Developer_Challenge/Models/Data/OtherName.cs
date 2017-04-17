namespace Turner_Developer_Challenge.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherName")]
    public partial class OtherName
    {
        public int? TitleId { get; set; }

        [StringLength(100)]
        public string TitleNameLanguage { get; set; }

        [StringLength(100)]
        public string TitleNameType { get; set; }

        [StringLength(100)]
        public string TitleNameSortable { get; set; }

        [StringLength(100)]
        public string TitleName { get; set; }

        public int Id { get; set; }

        public virtual Title Title { get; set; }
    }
}
