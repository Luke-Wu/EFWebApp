using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class BankAccount : Base
    {
        #region 
        [Key]
        public int BankAccountId { get; set; }

        [MaxLength(Lengths.cLength50)]
        public string BankAccountName { get; set; }

        [MinLength(Lengths.cLength2)]
        [MaxLength(Lengths.cLength2)]
        public string Bank { get; set; }

        [MinLength(Lengths.cLength4)]
        [MaxLength(Lengths.cLength4)]
        public string Branch { get; set; }

        [MinLength(Lengths.cLength8)]
        [MaxLength(Lengths.cLength8)]
        public string AccountNumber { get; set; }

        [MinLength(Lengths.cLength4)]
        [MaxLength(Lengths.cLength4)]
        public string Suffix { get; set; }

        public bool IsArchived { get; set; }



        #endregion

        #region Foreign Key Properties
        public int AccountId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Account Account { get; set; }
        #endregion

    }
}
