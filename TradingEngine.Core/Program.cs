using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TradingEngine.Core;

var book = new OrderBook();

book.AddOrder(new OrderEntry(0, 200, 2, OrderSide.Bid, 1 ));
//book.AddOrder(new OrderEntry(0, 300, 1, OrderSide.Bid, 2 ));


Console.WriteLine("Trades: ");
foreach (var bids in book._bids)
{
    Console.WriteLine(bids);
}
