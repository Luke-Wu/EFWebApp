using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Contract : Base
    {
        #region Properties
        public int ContractId { get; set; }

        public string ContractName { get; set; }

        private DateTime? _contractSignedOn { get; set; }

        public DateTime? ContractSignedOn
        {
            get => _contractSignedOn.HasValue ? DateTime.SpecifyKind(_contractSignedOn.Value, DateTimeKind.Utc) : (DateTime?)null;
            set => _contractSignedOn = value;
        }

        private DateTime _contractStartsOn;
        public DateTime ContractStartsOn
        {
            get { return DateTime.SpecifyKind(_contractStartsOn, DateTimeKind.Utc); }
            set { _contractStartsOn = value; }
        }

        private DateTime? _contractEndsOn;
        public DateTime? ContractEndsOn
        {
            get
            {
                return _contractEndsOn.HasValue
                    ? DateTime.SpecifyKind(_contractEndsOn.Value, DateTimeKind.Utc)
                    : (DateTime?)null;
            }
            set { _contractEndsOn = value; }
        }

        public int MaxSessions { get; set; }

        public bool IsTaxRegistered { get; set; }

        public decimal TaxRate { get; set; }

        #endregion

        #region Foreign Key Properties
        public int AccountId { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public int CreatedPersonId { get; set; }


        #endregion

        #region Navigation Properties
        public virtual Account Account { get; set; }

        public virtual Person Doctor { get; set; }

        public virtual Person Patient { get; set; }

        public virtual Person CreatedPerson { get; set; }
        #endregion
    }
}
