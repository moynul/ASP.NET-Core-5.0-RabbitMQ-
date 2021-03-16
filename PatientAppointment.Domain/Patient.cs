using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientAppointment.Domain
{
   public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }

    }
}
