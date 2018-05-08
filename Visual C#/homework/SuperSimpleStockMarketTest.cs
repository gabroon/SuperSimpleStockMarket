using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStockMarket
{
    [TestFixture]
    class SuperSimpleStockMarketTest
    {
        [TestCase]
        public void calculateDividendYield()
        {
            //test common first
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            Assert.AreEqual(0.0000000008, stockPOP.calculateDividendYield(10000000000));
            Assert.AreEqual(0, stockPOP.calculateDividendYield(0));
            Assert.AreEqual(0.08, stockPOP.calculateDividendYield(100));
            Assert.AreEqual(0, stockPOP.calculateDividendYield(-10));
        }

        [TestCase]
        public void calculatePERatio()
        {
            //test common first
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            Assert.AreEqual(125000000000, stockPOP.calcualtePERatio(10000000000));
            Assert.AreEqual(0, stockPOP.calcualtePERatio(0));
            Assert.AreEqual(1250, stockPOP.calcualtePERatio(100));
            Assert.AreEqual(0, stockPOP.calcualtePERatio(-10));
        }

        [TestCase]
        public void sellStock()
        {
            //test common first
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            stockPOP.sellStock(10, 100);
            Assert.AreEqual(1,stockPOP.listOfTrades.Count);
            stockPOP.sellStock(0, 0);
            Assert.AreEqual(1, stockPOP.listOfTrades.Count);
            stockPOP.sellStock(-10, -500);
            Assert.AreEqual(1, stockPOP.listOfTrades.Count);
            stockPOP.sellStock(10, 500);
            Assert.AreEqual(2, stockPOP.listOfTrades.Count);
        }

        [TestCase]
        public void buyStock()
        {
            //test common first
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            stockPOP.buyStock(10, 100);
            Assert.AreEqual(1, stockPOP.listOfTrades.Count);
            stockPOP.buyStock(0, 0);
            Assert.AreEqual(1, stockPOP.listOfTrades.Count);
            stockPOP.buyStock(-10, -500);
            Assert.AreEqual(1, stockPOP.listOfTrades.Count);
            stockPOP.buyStock(10, 500);
            Assert.AreEqual(2, stockPOP.listOfTrades.Count);
        }

        [TestCase]
        public void calculateVolumeWeightedStockPrice()
        {
            Stock stockPOP = new Stock("POP", StockType.Common, 8, 0, 100);
            stockPOP.buyStock(10, 100);
            stockPOP.buyStock(10, 500);
            stockPOP.sellStock(10, 500);
            Assert.AreEqual(366.66666666666666666666666666667m, stockPOP.calculateVolumeWeightedStockPrice());

            Stock stockPOP2 = new Stock("POP", StockType.Common, 8, 0, 100);
            
            Assert.AreEqual(0, stockPOP2.calculateVolumeWeightedStockPrice());
        }


        [TestCase]
        public void calculateAllShareIndex()
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

            for (var i = 0; i < stocks.Count; i++)
            {
                var stock = stocks[i];
                if (i % 2 == 0)
                {
                    stock.sellStock(10, 50);
                }
                else
                {
                    stock.buyStock(10, 50);
                }

            }

            Assert.AreEqual(3.0170881682725815432356308547584m, GCBEGeneralMethods.getGCBEAllShareIndex(stocks));

        }

    }
}
