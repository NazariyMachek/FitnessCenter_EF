using FitnessCenter_EF.API.Validation.Instructor;
using FitnessCenter_EF.API.Validation.Subscription;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Instructor;
using FitnessCenter_EF.BLL.DTOs.Subscription;
using FitnessCenter_EF.BLL.Services;
using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
using FitnessCenter_EF.DAL.Helpers;
using FitnessCenter_EF.DAL.InsertData;
using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .AddFluentValidation();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    op => op.MigrationsAssembly("FitnessCenterFrameworkControllers")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IValidator<UpdateInstructorDTO>, UpdateInstructorDTO_Validator>();
builder.Services.AddTransient<IValidator<InstructorDTO>, InstructorDTO_Validator>();
builder.Services.AddTransient<IValidator<CreateInstructorDTO>, CreateInstructorDTO_Validator>();
builder.Services.AddTransient<IValidator<UpdateSubscriptionDTO>, UpdateSubscriptionDTO_Validator>();
builder.Services.AddTransient<IValidator<SubscriptionDTO>, SubscriptionDTO_Validator>();
builder.Services.AddTransient<IValidator<CreateSubscriptionDTO>, CreateSubscriptionDTO_Validator>();

builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentClassService, EquipmentClassService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddScoped<ISortHelper<Attendance>, SortHelper<Attendance>>();
builder.Services.AddScoped<ISortHelper<Booking>, SortHelper<Booking>>();
builder.Services.AddScoped<ISortHelper<Class>, SortHelper<Class>>();
builder.Services.AddScoped<ISortHelper<Customer>, SortHelper<Customer>>();
builder.Services.AddScoped<ISortHelper<Equipment>, SortHelper<Equipment>>();
builder.Services.AddScoped<ISortHelper<EquipmentClass>, SortHelper<EquipmentClass>>();
builder.Services.AddScoped<ISortHelper<Instructor>, SortHelper<Instructor>>();
builder.Services.AddScoped<ISortHelper<Subscription>, SortHelper<Subscription>>();

builder.Services.AddScoped<IDataShaper<Attendance>, DataShaper<Attendance>>();
builder.Services.AddScoped<IDataShaper<Booking>, DataShaper<Booking>>();
builder.Services.AddScoped<IDataShaper<Class>, DataShaper<Class>>();
builder.Services.AddScoped<IDataShaper<Customer>, DataShaper<Customer>>();
builder.Services.AddScoped<IDataShaper<Equipment>, DataShaper<Equipment>>();
builder.Services.AddScoped<IDataShaper<EquipmentClass>, DataShaper<EquipmentClass>>();
builder.Services.AddScoped<IDataShaper<Instructor>, DataShaper<Instructor>>();
builder.Services.AddScoped<IDataShaper<Subscription>, DataShaper<Subscription>>();

builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentClassRepository, EquipmentClassRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

DataGenerator.Generate();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.MapControllers();
app.Run();
