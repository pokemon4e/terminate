using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MilenaSapunova.TerminateContracts.Model.Contracts;
using System.Collections.Generic;

namespace MilenaSapunova.TerminateContracts.Model
{
    public class User : IdentityUser, IDeletable, IAuditable
    {
        public User()
        {
            this.Contracts = new List<Contract>();
        }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public virtual ICollection<TerminationNotice> TerminationNotices { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
