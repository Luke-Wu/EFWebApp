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
    public class Account : Base
    {
        #region Properties
        [Key]
        public int AccountId { get; set; }

        [Column(TypeName = "Money")]
        public decimal AccountBalance { get; set; }

        [Column(TypeName = "Money")]
        public decimal PendingBalance { get; set; }

        [Column(TypeName = "Money")]
        public decimal LifetimeEarnings { get; set; }



        [MaxLength(Lengths.cLength255)]
        public string Description { get; set; }

        private DateTime? _lastPaidOn;
        public DateTime? LastPaidOn
        {
            get
            {
                return _lastPaidOn.HasValue ? DateTime.SpecifyKind(_lastPaidOn.Value, DateTimeKind.Utc) : (DateTime?)null;
            }
            set { _lastPaidOn = value; }
        }


        public bool IsArchived { get; set; }

        #region FK Properties
        public int PersonId { get; set; }

        public int AccountTypeId { get; set; }


        #endregion

        #endregion

        #region Navigation Properties
        public virtual Person Person { get; set; }
        public virtual AccountType AccountType { get; set; }

        public virtual BankAccount CurrentBankAccount { get; set; }

        public virtual CreditCard CurrentCreditCard { get; set; }

        private ICollection<BankAccount> _bankAccounts { get; set; }

        public virtual ICollection<BankAccount> BankAccounts
        {
            get => _bankAccounts ?? (_bankAccounts = new HashSet<BankAccount>());
            set => _bankAccounts = value;
        }

        private ICollection<CreditCard> _creditCards { get; set; }

        public virtual ICollection<CreditCard> CreditCards
        {
            get => _creditCards ?? (_creditCards = new HashSet<CreditCard>());
            set => _creditCards = value;
        }





        #endregion



    }
}
