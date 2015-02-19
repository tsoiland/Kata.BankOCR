namespace Kata.BankOCR
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class OCRTest
    {
        [Test]
        public void a()
        {
            // Arrange
            var sut = new BankOCRParser();
            
            const string s = "    _  _     _  _  _  _  _ \n" +
                             "  | _| _||_||_ |_   ||_||_|\n" +
                             "  ||_  _|  | _||_|  ||_| _|\n" +
                             "                           ";

            // Act
            var i = sut.Parse(s);

            // Assert
            Assert.AreEqual(123456789, i);
        }
    }

    public class BankOCRParser
    {
        public int Parse(string raw)
        {
            // Separate lines
            var lines = raw.Split('\n');

            // Chunk it in 3 by 3 characters
            var indexes = Enumerable.Range(0, 9);
            var threeByThreeChunks = indexes.Select(i => lines.Select(line => line.Substring(i * 3, 3)));

            // Parse each digit to int
            var ints = threeByThreeChunks.Select(chunk => new Digit(chunk).ToInt());

            // Concat ints and return
            return int.Parse(string.Join("", ints));
        }
    }

    public class Digit
    {
        private readonly string[] lines = new string[3];

        public Digit(IEnumerable<string> lines)
        {
            this.lines = lines.ToArray();
        }

        public override bool Equals(object obj)
        {
            var other = (Digit)obj;
            return this.lines.SequenceEqual(other.lines);
        }

        public int ToInt()
        {
            return glyphs.IndexOf(this) + 1;
        }

        private static readonly List<Digit> glyphs = new List<Digit>
                                     {
                                         new Digit(new []
                                                   {
                                                       "   ",
                                                       "  |",
                                                       "  |",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       " _|",
                                                       "|_ ",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       " _|",
                                                       " _|",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       "   ",
                                                       "|_|",
                                                       "  |",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       "|_ ",
                                                       " _|",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       "|_ ",
                                                       "|_|",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       "  |",
                                                       "  |",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       "|_|",
                                                       "|_|",
                                                       "   "
                                                   }),
                                         new Digit(new []
                                                   {
                                                       " _ ",
                                                       "|_|",
                                                       " _|",
                                                       "   "
                                                   }),
                                     };
    }
}
