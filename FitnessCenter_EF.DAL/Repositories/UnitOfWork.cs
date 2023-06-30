using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            DataContext dbContext,
            IAttendanceRepository Attendance,
            IBookingRepository Bookings,
            IClassRepository Classes,
            ICustomerRepository Customers,
            IEquipmentRepository Equipment,
            IEquipmentClassRepository EquipmentClass,
            IInstructorRepository Instructors,
            ISubscriptionRepository Subscriptions)
        {
            this.dbContext = dbContext;
            this.Attendance = Attendance;
            this.Bookings = Bookings;
            this.Classes = Classes;
            this.Customers = Customers;
            this.Equipment = Equipment;
            this.EquipmentClass = EquipmentClass;
            this.Instructors = Instructors;
            this.Subscriptions = Subscriptions;
        }
        public DataContext dbContext { get; set; }
        public IAttendanceRepository Attendance { get; set; }
        public IBookingRepository Bookings { get; set; }
        public IClassRepository Classes { get; set; }
        public ICustomerRepository Customers { get; set; }
        public IEquipmentRepository Equipment { get; set; }
        public IEquipmentClassRepository EquipmentClass { get; set; }
        public IInstructorRepository Instructors { get; set; }
        public ISubscriptionRepository Subscriptions { get; set; }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
