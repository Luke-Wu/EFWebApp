using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class PersonType : Base
    {
        [Key]
        public int PersonTypeId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string PersonTypeName { get; set; }

        #region Navigation Properties
        private ICollection<Person> _people;
        public virtual ICollection<Person> People
        {
            get { return _people ?? (_people = new HashSet<Person>()); }
            set { _people = value; }
        }
        #endregion

    }
}
