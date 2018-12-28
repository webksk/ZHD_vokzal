namespace ZHD_vokzal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Train")]
    public partial class Train
    {
        public int NumberTrain { get; set; }

        public int? IDVagon { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public virtual Vagon Vagon { get; set; }
    }
}
