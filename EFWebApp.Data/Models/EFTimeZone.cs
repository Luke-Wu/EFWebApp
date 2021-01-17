using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class EFTimeZone : Base
    {
        [Key]
        public int TimeZoneId { get; set; }

        [MaxLength(Lengths.cLength20)]
        public string Title { get; set; }

        [MaxLength(Lengths.cLengthMax)]
        public string Description { get; set; }

        private ICollection<Person> _people;

        public virtual ICollection<Person> People
        {
            get => _people ?? (_people = new HashSet<Person>());
            set => _people = value;
        }


    }
}
