using MediatR;
using RightWay.Application.Request;
using RightWay.Application.Response;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;
using RightWay.Domain.Interface;

namespace RightWay.Application.Handler;

public class OrderHandler
    : IRequestHandler<OrderConfirmedRequest, Result<StatusOperationResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public OrderHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public async Task<Result<StatusOperationResponse>> Handle(OrderConfirmedRequest request, CancellationToken cancellationToken)
    {
        var orders = request.Orders.Select(order =>
        {
            Guid orderId = Guid.NewGuid(), addressId = Guid.NewGuid(), baseAddressId = Guid.NewGuid();
            DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
            Address address = new(addressId, createdAt, updatedIn, order.Address.Number, order.Address.Complement!, baseAddressId, orderId, null);
            return new Order(orderId, createdAt, updatedIn, order.Weight, order.Height, order.PriorityLevel, OrderStatusEnum.SEPARATION, addressId);
        });
        await _orderRepository.CreateRangeAsync(orders, cancellationToken);
        return new StatusOperationResponse("Orders awaiting separation.");
    }
}
