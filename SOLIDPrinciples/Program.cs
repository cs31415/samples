using System;
using System.Diagnostics.Contracts;
using SOLIDPrinciples.LiskovSubstitution.Conformance;

/*using SOLIDPrinciples.LiskovSubstitution.NonConformance;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle {Height = 1, Width = 2};
            Stretch(rect, 2);

            var square = new Square {Height = 1, Width = 1};
            Stretch(square, 2);
        }

        static void Stretch(Rectangle rectangle, int factor)
        {
            rectangle.HorizontalStretch(factor);
            rectangle.Print();
        }
    }
}*/

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.Do();
        }

    }
}