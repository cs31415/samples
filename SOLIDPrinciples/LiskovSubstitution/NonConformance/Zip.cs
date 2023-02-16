using System;

namespace SOLIDPrinciples.LiskovSubstitution.NonConformance
{
    internal interface IZip
    {
        // returns null if input is null else returns compressed string
        string Zip(string input);
    }

    class SimpleZip : IZip
    {
        public string Zip(string input)
        {
            if (input == null)
                return null;
            // compress spaces
            return Utils.CompressSpaces(input);
        }
    }

    class AdvancedZip : IZip
    {
        public string Zip(string input)
        {
            // pre-conditions violation
            if (input == null)
                throw new ArgumentException();
            return Utils.CompressRepeatingBlocks(Utils.CompressSpaces(input));
        }
    }

    static class Utils
    {
        public static string CompressSpaces(string input)
        {
            //...
            return input;
        }
        public static string CompressRepeatingBlocks(string input)
        {
            //...
            return input;
        }
    }
}
