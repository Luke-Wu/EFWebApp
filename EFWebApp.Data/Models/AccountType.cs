using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Models
{
    public class AccountType : Base
    {
        public int AccountTypeId { get; set; }

        public string AccountTypeName { get; set; }

        public string Description { get; set; }

        public bool IsArchived { get; set; }





        #region Navigation Properties

        private ICollection<Account> _accounts;

        public virtual ICollection<Account> Accounts
        {
            get => _accounts ?? (_accounts = new HashSet<Account>());
            set => _accounts = value;
        }

        #endregion



    }
}
