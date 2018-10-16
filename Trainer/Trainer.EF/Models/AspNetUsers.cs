﻿using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            Articles = new HashSet<Articles>();
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ProfilePicture { get; set; }
        public string UserName { get; set; }

        public Clients Clients { get; set; }
        public ProductsOwners ProductsOwners { get; set; }
        public Trainers Trainers { get; set; }
        public ICollection<Articles> Articles { get; set; }
        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
