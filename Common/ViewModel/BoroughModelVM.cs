﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class BoroughModelVM :BaseEntityVM
    {      
        public int Id { get; set; }
        public string BoroughName { get; set; }
    }
}
