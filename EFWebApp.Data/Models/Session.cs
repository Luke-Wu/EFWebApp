using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Session : Base
    {
        #region Properties
        [Key]
        public int SessionId { get; set; }

        [MaxLength(Lengths.cLength255)]
        public string Description { get; set; }

        private DateTime _scheduledStartsOn;
        public DateTime ScheduledStartsOn
        {
            get { return DateTime.SpecifyKind(_scheduledStartsOn, DateTimeKind.Utc); }
            set { _scheduledStartsOn = value; }
        }

        private DateTime _scheduledEndsOn;
        public DateTime ScheduledEndsOn
        {
            get { return DateTime.SpecifyKind(_scheduledEndsOn, DateTimeKind.Utc); }
            set { _scheduledEndsOn = value; }
        }

        private DateTime _actualStartsOn;
        public DateTime ActualStartsOn
        {
            get { return DateTime.SpecifyKind(_actualStartsOn, DateTimeKind.Utc); }
            set { _actualStartsOn = value; }
        }

        private DateTime _actualEndsOn;
        public DateTime ActualEndsOn
        {
            get { return DateTime.SpecifyKind(_actualEndsOn, DateTimeKind.Utc); }
            set { _actualEndsOn = value; }
        }



        #endregion

        #region Foreign Key Properties
        public int ContractId { get; set; }

        public int? CreatedPersonId { get; set; }

        #endregion

        #region Navigation Properties
        public virtual Person CreatedPerson { get; set; }

        public virtual Contract Contract { get; set; }

      

    

       

        private ICollection<SessionStatus> _sessionStatuses;
        public virtual ICollection<SessionStatus> SessionStatuses
       {
            get { return _sessionStatuses ?? (_sessionStatuses = new HashSet<SessionStatus>()); }
            set { _sessionStatuses = value; }
        }

        private ICollection<Transaction> _transactions;
        public virtual ICollection<Transaction> Transactions
        {
            get { return _transactions ?? (_transactions = new HashSet<Transaction>()); }
            set { _transactions = value; }
        }

      

        #endregion

    }
}
