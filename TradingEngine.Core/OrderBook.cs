namespace TradingEngine.Core;

public class OrderBook
{
    public SortedDictionary<long, LinkedList<OrderEntry>> _asks = new();
    public SortedDictionary<long, LinkedList<OrderEntry>> _bids = new();

    public void AddOrder(OrderEntry orderEntry)
    {
        if (orderEntry.Side == OrderSide.Ask)
        {
            if (_asks.ContainsKey(orderEntry.Price))
            {
                _asks[orderEntry.Price].AddLast(orderEntry);
            }
            else
            {
                _asks.Add(orderEntry.Price, new LinkedList<OrderEntry>());
                _asks[orderEntry.Price].AddLast(orderEntry);
            }
        }
        else if (orderEntry.Side == OrderSide.Bid)
        {
            if (_bids.ContainsKey(orderEntry.Price))
            {
                _bids[orderEntry.Price].AddLast(orderEntry);
            }
            else
            {
                _bids.Add(orderEntry.Price, new LinkedList<OrderEntry>());
                _bids[orderEntry.Price].AddLast(orderEntry);
            }
        }
    }
}