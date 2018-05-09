using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStockMarket
{
    /// <summary>
    /// The <c>GCBEGeneralMethods</c> contains a method to get the Global Beverage Corporation Exchange's All Share Index
    /// </summary>
    public static class GCBEGeneralMethods
    {
        /// <summary>
        /// The method calculates the Global Beverage Corporation Exchange All share index 
        /// </summary>
        /// <param name="stocks"> A list of stocks</param>
        /// <returns>returns a double representing the all share index</returns>
        public static double getGCBEAllShareIndex(List<Stock> stocks)
        {
            //check if there are any stocks in the list 
            if(stocks.Count == 0){
                return 0;
            }else{
                 //number used to define the nth root
                var n = stocks.Count;
                var sumOfVWSP = stocks.Sum(x => x.calculateVolumeWeightedStockPrice());
                //nth root of x =  x ^ 1/n
                var allShareIndex = Math.Pow((double)sumOfVWSP, (double)1/n);
                return allShareIndex;

            }
          

        }

    }
}
