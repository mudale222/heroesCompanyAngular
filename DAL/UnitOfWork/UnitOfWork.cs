using System;
using heroesCompanyAngular.Models;
using heroesCompanyAngular.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using heroesCompanyAngular.DataAccess.Heros;
using heroesCompanyAngular.Data;
using AutoMapper;
using System.Threading.Tasks;
using heroesCompanyAngular.ControllersServices;
using Microsoft.AspNetCore.Identity;

namespace heroesCompanyAngular.DAL.UnitOfWork {
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

        //HeroesDbContext IUnitOfWork.DbContext => this.dbContext as HeroesDbContext;


        //IHeroRepository UnitOfWork.HeroRepo => this.heroRepo;

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


