using System;
using System.Collections.Generic;
using System.Linq;

namespace homework
{
    /// <summary>
    /// The <c>Stock</c> class contains all the methods that are performed on a stock, such as :
    /// 1. calculate the dividend yield
    /// 2. calculate the P/E Ratio
    /// 3. Record a trade
    /// 4. calculate Volume Weighted Stock Price based on trades in past 5 minutes
    /// </summary>
    class Stock
    {
        public string stockSymbol;
        public StockType type;
        public decimal lastDividend;
        public decimal fixedDividend;
        public decimal parValue;
        public List<Trade> listOfTrades;

        public Stock(string stockSymbol, StockType type, decimal lastDividend, decimal fixedDividend, decimal parValue)
        {
            this.stockSymbol = stockSymbol;
            this.type = type;
            this.lastDividend = lastDividend;
            this.fixedDividend = fixedDividend;
            this.parValue = parValue;
            listOfTrades = new List<Trade>();
        }

        /// <summary>
        ///  The method calcualtes the dividend yield for a given price for the current stock
        /// </summary>
        /// <param name="price">The price of the stock in decimal</param>
        /// <returns> returns a deciaml that represents the dividend yield</returns>
        public decimal calculateDividendYield(decimal price)
        {
            decimal dividendYield = 0;
            //check if price is zero or is negative 
            if (price == 0 || price < 0)
            {
                return dividendYield;
            }
            else
            {
                switch (type)
                {
                    case StockType.Common:
                        dividendYield = lastDividend / price;
                        break;
                    case StockType.Preferred:
                        dividendYield = (fixedDividend * parValue) / price;
                        break;
                    default:
                        dividendYield = 0;
                        break;
                }

                return dividendYield;
            }
           
        }

        /// <summary>
        /// The method calcualtes the PE Ratio for a given price for the current stock
        /// </summary>
        /// <param name="price">The price of the stock in decimal</param>
        /// <returns>returns a decimal that represents the PE Ratio</returns>
        public decimal calcualtePERatio(decimal price)
        {
            decimal PERatio = 0;
            decimal dividend = (calculateDividendYield(price) * price)/100;

            if(dividend != 0)
            {
                return PERatio = price / dividend;
            }else
            {
                return PERatio;
            }
        }

        /// <summary>
        /// The method sells stocks
        /// </summary>
        /// <param name="quantity">an int that represents the number of stocks sold</param>
        /// <param name="price">a decimal that represents the price of selling</param>
        public void sellStock(int quantity, decimal price)
        {
            recordTrade(quantity, TransactionType.SELL, price);
        }


        /// <summary>
        /// The method buys stocks
        /// </summary>
        /// <param name="quantity">an int that represents the number of stocks bought</param>
        /// <param name="price">a decimal that represents the price of buying</param>
        public void buyStock(int quantity, decimal price)
        {
            recordTrade(quantity, TransactionType.BUY, price);
        }


        /// <summary>
        /// This method records a trade performed on a stock
        /// </summary>
        /// <param name="trade">A Trade object that contains the following information: when the trade happend, the quantity , the price and the transaction type</param>
        private void recordTrade(Trade trade)
        {
            listOfTrades.Add(trade);
        }

        /// <summary>
        /// This method records a trade performed on a stock
        /// </summary>
        /// <param name="quantity">An int that defines the quantity of stocks invovled in the transaction</param>
        /// <param name="transactionType">a string that defines if the trade was a selling transaction or a buying one.</param>
        /// <param name="price">The price of the stock in at the time of the trade</param>
        private void recordTrade( int quantity, TransactionType transactionType,decimal price)
        { 
            Trade trade = new Trade(DateTime.Now, quantity, transactionType, price);
            recordTrade(trade);
        }

        /// <summary>
        /// The method retuns the volume weighted stock price for all the trades that happend in the last 5 minutes
        /// </summary>
        /// <returns>returns a decimal that represents the volume weighted stock price </returns>
        public decimal calculateVolumeWeightedStockPrice()
        {
            //Volume weighted stock price
            decimal VWSP = 0;
            var tradesInTheLast5Minutes = getTradesInTheLast5Minutes();
            var sumOfTradedPriceByQuantity = tradesInTheLast5Minutes.Sum(x => x.price * x.quantity);
            var sumOfQuantity = tradesInTheLast5Minutes.Sum(x => x.quantity);
            VWSP =  sumOfTradedPriceByQuantity /sumOfQuantity;
            return VWSP;
        }

        /// <summary>
        /// Returns the a list of trades that happend in the last 5 minutes
        /// </summary>
        /// <returns>A list of trade objects that happend in the last 5 minutes</returns>
        private List<Trade> getTradesInTheLast5Minutes()
        {
            var currentTime = DateTime.Now;
            var theTime5MinutesAgo = currentTime.AddMinutes(-5);
            return listOfTrades.Where(x => x.timeStamp >= theTime5MinutesAgo && x.timeStamp <= currentTime).ToList();
        }

        



    }
}
