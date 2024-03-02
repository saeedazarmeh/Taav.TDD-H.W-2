using DoctorAppointment.Persistance.EF.Appointments;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Appointmens;
using DoctorAppointment.Services.Appointmens.Cantracts;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Patients;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using PatientAppointment.Persistance.EF.Patients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DoctorRepository,EFDoctorRepository>();
builder.Services.AddScoped<PatientRepository,EFPatientRepository>();
builder.Services.AddScoped<AppointmentRepository,EfAppointmentRepository>();
builder.Services.AddScoped<DoctorService,DoctorAppService>();
builder.Services.AddScoped<PatientService,PatientAppService>();
builder.Services.AddScoped<AppointmentService,AppointmentAppService>();
builder.Services.AddDbContext<EFDataContext>(option =>
     option.UseSqlServer(builder.Configuration["ConnectionStrings:D.A_Database"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
