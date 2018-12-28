namespace ZHD_vokzal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reis
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reis()
        {
            Bilet = new HashSet<Bilet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumberReis { get; set; }

        public int? NumberMarshruta { get; set; }

        public int? NumberTrain { get; set; }

        public int? Rasstoyanie { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOtpravleniya { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatePribitiya { get; set; }

        public TimeSpan? TimeOtpravleniya { get; set; }

        public TimeSpan? TimePribitiya { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bilet> Bilet { get; set; }

        public virtual Marshrut Marshrut { get; set; }
    }
}
