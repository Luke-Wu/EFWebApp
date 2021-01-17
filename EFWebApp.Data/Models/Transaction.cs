using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Transaction : Base
    {
        #region Properties
        [Key]
        public int TransactionId { get; set; }
        #endregion

        #region FK Properties
        public int TransactionTypeId { get; set; }

        public int? BankTransactionId { get; set; }

        public int? SessionId { get; set; }


        public string InvoiceNumber { get; set; }

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

        #region Navigation Properties
        public virtual TransactionType TransactionType { get; set; }

        public virtual Session Session { get; set; }

      

        private ICollection<Invoice> _invoice;

        public virtual ICollection<Invoice> Invoices

        {
            get { return _invoice ?? (_invoice = new HashSet<Invoice>()); }
            set { _invoice = value; }
        }

     

        private ICollection<TransactionItem> _transactionItems;
        public virtual ICollection<TransactionItem> TransactionItems
        {
            get { return _transactionItems ?? (_transactionItems = new HashSet<TransactionItem>()); }
            set { _transactionItems = value; }
        }
        #endregion



    }
}
