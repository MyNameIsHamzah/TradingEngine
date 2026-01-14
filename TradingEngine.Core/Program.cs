using TradingEngine.Core;

var book = new OrderBook();

book.AddOrder(new OrderEntry(price: 100, quantity: 2, orderId: 1, side: OrderSide.Bid, sequenceId: 1));

book.AddOrder(new OrderEntry(price: 101, quantity: 4, orderId: 2, side: OrderSide.Bid, sequenceId: 2));

book.AddOrder(new OrderEntry(1,102,3,OrderSide.Ask,3));

book.AddOrder(new OrderEntry(1,102,4,OrderSide.Ask,4));

book.PrintOrders(book);

