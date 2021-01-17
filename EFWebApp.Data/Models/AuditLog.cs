using EFWebApp.Common.Constants;
using EFWebApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class AuditLog
    {
        #region Properties

        public int AuditLogId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Column("ActionType")]
        [MaxLength(Lengths.cLength10)]
        public string ActionTypeString
        {
            get { return ActionType.ToString(); }
            private set { ActionType = (DataBaseActionType)Enum.Parse(typeof(DataBaseActionType), ActionTypeString); }
        }

        [NotMapped]
        public DataBaseActionType ActionType { get; set; }

        [Required]
        [MaxLength(Lengths.cLength20)]
        public string TableName { get; set; }

        [Required]
        [MaxLength(Lengths.cLength100)]
        public string RecordId { get; set; }



        #endregion



        #region Navigation Properties
        private ICollection<AuditLogDetail> _auditLogDetails;

        public virtual ICollection<AuditLogDetail> AuditLogDetails
        {
            get => _auditLogDetails ?? (_auditLogDetails = new HashSet<AuditLogDetail>());
            set => _auditLogDetails = value;
        }
        #endregion
    }
}
