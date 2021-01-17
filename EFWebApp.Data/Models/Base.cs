using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    /// <summary>
    /// The base class for all the models
    /// </summary>
    public abstract class Base
    {
        #region Properties
        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return DateTime.SpecifyKind(_createdOn, DateTimeKind.Utc); }
            set { _createdOn = value; }
        }

        private DateTime _modifiedOn;
        public DateTime ModifiedOn
        {
            get { return DateTime.SpecifyKind(_modifiedOn, DateTimeKind.Utc); }
            set { _modifiedOn = value; }
        }

        [Required]
        public bool IsDeleted { get; set; }
        #endregion

    }
}
