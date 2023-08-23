using Beredskap.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }

}
