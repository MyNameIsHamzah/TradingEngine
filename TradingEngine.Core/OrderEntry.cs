using System.Runtime.InteropServices;

namespace TradingEngine.Core;

// Invariants:
// - No heap allocations
// - Fixed size (32 bytes)
// - All fields are blittable
// - Suitable for array-backed storage and unsafe access

public enum OrderSide
{
  Bid,
  Ask,
}

[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct OrderEntry(long price, int quantity, long orderId, OrderSide side, long sequenceId)
{
  [FieldOffset(0)] public long OrderId = orderId;
  [FieldOffset(8)] public long Price = price;
  [FieldOffset(16)] public int Quantity = quantity;
  [FieldOffset(20)] public OrderSide Side = side; //padding at bytes 21,22 and 23. 
  [FieldOffset(24)] public long SequenceId = sequenceId;
}

