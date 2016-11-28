﻿using Aurora.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.SMS.EFModel
{
    public class TemplateField:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
    }
}