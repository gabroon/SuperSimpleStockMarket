using System;
using System.Collections.Generic;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stock> stocks = new List<Stock>();
            Stock stockTea = new Stock("TEA", StockType.Common, 0, 0, 100);
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            Stock stockALE = new Stock("ALE", StockType.Common, 23, 0, 60);
            Stock stockGIN = new Stock("GIN", StockType.Preferred, 8, 2, 100);
            Stock stockJOE = new Stock("JOE", StockType.Common, 13, 0, 250);
            stocks.Add(stockTea);
            stocks.Add(stockPOP);
            stocks.Add(stockALE);
            stocks.Add(stockGIN);
            stocks.Add(stockJOE);

            //print Dividend Yield for stock tea
            //return 0
            Console.WriteLine(" Dividend yield : " + stockPOP.calculateDividendYield(0));
            Console.WriteLine(" Dividend yield : " + stockPOP.calculateDividendYield(10.5m));
            Console.WriteLine(" Dividend yield : " + stockPOP.calculateDividendYield(100));
            //retuns 0
            Console.WriteLine(" Dividend yield : " + stockTea.calculateDividendYield(-100));
            //print PE ratio for stock tea
            Console.WriteLine(" PE Ratio : " + stockTea.calcualtePERatio(100));


            //do some transactions on the stocks
            for(var i = 0; i < stocks.Count; i++)
            {
                var stock = stocks[i];
                Random random = new Random(10);
                Random randomPrice = new Random(500); 
                if(i%2 == 0)
                {
                    stock.sellStock(random.Next(), randomPrice.Next());
                }
                else
                {
                    stock.buyStock(random.Next(), randomPrice.Next());
                }
               
            }

            //get all share index
           Console.WriteLine("All Share Index : " + GCBEGeneralMethods.getGCBEAllShareIndex(stocks));

        }
    }
}
