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
    public class Person : Base
    {
        #region Properties
        public int PersonId { get; set; }

        public int? UserId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string FirstName { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string LastName { get; set; }

        [MaxLength(Lengths.cLength255)]
        public string Location { get; set; }

        [MaxLength(Lengths.cLength255)]
        public string Description { get; set; }

        public int? OrganisatioId { get; set; }

        [MaxLength(Lengths.cLength150)]
        public string Email { get; set; }

        private DateTime? _birthDate;

        public DateTime? BirthDate
        {
            get { return _birthDate.HasValue ? DateTime.SpecifyKind(_birthDate.Value, DateTimeKind.Utc) : (DateTime?)null; }
            set { _birthDate = value; }
        }

        public bool IsTaxRegistered { get; set; }

        [Column("Gender")]
        public string GenderString { get; set; }

        public string GenderDescription { get; set; }

        public Gender Gender
        {
            get { return (Gender)Enum.Parse(typeof(Gender), GenderString); }
            set { var gender = value; }
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool EmailAddressVerified { get; set; }

        public string PhoneNumber { get; set; }

        [MaxLength(Lengths.cLength5)]
        public string PhoneNumberVerificationCode { get; set; }

        public bool PhoneNumberVerified { get; set; }

        [Column(TypeName = "Money")]
        public decimal? Rate { get; set; }

        private DateTime? _lastLoginOn;

        public DateTime? LastLoginOn
        {
            get { return _lastLoginOn.HasValue ? DateTime.SpecifyKind(_lastLoginOn.Value, DateTimeKind.Utc) : (DateTime?)null; }
            set { _lastLoginOn = value; }
        }

        public string ConfirmEmailToken { get; set; }

        public string ResetPasswordToken { get; set; }
        #endregion

        #region  Foreign Key Properties
        public int PersonTypeId { get; set; }

        public int? AgeGroupId { get; set; }

        public int? HospitalId { get; set; }

        public int? EducationId { get; set; }

        public int? TimeZoneId { get; set; }

        #endregion

        #region Navigation Properties
        public virtual PersonType PersonType { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        public virtual Hospital Hospital { get; set; }

        public virtual Education Education { get; set; }

        public virtual TimeZone TimeZone { get; set; }





        #endregion
    }
}
