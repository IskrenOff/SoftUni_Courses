using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        public CenterBack(string name) 
            : base(name, 4)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= 1;
            if (this.Rating < 1)
            {
                this.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            base.Rating += 1;
            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }
    }
}
