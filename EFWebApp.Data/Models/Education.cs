using EFWebApp.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class Education : Base
    {
        [Key]
        public int EducationId { get; set; }

        [MaxLength(Lengths.cLength50)]
        public string EducationName { get; set; }

        private ICollection<Person> _people;

        public virtual ICollection<Person> People
        {
            get => _people ?? (_people = new HashSet<Person>());
            set => _people = value;
        }


    }
}
