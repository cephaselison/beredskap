using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.DTOs.TenantDTOs
{
    public class TenantDTO
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
    }
}
