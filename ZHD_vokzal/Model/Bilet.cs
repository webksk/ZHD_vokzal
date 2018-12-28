namespace ZHD_vokzal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bilet")]
    public partial class Bilet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDbileta { get; set; }

        [StringLength(50)]
        public string FIOpassagira { get; set; }

        public string Passport { get; set; }

        public int? Stoimost { get; set; }

        public int? Skidka { get; set; }

        public int? NumberReis { get; set; }

        public int? NumberVagon { get; set; }

        public int? NumberMesto { get; set; }

        [StringLength(50)]
        public string MestoType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOtpravleniya { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatePribitiya { get; set; }

        public TimeSpan? TimeOtpravleniya { get; set; }

        public TimeSpan? TimePribitiya { get; set; }

        [StringLength(50)]
        public string PunktOtpravleniya { get; set; }

        [StringLength(10)]
        public string PunktPribitiya { get; set; }

        public virtual Reis Reis { get; set; }
    }
}
