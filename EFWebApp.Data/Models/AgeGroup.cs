using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class AgeGroup : Base
    {
        [Key]
        public int AgeGroupId { get; set; }

        [MaxLength(Lengths.cLength15)]
        public string AgeGroupName { get; set; }

        #region Navigation Properties
        private ICollection<Person> _people;

        public virtual ICollection<Person> People
        {
            get => _people ?? (_people = new HashSet<Person>());
            set => _people = value;

        }

        #endregion


    }
}
