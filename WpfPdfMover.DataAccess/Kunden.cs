namespace WpfPdfMover.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kunden")]
    public partial class Kunden
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(30)]
        public string Kundennummer { get; set; }

        [StringLength(40)]
        public string Kundenname { get; set; }

        [StringLength(10)]
        public string Postleitzahl { get; set; }

        [StringLength(20)]
        public string Ort { get; set; }

        [StringLength(10)]
        public string Land { get; set; }

        [StringLength(50)]
        public string Strasse { get; set; }
    }
}
