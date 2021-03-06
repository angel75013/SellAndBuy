﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            this.Adds = new HashSet<Add>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {          
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);          
            userIdentity.AddClaim(new Claim("Phone", this.PhoneNumber.ToString()));
            return userIdentity;
        }         

        public string Name { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Add> Adds { get; set; }
    }
}
