﻿using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class PackageStatusDto : IDto
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
    }
}
