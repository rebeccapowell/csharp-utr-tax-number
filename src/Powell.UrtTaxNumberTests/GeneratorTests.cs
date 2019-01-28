// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneratorTests.cs" company="Powells IT">
//   Overview       : An implementation of a UK UTR Number checker for C#.
//   Copyright      : (c) 2019 Rebecca Powell. 
//   License        : http://opensource.org/licenses/MIT
// </copyright>
// <summary>
//  UTR Numbers are unique tax identification reference numbers used in the UK by self-employed and companies.
//  They consist of a 3 digit tax district, followed by six digits that make up the unique assessment or filing number.
//  The first digit is a check digit, comprised based on the combined district and filing number.
// </summary>
// <author>
//   Rebecca Powell
//   <url>https://rebecca-powell.com</url>
//   <url>https://twitter.com/junto</url>
// </author>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using Powell.UtrTaxNumberTools;

namespace Powell.UrtTaxNumberTests
{
    public class GeneratorTests
    {
        /// <summary>
        /// The random
        /// </summary>
        private Random _rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Passes the generated utr without district.
        /// </summary>
        [Test]
        public void PassGeneratedUtrWithoutDistrict()
        {
            var sut = new Generator();
            for (int i = 0; i < 100; i++)
            {
                var utr = sut.Generate(string.Empty);
                Console.WriteLine(utr);

                var validator = new Validator();
                var result = validator.Validate(utr);
                Assert.That(result.Equals(true));
            }
        }

        /// <summary>
        /// Passes the generated utr with district.
        /// </summary>
        [Test]
        public void PassGeneratedUtrWithDistrict()
        {
            var sut = new Generator();
            var validator = new Validator();
            for (var i = 0; i < 100; i++)
            {
                var taxDistrict = _rnd.Next(100, 999).ToString("D3");
                var utr = sut.Generate(taxDistrict);
                Console.WriteLine(utr);
                Assert.That(utr.Length, Is.EqualTo(10));
                Assert.That(utr.Substring(1, 3), Is.EqualTo(taxDistrict));

                var result = validator.Validate(utr);
                Assert.That(result.Equals(true));
            }
        }
    }
}
