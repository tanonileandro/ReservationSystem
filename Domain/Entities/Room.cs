﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Type {  get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
        public int Bedrooms { get; set; }
    }
}
