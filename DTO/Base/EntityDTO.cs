using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Base
{
    public class EntityDTO : IEntityDTO<int>
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
    }
}
