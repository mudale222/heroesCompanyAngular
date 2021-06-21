using AutoMapper;
using heroesCompany.ControllersServices;
using heroesCompany.Data;
using heroesCompany.Data.EFCore;
using heroesCompany.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace heroesCompany.DAL.UnitOfWork {
    public class UnitOfWork : IDisposable {

        private readonly ApplicationDbContext context;
        private IMapper mapper;

        private EfCoreRepository<Hero> heroRepository;
        private EfCoreRepository<ApplicationUser> userRepository;

        private HeroRepository heroRepo;
        private AccountRepository account;

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public UnitOfWork(
            ApplicationDbContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public HeroRepository HeroRepo {
            get {

                if (this.heroRepo == null) {
                    this.heroRepo = new HeroRepository(context, mapper);
                }
                return heroRepo;
            }
        }

        public AccountRepository Account {
            get {
                if (this.account == null) {
                    this.account = new AccountRepository(context, this.userManager, signInManager);
                }
                return account;
            }
        }

        public EfCoreRepository<Hero> HeroGenericRepository {
            get {

                if (this.heroRepository == null) {
                    this.heroRepository = new EfCoreRepository<Hero>(context);
                }
                return heroRepository;
            }
        }

        public EfCoreRepository<ApplicationUser> ApplicationUserGenericRepository {
            get {

                if (this.userRepository == null) {
                    this.userRepository = new EfCoreRepository<ApplicationUser>(context);
                }
                return userRepository;
            }
        }

        public async Task<int> SaveAsync() {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


