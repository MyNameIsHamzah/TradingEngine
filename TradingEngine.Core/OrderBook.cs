namespace TradingEngine.Core;

public class OrderBook
{
    private SortedDictionary<long, LinkedList<OrderEntry>> _asks = new(); //linked list creates nodes on the heap (bad)
    private static Comparer<long> _highToLow = Comparer<long>.Create((x, y) => y.CompareTo(x));
    private SortedDictionary<long, LinkedList<OrderEntry>> _bids = new(_highToLow); //later we replace this with pre allocated arrays for zero allocation

    public void AddOrder(OrderEntry orderEntry)
    {
        switch (orderEntry.Side)
        {
            case OrderSide.Ask when _asks.ContainsKey(orderEntry.Price):
                _asks[orderEntry.Price].AddLast(orderEntry);
                break;
            case OrderSide.Ask:
                _asks.Add(orderEntry.Price, new LinkedList<OrderEntry>());
                _asks[orderEntry.Price].AddLast(orderEntry);
                break;
            case OrderSide.Bid when _bids.ContainsKey(orderEntry.Price):
                _bids[orderEntry.Price].AddLast(orderEntry);
                break;
            case OrderSide.Bid:
                _bids.Add(orderEntry.Price, new LinkedList<OrderEntry>());
                _bids[orderEntry.Price].AddLast(orderEntry);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void PrintOrders(OrderBook book)
    {
        Console.WriteLine("- - - - - - - - Bids (Buyers) - - - - - - - -");
        foreach (var priceLevel in book._bids)
        {
            Console.WriteLine($"Price level: {priceLevel.Key}");   
            foreach (var bid in priceLevel.Value)
            {
                Console.WriteLine($"Order Id: {bid.OrderId}, Quantity: {bid.Quantity} ");
            }
        }

        Console.WriteLine("- - - - - - - - Asks (Sellers) - - - - - - - -");
        foreach (var priceLevel in book._asks)
        {
            Console.WriteLine($"Price level: {priceLevel.Key}");   
            foreach (var ask in priceLevel.Value)
            {
                Console.WriteLine($"Order Id: {ask.OrderId}, Quantity: {ask.Quantity} ");
            }
        }
    }
}