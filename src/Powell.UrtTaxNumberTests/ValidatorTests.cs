// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorTests.cs" company="Powells IT">
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
using NUnit.Framework;
using Powell.UtrTaxNumberTools;

namespace Powell.UrtTaxNumberTests
{
    public class ValidatorTests
    {
        /// <summary>
        /// Passes the known valid utr number.
        /// </summary>
        /// <param name="utr">The utr.</param>
        [TestCase("3282497350")]
        [TestCase("9876598765")]
        public void PassKnownValidUtrNumber(string utr)
        {
            var sut = new Validator();
            var result = sut.Validate(utr);
            Assert.That(result.Equals(true));
        }
    }
}