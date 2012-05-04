// --------------------------------------------------------------------------
// THIS SOURCE FILE IS A PART OF THE LATENCE TRADING SUITE DEDICATED TO EMPOWER ALGORITHMIC TRADING ACTIVITIES.
// BY USING ALL OR ANY PART OF THE SOFTWARE COMPONENT OR SOURCES, YOU AGREE TO THE TERMS OF THE COMMERCIAL LICENCE ISSUED BY SUNIX FIRST LTD.
// DO NOT USE THE SOFTWARE UNTIL YOU HAVE CAREFULLY READ AND AGREED TO THE TERMS AND CONDITIONS OF THE LICENCE.
// THE MATERIALS ARE PROVIDED "AS IS". SUNIX DISCLAIMS ALL EXPRESS OR IMPLIED WARRANTIES WITH RESPECT TO THEM,
// INCLUDING ANY IMPLIED WARRANTIES OF MERCHANTABILITY, NON-INFRINGEMENT, AND FITNESS FOR ANY PARTICULAR PURPOSE.
// SUNIX SHALL NOT BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING,WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
// BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE SOFTWARE.
// contact@latence.co.uk
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fishery_Simulation
{
    class Simulator
    {



        /// <summary>The normdist.</summary>
        /// <param name="x">The x.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="std">The std. </param>
        /// <param name="cumulative">The cumulative.</param>
        /// <returns>The normdist.</returns>
        public static double NORMDIST(double x, double mean, double std, bool cumulative)
        {
            if (cumulative)
            {
                return Phi(x, mean, std);
            }

            var tmp = 1 / (Math.Sqrt(2 * Math.PI) * std);
            return tmp * Math.Exp(-.5 * Math.Pow((x - mean) / std, 2));
        }

        // from http://www.cs.princeton.edu/introcs/...Math.java.html
        // fractional error less than 1.2 * 10 ^ -7.

        // cumulative normal distribution
        /// <summary>The phi.</summary>
        /// <param name="z">The z.</param>
        /// <returns>The phi.</returns>
        public static double Phi(double z)
        {
            return 0.5 * (1.0 + erf(z / Math.Sqrt(2.0)));
        }

        // cumulative normal distribution with mean mu and std deviation sigma
        /// <summary>The phi.</summary>
        /// <param name="z">The z.</param>
        /// <param name="mu">The mu.</param>
        /// <param name="sigma">The sigma.</param>
        /// <returns>The phi.</returns>
        public static double Phi(double z, double mu, double sigma)
        {
            return Phi((z - mu) / sigma);
        }

        /// <summary>The erf.</summary>
        /// <param name="z">The z.</param>
        /// <returns>The erf.</returns>
        public static double erf(double z)
        {
            var t = 1.0 / (1.0 + 0.5 * Math.Abs(z));

            // use Horner's method
            var ans = 1 -
                      t *
                      Math.Exp(
                          -z * z - 1.26551223 +
                          t *
                          (1.00002368 +
                           t *
                           (0.37409196 +
                            t *
                            (0.09678418 +
                             t *
                             (-0.18628806 +
                              t *
                              (0.27886807 +
                               t * (-1.13520398 + t * (1.48851587 + t * (-0.82215223 + t * 0.17087277)))))))));
            if (z >= 0)
            {
                return ans;
            }

            return -ans;
        }



    }
}
