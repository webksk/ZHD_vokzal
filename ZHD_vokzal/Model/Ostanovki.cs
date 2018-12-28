namespace ZHD_vokzal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ostanovki")]
    public partial class Ostanovki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ostanovki()
        {
            Marshrut = new HashSet<Marshrut>();
        }

        [Key]
        [StringLength(50)]
        public string NazvOstanovki { get; set; }

        public int? NumberOstanovki { get; set; }

        public TimeSpan? TimeStoyanki { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataPosadki { get; set; }

        public TimeSpan? TimePosadki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marshrut> Marshrut { get; set; }
    }
}
