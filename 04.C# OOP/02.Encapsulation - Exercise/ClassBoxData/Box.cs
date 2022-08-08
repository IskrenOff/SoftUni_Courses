using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public double Lenght
        {
            get 
            { 
                return lenght; 
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                lenght = value; 
            }
        }
        
        public double Width
        {
            get 
            { 
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        
        public double Height
        {
            get 
            { 
                return height; 
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value; 
            }
        }

        public double SurfaceArea()
        {
            return 2 * lenght * width + 2 * lenght * height + 2 * width * height; 
        }
        public double LateralSurfaceArea()
        {
            return 2 * lenght * height + 2 * width * height;
        }
        public double Volume()
        {
            return lenght * width * height;
        }
    }
}
