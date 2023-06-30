using Bogus;
using FitnessCenter_EF.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.InsertData
{
    public static class DataGenerator
    {
        public static List<Attendance> Attendances { get; set; } = new();
        public static List<Booking> Bookings { get; set; } = new();
        public static List<Class> Classes { get; set; } = new();
        public static List<Customer> Customers { get; set; } = new();
        public static List<Equipment> Equipment { get; set; } = new();
        public static List<EquipmentClass> EquipmentClasses { get; set; } = new();
        public static List<Instructor> Instructors { get; set; } = new();
        public static List<Subscription> Subscriptions { get; set; } = new();

        private const int attendances = 50;
        private const int bookings = 50;
        private const int classes = 50;
        private const int customers = 50;
        private const int equipment = 50;
        private const int equipment_classes = 50;
        private const int instructors = 50;
        private const int subscriptions = 50;

        public static void Generate()
        {
            Customers = new Faker<Customer>()
                .RuleFor(x => x.CustomerId, _ => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.FirstName, x.LastName))
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber(@"## (###) ##-##"))
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .Generate(customers);
            Instructors = new Faker<Instructor>()
                .RuleFor(x => x.InstructorId, _ => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.FirstName, x.LastName))
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber(@"## (###) ##-##"))
                .RuleFor(x => x.Specialization, f => f.PickRandom(
                    "Fitness trainer", "Lifestyle coach", "Sports coach", "Personal trainer", 
                    "Athletic trainer", "Wellness specialist", "Health coach", "Bodybuilding coach", "Exercise specialist"))
                .Generate(instructors);
            Equipment = new Faker<Equipment>()
                .RuleFor(x => x.EquipmentId, _ => Guid.NewGuid())
                .RuleFor(x => x.EquipmentName, f => f.Lorem.Word())
                .RuleFor(x => x.Quantity, f => f.Random.Int(0, 500))
                .Generate(equipment);
            Subscriptions = new Faker<Subscription>()
                .RuleFor(x => x.SubscriptionId, _ => Guid.NewGuid())
                .RuleFor(x => x.CustomerId, f => f.PickRandom(Customers).CustomerId)
                .RuleFor(x => x.StartDate, f => f.Date.Past(2))
                .RuleFor(x => x.EndDate, (f, x) => f.Date.Past(x.StartDate.Year, DateTime.UtcNow.AddYears(10)))
                .RuleFor(x => x.Price, f => f.Random.Decimal(50, 10000))
                .Generate(subscriptions);
            Classes = new Faker<Class>()
                .RuleFor(x => x.ClassId, _ => Guid.NewGuid())
                .RuleFor(x => x.ClassName, f => f.Lorem.Word())
                .RuleFor(x => x.InstructorId, f => f.PickRandom(Instructors).InstructorId)
                .RuleFor(x => x.Schedule, f => f.Lorem.Sentence())
                .RuleFor(x => x.MaxCapacity, f => f.Random.Int(250))
                .Generate(classes);
            Bookings = new Faker<Booking>()
                .RuleFor(x => x.BookingId, _ => Guid.NewGuid())
                .RuleFor(x => x.CustomerId, f => f.PickRandom(Customers).CustomerId)
                .RuleFor(x => x.ClassId, f => f.PickRandom(Classes).ClassId)
                .RuleFor(x => x.BookingDate, f => f.Date.Past(2, DateTime.Now.AddYears(2)))
                .Generate(bookings);
            Attendances = new Faker<Attendance>()
                .RuleFor(x => x.AttendanceId, _ => Guid.NewGuid())
                .RuleFor(x => x.CustomerId, f => f.PickRandom(Customers).CustomerId)
                .RuleFor(x => x.ClassId, f => f.PickRandom(Classes).ClassId)
                .RuleFor(x => x.AttendanceDate, f => f.Date.Past(2))
                .Generate(attendances);

            EquipmentClasses = new Faker<EquipmentClass>()
                .RuleFor(x => x.EquipmentClassId, _ => Guid.NewGuid())
                .RuleFor(x => x.ClassId, f => f.PickRandom(Classes).ClassId)
                .RuleFor(x => x.EquipmentId, f => f.PickRandom(Equipment).EquipmentId)
                .Generate(equipment_classes);
        }
    }
}
