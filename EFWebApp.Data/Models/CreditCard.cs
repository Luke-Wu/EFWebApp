using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class CreditCard : Base
    {
        #region Properties
        [Key]
        public int CreditCardId { get; set; }

        [MaxLength(Lengths.cLength16)]
        public string CardNumber { get; set; }

        [MaxLength(Lengths.cLength16)]
        public string CardName { get; set; }

        [MaxLength(Lengths.cLength5)]
        public string CardExpiresOn { get; set; }

        [MaxLength(Lengths.cLength64)]
        public string CardHolderName { get; set; }

        [MaxLength(Lengths.cLength16)]
        public string CardRecurringToken { get; set; }

        [MaxLength(Lengths.cLength2)]
        public string ResponseCode { get; set; }

        public bool IsArchived { get; set; }
        #endregion

        #region FK Properties
        public int AccountId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Account Account { get; set; }
        #endregion

    }
}
