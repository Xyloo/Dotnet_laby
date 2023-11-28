using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        [Display(Name = "Invoice Number")]
        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Billing Address")]
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        [Display(Name = "Ordered Tracks")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
