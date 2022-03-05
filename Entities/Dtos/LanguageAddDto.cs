﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class LanguageAddDto : IDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
