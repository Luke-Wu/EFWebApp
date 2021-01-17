using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Invoice : Base
    {
        #region Properties
        [Key]
        public int InvoiceId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

       

        [Column(TypeName = "Money")]
        public decimal TaxAmount { get; set; }

        private DateTime? _periodStartsOn;
        public DateTime? PeriodStartsOn
        {
            get
            {
                return _periodStartsOn.HasValue
                    ? DateTime.SpecifyKind(_periodStartsOn.Value, DateTimeKind.Utc)
                    : (DateTime?)null;
            }
            set { _periodStartsOn = value; }
        }

        private DateTime? _periodEndsOn;
        public DateTime? PeriodEndsOn
        {
            get
            {
                return _periodEndsOn.HasValue
                    ? DateTime.SpecifyKind(_periodEndsOn.Value, DateTimeKind.Utc)
                    : (DateTime?)null;
            }
            set { _periodEndsOn = value; }
        }

        #endregion

        #region FK Properties
        public int AccountId { get; set; }

        #endregion

        #region Navigation Properties


        public virtual Account Account { get; set; }

        private ICollection<Transaction> _transactions;
        public virtual ICollection<Transaction> Transactions
        {
            get { return _transactions ?? (_transactions = new HashSet<Transaction>()); }
            set { _transactions = value; }
        }

        #endregion


    }
}
