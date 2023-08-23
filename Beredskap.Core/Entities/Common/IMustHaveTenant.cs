using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Domain.Entities.Common
{
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
