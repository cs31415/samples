using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.LiskovSubstitution.Conformance
{
    public class Animal {}
    public class Giraffe : Animal { }

    public class Client
    {
        public void Do()
        {
            Func<Animal, Animal> foo = Foo;
            var g = new Giraffe();
            var a = foo(g);
            Console.WriteLine($"type of a = {g.GetType().Name}");
        }

        private Animal Foo(Animal arg)
        {
            return arg;
        }
    }
}
