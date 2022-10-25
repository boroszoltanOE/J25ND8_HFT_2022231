using J25ND8_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Repository.Data
{
    public partial class AirPortDbContext : DbContext
    {
        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public AirPortDbContext()
        {
            this.Database.EnsureCreated();
        }
        public AirPortDbContext(DbContextOptions<AirPortDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("airportdb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasOne(passenger => passenger.Plane)
                .WithMany(plane => plane.Passengers)
                .HasForeignKey(passenger => passenger.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasOne(plane => plane.Airline)
                .WithMany(airline => airline.Planes)
                .HasForeignKey(plane => plane.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Airline AfganLine = new Airline() { Id = 1, Name ="AfganLine", BaseCountry = "Afganistan", CreatingTime = new DateTime(2008,5,30), SafetyPoint = 6.5};
            Airline TurkishAirline = new Airline() { Id = 2, Name ="TurkishAirline", BaseCountry = "Turkey", CreatingTime = new DateTime(2000,9,20), SafetyPoint = 9.8};
            Airline IzraelPlanes = new Airline() { Id = 3, Name ="IzraelPlanes", BaseCountry = "Izrael", CreatingTime = new DateTime(2020,1,1), SafetyPoint = 2.25};

            Plane plane1 = new Plane() { Id = 1, AirlineId=AfganLine.Id, Destination ="New Zealand", StartingCountry="Afganistan", Type = "Douglas DC-8"};
            Plane plane2 = new Plane() { Id = 2, AirlineId=AfganLine.Id, Destination ="USA", StartingCountry="Afganistan", Type = "Boeing 707"};
            Plane plane3 = new Plane() { Id = 3, AirlineId=TurkishAirline.Id, Destination ="Canary Islands", StartingCountry="Turkey", Type = "Airbus A320"};
            Plane plane4 = new Plane() { Id = 4, AirlineId=TurkishAirline.Id, Destination ="Russia", StartingCountry="Turkey", Type = "Bombardier CRJ700 series"};
            Plane plane5 = new Plane() { Id = 5, AirlineId=IzraelPlanes.Id, Destination ="Egypt", StartingCountry="Izrael", Type = "ATR 42/72"};
            Plane plane6 = new Plane() { Id = 6, AirlineId=IzraelPlanes.Id, Destination ="Slovakia", StartingCountry="Izrael", Type = "Dash-8"};

            Passenger Sebastian = new Passenger() { Id=1, PlaneId=plane1.Id, Name="Franco Sebastian", TicketColumn = 3, TicketRow = 1};
            Passenger Anna = new Passenger() { Id=2, PlaneId=plane4.Id, Name= "Anna Kournikova", TicketColumn = 2, TicketRow = 4};
            Passenger Serena = new Passenger() { Id=3, PlaneId=plane2.Id, Name="Serena Williams", TicketColumn = 1, TicketRow = 20};
            Passenger Benitez = new Passenger() { Id=4, PlaneId=plane3.Id, Name= "Wenceslao Benítez Inglott", TicketColumn = 5, TicketRow = 14};
            Passenger Mohamed = new Passenger() { Id=5, PlaneId=plane5.Id, Name="Mohamed Salah", TicketColumn = 4, TicketRow = 7};
            Passenger Hamsik = new Passenger() { Id=6, PlaneId=plane6.Id, Name= "Marek Hamšík", TicketColumn = 1, TicketRow = 8};

        }
    }
}
