using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Region : Base
    {
        [Key]
        public int RegionId { get; set; }

        [MaxLength(Lengths.cLength100)]
        public string RegionName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

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
