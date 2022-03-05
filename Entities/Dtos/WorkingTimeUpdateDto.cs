﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WorkingTimeUpdateDto : IDto
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
