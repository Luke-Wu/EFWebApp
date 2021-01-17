using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class SessionStatus : Base
    {
        #region Properties
        [Key]
        public int SessionStatusId { get; set; }

        [MaxLength(Lengths.cLengthMax)]
        public string Comment { get; set; }
        #endregion

        #region FK Properties
        public int SessionId { get; set; }

        public int SessionStatusTypeId { get; set; }

        public int? ModifiedByPersonId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual SessionStatusType SessionStatusType { get; set; }

        public virtual Session Session { get; set; }

        public virtual Person ModifiedByPerson { get; set; }
        #endregion


    }
}
