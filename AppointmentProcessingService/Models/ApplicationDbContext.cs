using Microsoft.EntityFrameworkCore;
using PatientAppointment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentProcessingService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
          public DbSet<Patient> Patients { get; set; }
    }


 }
