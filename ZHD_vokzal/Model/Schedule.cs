namespace ZHD_vokzal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    namespace ZHD_vokzal.Model
    {
        public partial class Schedule
        {
            public Reis ReisData { get; set; }

            public string Punkt_pribitiya { get; set; }

            public string Punkt_otpravleniya { get; set; }
        }
    }
}
