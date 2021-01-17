using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class AuditLogDetail
    {
        [Key]
        public int AuditLogDetailId { get; set; }

        [Required]
        [MaxLength(Lengths.cLength255)]
        public string ColumnName { get; set; }

        [MaxLength(Lengths.cLengthMax)]
        public string OriginalValue { get; set; }

        [MaxLength(Lengths.cLengthMax)]
        public string NewValue { get; set; }


        #region Foreign Key Property
        public int AuditLogId { get; set; }
        #endregion


        #region Navigation Property
        public virtual AuditLog AuditLog { get; set; }
        #endregion




    }
}
