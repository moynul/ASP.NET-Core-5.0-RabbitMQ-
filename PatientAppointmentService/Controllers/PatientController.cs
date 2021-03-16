using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientAppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IBus _bus;

        public PatientController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Patient patient)
        {
            if (patient != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/PatientQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(patient);
                return Ok();
            }
            return BadRequest();
        }
    }
}
