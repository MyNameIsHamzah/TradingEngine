namespace TradingEngine.Core;

public class OrderBook
{
    public SortedDictionary<long, LinkedList<OrderEntry>> _asks = new();
    public SortedDictionary<long, LinkedList<OrderEntry>> _bids = new();

    public void AddOrder(OrderEntry orderEntry)
    {
        if (orderEntry.Side == OrderSide.Ask)
        {
            _asks.Add(orderEntry.Price, new LinkedList<OrderEntry>());
        }
        else if (orderEntry.Side == OrderSide.Bid)
        {
            _bids.Add(orderEntry.Price, new LinkedList<OrderEntry>());
        }
    }
    
}