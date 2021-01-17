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
    public class TransactionItem : Base
    {
        #region Properties
        [Key]
        public int TransactionItemId { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [MaxLength(Lengths.cLength3)]
        public string CurrencyType { get; set; }

        [MaxLength(Lengths.cLength255)]
        public string Description { get; set; }
        #endregion

        #region FK Properties
        public int TransactionId { get; set; }

        public int AccountId { get; set; }

      
        #endregion

        #region Navigation Properties
        public virtual Transaction Transaction { get; set; }

        public virtual Account Account { get; set; }

      
        #endregion



    }
}
