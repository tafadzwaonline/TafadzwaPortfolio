using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactForm.Logic.Response
{
    public class ServiceResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
    }
}
