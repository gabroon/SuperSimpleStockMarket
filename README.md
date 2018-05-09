# Super Simple Stock Market
A Solution to JP Morgan's technical excersice.

A C# console application that is part of the Global Beverage Corporation Exchange new stock market trading program. This part of the application handles dealing with stocks and all the trades preformed on them, Also it gets the All share index for GBCE.

## Content
The solution has two folders : 
* "Visual C#" that contains the visual studio C# console application + Unit Testing project
* "SuperSimpleStockMarket C# files" this is a striped down version of the project that contains only the necessary C# files.

### Main files in the solution : 
* Stock.cs

  A class that represents a single stock with the following properties (Stock symbol , stock type , last dividend, fixed dividend, par value)  and conatains methods that do the following : 
  
   * Given any price as input, calculates the dividend yield
   * Given any price as input, calculates the P/E Ratio
   * Records a trade, with timestamp, quantity, buy or sell indicator and price
   * Calculates Volume Weighted Stock Price based on trades in past 5 minutes
* Trade.cs

  A class that represents a single trade perfomed on a stock. Has the following properties (the time the trade happend , the quantity ,transaction type, the price)
* GCBEGeneralMethods.cs

  A static class that has one method for caluclating the Global Beverage Corporation Exchange's All Share Index
* enums/TransactionType.cs

  The types of transaction available (Buy, sell)
* enums/StockType.cs

  Types of stock (Common,Preferred)
 * Program.cs 
 
    Has examples of implementing the previous mentioned classes
  
 * SuperSimpleStockMarketTest.cs
    
    The file contains test cases for the main functionalties in the program.
    
## Built With : 
### Technologies used :
  * C#
  * [nUnit](http://nunit.org/) Version 3.10.1 (for testing)
  * [NUnit3TestAdapter](https://github.com/nunit/docs/wiki/VS-Adapter) Version 3.10.0 (for testing)
### IDE :
  * Visual studio Community 2015 + 2017
  
## Testing :
* 6 test cases are available in SuperSimpleMarketTest.cs which test the following : 
   * Calculating the dividend yield
   * Calculating the P/E Ratio
   * Buying or selling a stock
   * Calculating Volume Weighted Stock Price based on trades in past 5 minutes
   * Calculating the All share index for GCBE
  
