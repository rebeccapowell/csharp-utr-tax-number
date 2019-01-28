// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validator.cs" company="Powell IT">
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

namespace Powell.UtrTaxNumberTools
{
    public class Validator
    {
        /// <summary>
        ///     Validates the specified utr.
        /// </summary>
        /// <param name="utr">The utr.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        ///     UTR must have a length of 10.
        ///     or
        ///     UTR must have be numeric.
        /// </exception>
        public bool Validate(string utr)
        {
            // validate length
            if (utr.Length != 10) throw new ArgumentException("UTR must have a length of 10.");

            // validate we only have numeric characters
            if (!utr.All(char.IsDigit)) throw new ArgumentException("UTR must have be numeric.");

            // multipliers and check references
            var multiplier = new[] {6, 7, 8, 9, 10, 5, 4, 3, 2};
            var check = new[] {2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1};

            // convert string to integer array
            var chars = utr.Select(CharUnicodeInfo.GetDecimalDigitValue).ToArray();

            // define the check number
            var checkNumber = chars[0];

            // just use the rest of the number without the check number
            chars = chars.Skip(1).ToArray();

            // define the result
            var result = 0;
            for (var i = 0; i < chars.Length; i++)
                // multiply the reference by the number
                result = result + chars[i] * multiplier[i];

            // remainder of the calculation X/11
            result = result - result / 11 * 11;

            // if they match then this is valid
            return check[result] == checkNumber;
        }
    }
}