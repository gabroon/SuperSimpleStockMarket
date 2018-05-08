using System;

namespace SuperSimpleStockMarket
{
    /// <summary>
    /// The <c>Trade</c> class contains the follwoing information about a trade : 
    /// 1. when the trade happend
    /// 2. the transaction type
    /// 3. the quantity
    /// 4. the price
    /// </summary>
    class Trade
    {
        public DateTime timeStamp;
        public int quantity;
        public TransactionType transactionType;
        public decimal price;
        public Trade(DateTime timeStamp ,int quantity, TransactionType transactionType, decimal price)
        {
            this.timeStamp = timeStamp;
            this.quantity = quantity;
            this.transactionType = transactionType;
            this.price = price;
        }
    }
}
