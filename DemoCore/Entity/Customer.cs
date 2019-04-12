using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCore.Entity
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CUSTOMERID")]
        public int CustomerId { get; set; }
        [Column("FIRSTNAME")]
        public string FirstName { get; set; }
        [Column("LASTNAME")]
        public string LastName { get; set; }
        [Column("ADDRESS")]
        [DefaultValue("北京")]
        public string Address { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }
}
