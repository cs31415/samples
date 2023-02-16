using System;
using System.Diagnostics.Contracts;

namespace SOLIDPrinciples.LiskovSubstitution.Conformance
{
    class Rectangle
    {
        // invariant: Width
        public virtual int Height { get; set; }
        
        // invariant: Height
        public virtual int Width { get; set; }

        // postcondition: width = factor * width
        // invariant: height
        public virtual Rectangle HorizontalStretch(Rectangle rectangle, int factor)
        {
            rectangle.Width *= factor;
            return rectangle;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Height = {Height}, Width = {Width}");
        }
    }

    class Square : Rectangle
    {
        private int _height;

        // violates invariant
        public override int Height
        {
            get => _height;
            set => _height = _width = value;
        }

        private int _width;

        // violates invariant
        public override int Width
        {
            get => _width;
            set => _width = _height = value;
        }

        public override Rectangle HorizontalStretch(Rectangle rectangle, int factor)
        {
            rectangle.Width *= factor;
            return rectangle;
        }
    }
}
