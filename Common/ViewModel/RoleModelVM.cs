﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class RoleModelVM :BaseEntityVM
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
    }
}
