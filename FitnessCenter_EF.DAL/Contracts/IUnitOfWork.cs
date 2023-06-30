using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendance { get; }
        IBookingRepository Bookings { get; }
        IClassRepository Classes { get; }
        ICustomerRepository Customers { get; }
        IEquipmentRepository Equipment { get; }
        IEquipmentClassRepository EquipmentClass { get; }
        IInstructorRepository Instructors { get; }
        ISubscriptionRepository Subscriptions { get; }

        Task SaveChangesAsync();
    }
}
