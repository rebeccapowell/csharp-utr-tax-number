// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Generator.cs" company="Powell IT">
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Powell.UtrTaxNumberTools
{
    /// <summary>
    /// Class that generates UK UTR tax numbers.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// The random
        /// </summary>
        private Random _rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Generates the specified district.
        /// </summary>
        /// <param name="district">The district.<examples>201, 362, 794, 406, 687, 456, 020, 455, 532, 687</examples></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Tax Districts are 3 numbers long</exception>
        public string Generate(string district = "")
        {
            // validate that district is three chars or empty
            if (!string.IsNullOrEmpty(district) && district.Length != 3 && !district.All(char.IsDigit))
            {
                throw new ArgumentException("Tax Districts are 3 numbers long");
            }
            
            // define out array for the district and assessment/filing number
            var utrList = new List<int>();

            // validate district
            if (string.IsNullOrEmpty(district))
            {
                utrList.AddRange(_rnd.Next(100, 999).ToString("D3").Select(CharUnicodeInfo.GetDecimalDigitValue));
            }
            else
            {
                utrList.AddRange(district.Select(CharUnicodeInfo.GetDecimalDigitValue));
            }

            // create file / register / assessment number
            utrList.AddRange(_rnd.Next(100000, 999999).ToString("D6").Select(CharUnicodeInfo.GetDecimalDigitValue));

            // multipliers and check references
            var multiplier = new int[] { 6, 7, 8, 9, 10, 5, 4, 3, 2 };
            var check = new int[] { 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var result = 0;

            // calculate sum of totals
            for (int i = 0; i < utrList.Count; i++)
            {
                // multiply the reference by the number
                result = result + utrList[i] * multiplier[i];
            }

            // remainder of the calculation X/11
            result = result - (result / 11) * 11;

            // fx the check digit
            var checkDigit = check[result];

            //utrList.Reverse();
            utrList.Insert(0, checkDigit);

            // return as string
            return string.Join("", utrList.Select(item => item.ToString()).ToArray());
        }
    }
}
