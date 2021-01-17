using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class TransactionType : Base
    {
        #region Properties  
        [Key]
        public int TransactionTypeId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string TransactionTypeName { get; set; }
        #endregion
    }
}
