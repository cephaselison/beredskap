using Beredskap.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.DTOs.VenueDTOs
{
    public class CreateVenueRequest
    {
        public string VenueName { get; set; }
        public string VenueDescription { get; set; }
        public VenueTypeEnum VenueType { get; set; }
    }
}
