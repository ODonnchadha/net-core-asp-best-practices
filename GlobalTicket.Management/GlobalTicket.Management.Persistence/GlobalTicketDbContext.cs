namespace GlobalTicket.Management.Persistence
{
    using GlobalTicket.Management.Domain.Common;
    using GlobalTicket.Management.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GlobalTicketDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public GlobalTicketDbContext(DbContextOptions<GlobalTicketDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GlobalTicketDbContext).Assembly);

            var On_MODEL_CREATING_DATE = DateTime.Now;
            var CONCERT = Guid.Parse("DF2892EC-B34C-4A17-B59B-0C4A8F707F7A");
            var CONFERENCE = Guid.Parse("9FED660D-54B2-4B26-A5A5-C0D3142D7B94");
            var MUSICAL = Guid.Parse("C70650CE-5DCF-4FA7-BD83-FE173FB825B1");
            var PLAY = Guid.Parse("EBB7BBDB-A1AD-47C0-BA80-FE33A0784D70");

            #region Category
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = CONCERT,
                Name = "CONCERT",
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = CONFERENCE,
                Name = "CONFERENCE",
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = MUSICAL,
                Name = "MUSICAL",
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = PLAY,
                Name = "PLAY",
            });
            #endregion

            #region Event
            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("253AD714-11BA-47AC-8590-61326894B37C"),
                Name = "CONCERT 1",
                Price = 65,
                Artist = "CONCERT 1 ARTIST",
                Date = On_MODEL_CREATING_DATE.AddMonths(6),
                Description = "CONCERT 1 DESCRIPTION",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                CategoryId = CONCERT
            });
            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("FD928A5D-3613-4AA1-9FC5-AC87C9A8F8AD"),
                Name = "CONCERT 2",
                Price = 85,
                Artist = "CONCERT 2 ARTIST",
                Date = On_MODEL_CREATING_DATE.AddMonths(9),
                Description = "CONCERT 2 DESCRIPTION",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                CategoryId = CONCERT
            });
            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("2D1166D1-219B-45A9-99B4-F6A81DF01ED6"),
                Name = "MUSICAL 1",
                Price = 450,
                Artist = "MUSICAL 1 ARTIST",
                Date = On_MODEL_CREATING_DATE.AddMonths(4),
                Description = "MUSICAL 1 DESCRIPTION",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                CategoryId = MUSICAL
            });
            builder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("C4908B48-738C-4678-A918-B606E3F8E853"),
                Name = "MUSICAL 2",
                Price = 450,
                Artist = "MUSICAL 2 ARTIST",
                Date = On_MODEL_CREATING_DATE.AddMonths(12),
                Description = "MUSICAL 2 DESCRIPTION",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                CategoryId = MUSICAL
            });
            #endregion

            #region Order
            builder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("C2A65DEE-59F3-43BB-9540-A7787B74D155"),
                OrderTotal = 2000,
                OrderPaid = true,
                OrderPlaced = On_MODEL_CREATING_DATE,
                UserId = Guid.Parse("871566AE-DD6E-42F4-A11E-C9B5D554215E")
            });
            #endregion
        }
        public override Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(token);
        }
    }
}
