using Logic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Testos.Repos;

namespace Testos.Models
{
    public class ApplicationUser : IdentityUser, IEntity<String>
    {
       
        public string FirstName { get; set; }
        public string EfterNamn { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string From { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ApplicationUser> Friends { get; set; }
        public Boolean searchable { get; set; }

        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }
    }
