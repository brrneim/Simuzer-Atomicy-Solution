using Atomicy.Domain.Common;
using Atomicy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atomicy.Persistence
{
    public class AtomicyDbContext: DbContext
    {
        public AtomicyDbContext(DbContextOptions<AtomicyDbContext> options, Application.Contracts.ILoggedInUserService @object)
           : base(options)
        {
        }

        public DbSet<DemandType> DemandTypes { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<FirmVehicle> FirmVehicles { get; set; }
        public DbSet<FirmComment> FirmComments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtomicyDbContext).Assembly);

            //seed data, added through migrations



            var homeGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var furnitureGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var officeGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            modelBuilder.Entity<DemandType>().HasData(new DemandType
            {
                DemandTypeId = homeGuid,
                Name = "Evimi Taşı"
            });
            modelBuilder.Entity<DemandType>().HasData(new DemandType
            {
                DemandTypeId = furnitureGuid,
                Name = "Parça Eşyamı Taşı"
            });
            modelBuilder.Entity<DemandType>().HasData(new DemandType
            {
                DemandTypeId = officeGuid,
                Name = "Ofisimi Taşı"
            });

            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                Completed = false,
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                DemandDate = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                DemandTypeId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                From = "Bahçelievler",
                LastModifiedBy = null,
                LastModifiedDate = null,
                Note = "Paketlemeyi de sizin yapmanızı istiyorum.",
                To = "Halkalı"
            });
            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                Completed = false,
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                DemandDate = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                DemandTypeId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                From = "Avcılar",
                LastModifiedBy = null,
                LastModifiedDate = null,
                Note = "Paketlemeyi de sizin yapmanızı istiyorum.",
                To = "Bakırköy"
            });

            modelBuilder.Entity<DemandConversation>().HasData(new DemandConversation
            {
                DemandConversationId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                Date = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                CustomerMessage = null,
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmMessage = "Merhaba 3000 tl ye götürebiliriz.",
                Read = false,
                DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                FirmId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde")
            });

            modelBuilder.Entity<DemandConversation>().HasData(new DemandConversation
            {
                DemandConversationId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                Date = new DateTime(2023, 9, 4, 23, 22, 26, 339, DateTimeKind.Local).AddTicks(5213),
                CustomerMessage = "Hangi günler musaitsiniz?",
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmMessage = null,
                Read = false,
                DemandId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                FirmId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde")
            });

            modelBuilder.Entity<Firm>().HasData(new Firm
            {
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmName = "İstanbul Nakliyat",
                VanCount = 4,
                TruckCount = 10,
                BigTruckCount = 10,
                Note = "30 yıldır taşımacılık sektöründe faaliyet göstermekteyiz."
            });

            modelBuilder.Entity<Firm>().HasData(new Firm
            {
                FirmId = new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmName = "İstanbul Nakliyat",
                VanCount = 2,
                TruckCount = 5,
                BigTruckCount = 3,
                Note = "10 yıldır müşterilerimize üst düzeyde hizmet vermekteyiz."
            });

            modelBuilder.Entity<FirmComment>().HasData(new FirmComment
            {
                FirmCommentId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                UserId = new Guid("15EFC991-E022-48A1-9394-D398A9FFF76F"),
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Comment = "Eşyalara zarar vermeden paketleme ve taşıma harikaydı. Tavsiye ederim."
            });

            modelBuilder.Entity<FirmComment>().HasData(new FirmComment
            {
                FirmCommentId = new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                UserId = new Guid("15EFC991-E022-48A1-9394-D398A9FFF76F"),
                FirmId = new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"),
                Comment = "Çok memnun kalmadım. Tavsiye etmiyorum."
            });

            modelBuilder.Entity<FirmVehicle>().HasData(new FirmVehicle
            {
                FirmVehicleId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Plate = "34 DP 524",
                DriverName = "Melih Gümüş",
                DriverExperience = 21,
                DriverNote= "Ehliyeti aldığından beri kaza geçirmemiş, deneyimli bir şöfördür."
            });

            modelBuilder.Entity<FirmVehicle>().HasData(new FirmVehicle
            {
                FirmVehicleId = new Guid("6313179F-7837-473A-A4D5-A5571B43E6A6"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Plate = "34 HGE 239",
                DriverName = "Güven Duman",
                DriverExperience = 15,
                DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır."
            });

            modelBuilder.Entity<FirmVehicle>().HasData(new FirmVehicle
            {
                FirmVehicleId = new Guid("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Plate = "34 PT 6376",
                DriverName = "Zafer Yener",
                DriverExperience = 12,
                DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır."
            });

            modelBuilder.Entity<FirmVehicle>().HasData(new FirmVehicle
            {
                FirmVehicleId = new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Plate = "34 MVR 13",
                DriverName = "İsmet Yıldırım",
                DriverExperience = 26,
                DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır."
            });

            modelBuilder.Entity<FirmVehicle>().HasData(new FirmVehicle
            {
                FirmVehicleId = new Guid("661A30F3-EFE5-4474-73B9-08DBB62985D7"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Plate = "34 DE 147",
                DriverName = "Hakan Yakın",
                DriverExperience = 12,
                DriverNote = "Sürücünün ilk yardım belgesi bulunmaktadır."
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationId = new Guid("661A30F3-EFE5-4474-73B9-08DBB62985D7"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                DemandId = new Guid("5145DD9C-B73E-4B8B-0100-08DBB5B79E8A"),
                FirmId = new Guid("FE98F549-E790-4E9F-AA16-18C2292A2EE9"),
                Note = "Yola çıkmadan önce müşteri aranacak.",
                ReservationDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                CarryDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationId = new Guid("6313179F-7837-473A-A4D5-A5571B43E6A6"),
                CreatedBy = null,
                CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                LastModifiedBy = null,
                LastModifiedDate = null,
                UserId = new Guid("d67d8f35-1e55-4543-8ef3-f58ac532d38b"),
                DemandId = new Guid("5145DD9C-B73E-4B8B-0100-08DBB5B79E8A"),
                FirmId = new Guid("BF3F3002-7E53-441E-8B76-F6280BE284AA"),
                Note = "10 bin tl ye anlaşıldı.",
                ReservationDate = new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                CarryDate = new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
            });
           
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
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
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
