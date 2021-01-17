using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class SessionStatusType : Base
    {
        #region Properties  
        [Key]
        public int SessionStatusTypeId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string SessionStatusTypeName { get; set; }
        #endregion

        #region Navigation Properties
        private ICollection<SessionStatus> _sessionStatuses;
        public virtual ICollection<SessionStatus> SessionStatuses
        {
            get { return _sessionStatuses ?? (_sessionStatuses = new HashSet<SessionStatus>()); }
            set { _sessionStatuses = value; }
        }
        #endregion


    }
}
