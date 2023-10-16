﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Entities
{
    public class Reservation : BaseModel
    {
        public int Id { get; set; }
        public int CustomerVehicleId { get; set; }
        public DateTime Entrance { get; set; }
        public DateTime Exit { get; set; }
        public int TimeParked { get; set; }
        public bool Paid { get; set; }
        public bool Finished { get; set; }

        public virtual Valet? Valet { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }
}
