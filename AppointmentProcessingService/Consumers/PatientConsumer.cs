using AppointmentProcessingService.Models;
using MassTransit;
using PatientAppointment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentProcessingService.Consumers
{
    public class PatientConsumer : IConsumer<Patient>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PatientConsumer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Consume(ConsumeContext<Patient> context)
        {
            var data = context.Message;
            var patient = new Patient();
            patient.Address = data.Address;
            patient.Age = data.Age;
            patient.Name = data.Name;

            _applicationDbContext.Patients.Add(patient);
            _applicationDbContext.SaveChanges();

        }
    }
}
