using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public partial class Track
    {
        public Track()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            Playlists = new HashSet<Playlist>();
        }

        [Display(Name = "Track ID")]
        public long TrackId { get; set; }
        [Display(Name = "Track")]
        public string Name { get; set; } = null!;
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        public string? Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual MediaType MediaType { get; set; } = null!;
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
