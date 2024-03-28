﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name) 
            : base(name, 2.5)
        {
        }

        public override void IncreaseRating()
        {
            base.Rating += 0.75;
            if (this.Rating > 10)
            {
                this.Rating = 10;
            }         
        }

        public override void DecreaseRating()
        {
            base.Rating -= 1.25;
            if (this.Rating < 1) 
            {
                this.Rating = 1;
            }
        }
    }
}
