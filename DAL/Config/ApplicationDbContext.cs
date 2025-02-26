﻿using heroesCompany.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace heroesCompany.Data {
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser> {

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {
        }
        public DbSet<Hero> Heroes { get; set; }
    }
}
