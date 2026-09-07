using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItemDTO>> GetAllOrderItemsAsync();
    Task<IEnumerable<OrderItemDTO>> GetOrderItemsByOrderIdAsync(int orderId);
}