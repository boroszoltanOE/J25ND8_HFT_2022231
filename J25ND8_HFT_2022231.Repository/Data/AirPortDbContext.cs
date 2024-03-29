﻿using J25ND8_HFT_2022231.Models;
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

            Plane pl1 = new Plane() { Id = 1, AirlineId=AfganLine.Id, Destination ="New Zealand", StartingCountry="Afganistan", Type = "Douglas DC-8", CalculatedTime =13.54};
            Plane pl2 = new Plane() { Id = 2, AirlineId=AfganLine.Id, Destination ="USA", StartingCountry="Afganistan", Type = "Boeing 707", CalculatedTime = 25.32};
            Plane pl3 = new Plane() { Id = 3, AirlineId=TurkishAirline.Id, Destination ="Canary Islands", StartingCountry="Turkey", Type = "Airbus A320", CalculatedTime = 5.12};
            Plane pl4 = new Plane() { Id = 4, AirlineId=TurkishAirline.Id, Destination ="Russia", StartingCountry="Turkey", Type = "Bombardier CRJ700 series", CalculatedTime=21.4};
            Plane pl5 = new Plane() { Id = 5, AirlineId=IzraelPlanes.Id, Destination ="Egypt", StartingCountry="Izrael", Type = "ATR 42/72", CalculatedTime =4.48};
            Plane pl6 = new Plane() { Id = 6, AirlineId=IzraelPlanes.Id, Destination ="Slovakia", StartingCountry="Izrael", Type = "Dash-8", CalculatedTime = 9.6};

            Passenger pr1 = new Passenger() { Id=1, PlaneId=pl1.Id, Name="Franco Sebastian", TicketColumn = 3, TicketRow = 1, TicketPrice = 10000, FirstClass = false};
            Passenger pr2 = new Passenger() { Id=2, PlaneId=pl1.Id, Name="Distefano Bologna", TicketColumn = 1, TicketRow = 3, TicketPrice = 16500, FirstClass = true};
            Passenger pr3 = new Passenger() { Id=3, PlaneId=pl1.Id, Name="Saint Emanuel", TicketColumn = 4, TicketRow = 4, TicketPrice = 14250, FirstClass = true};
            Passenger pr4 = new Passenger() { Id=4, PlaneId=pl4.Id, Name= "Anna Kournikova", TicketColumn = 2, TicketRow = 4, TicketPrice = 8500, FirstClass = true};
            Passenger pr5 = new Passenger() { Id=5, PlaneId=pl4.Id, Name= "Kiss András", TicketColumn = 1, TicketRow = 23, TicketPrice = 7650, FirstClass = false};
            Passenger pr6 = new Passenger() { Id=6, PlaneId=pl4.Id, Name= "Michael Jackson", TicketColumn = 3, TicketRow = 44, TicketPrice = 9850, FirstClass = true };
            Passenger pr7 = new Passenger() { Id=7, PlaneId=pl2.Id, Name="Serena Williams", TicketColumn = 1, TicketRow = 20, TicketPrice = 6400, FirstClass = false };
            Passenger pr8 = new Passenger() { Id=8, PlaneId=pl2.Id, Name="Britney Spearce", TicketColumn = 5, TicketRow = 14, TicketPrice = 4200 , FirstClass = true };
            Passenger pr9 = new Passenger() { Id=9, PlaneId=pl2.Id, Name="Bob Marley", TicketColumn = 8, TicketRow = 26, TicketPrice = 6900, FirstClass = true };
            Passenger pr10 = new Passenger() { Id=10, PlaneId=pl3.Id, Name= "Wenceslao Benítez Inglott", TicketColumn = 5, TicketRow = 14, TicketPrice = 14500, FirstClass = false };
            Passenger pr11 = new Passenger() { Id=11, PlaneId=pl3.Id, Name= "Danyi Úszafygan Joel", TicketColumn = 9, TicketRow = 1, TicketPrice = 5400, FirstClass = false };
            Passenger pr12 = new Passenger() { Id=12, PlaneId=pl3.Id, Name= "Dalmadi Úszafygan Ramirez", TicketColumn = 10, TicketRow = 10, TicketPrice = 18000, FirstClass = true };
            Passenger pr13 = new Passenger() { Id=13, PlaneId=pl5.Id, Name="Mohamed Salah", TicketColumn = 4, TicketRow = 70, TicketPrice = 1500, FirstClass = false };
            Passenger pr14 = new Passenger() { Id=14, PlaneId=pl5.Id, Name="Richard Gear", TicketColumn = 11, TicketRow = 47, TicketPrice = 750, FirstClass = false };
            Passenger pr15 = new Passenger() { Id=15, PlaneId=pl5.Id, Name="Rebete Julio", TicketColumn = 5, TicketRow = 37, TicketPrice = 1750, FirstClass = false };
            Passenger pr16 = new Passenger() { Id=16, PlaneId=pl6.Id, Name= "Marek Hamšík", TicketColumn = 1, TicketRow = 8, TicketPrice = 4500, FirstClass = true};
            Passenger pr17 = new Passenger() { Id=17, PlaneId=pl6.Id, Name= "Ljubl Sirik", TicketColumn = 3, TicketRow = 18, TicketPrice = 2000, FirstClass = false };
            Passenger pr18 = new Passenger() { Id=18, PlaneId=pl6.Id, Name= "Draga Retek", TicketColumn = 7, TicketRow = 34, TicketPrice = 7500, FirstClass = true};

            modelBuilder.Entity<Airline>().HasData(AfganLine,TurkishAirline,IzraelPlanes);
            modelBuilder.Entity<Plane>().HasData(pl1, pl2, pl3, pl4, pl5, pl6);
            modelBuilder.Entity<Passenger>().HasData(pr1,pr2,pr3,pr4,pr5,pr6,pr7,pr8,pr9,pr10, pr11, pr12, pr13, pr14, pr15, pr16, pr17, pr18);
        }
    }
}
