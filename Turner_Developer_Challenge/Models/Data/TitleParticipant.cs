namespace Turner_Developer_Challenge.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TitleParticipant")]
    public partial class TitleParticipant
    {
        public int Id { get; set; }

        public int TitleId { get; set; }

        public int ParticipantId { get; set; }

        public bool IsKey { get; set; }

        [StringLength(100)]
        public string RoleType { get; set; }

        public bool IsOnScreen { get; set; }

        public virtual Participant Participant { get; set; }

        public virtual Title Title { get; set; }
    }
}
