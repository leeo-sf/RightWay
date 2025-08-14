using AutoMapper;
using MediatR;
using RightWay.Application.Dto;
using RightWay.Application.Request.Order;
using RightWay.Application.Response;
using RightWay.Domain.Entity;
using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;
using RightWay.Domain.Interface;

namespace RightWay.Application.Handler;

public class OrderHandler
    : IRequestHandler<OrderConfirmedRequest, Result<StatusOperationResponse>>,
        IRequestHandler<OrdersAwaitingSeparationRequest, Result<List<OrderDto>>>,
        IRequestHandler<OrderSeparatedRequest, Result>,
        IRequestHandler<OrdersReadyToDispatchRequest, Result<List<OrderDto>>>,
        IRequestHandler<OrderDispatchedRequest, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderHandler(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<StatusOperationResponse>> Handle(OrderConfirmedRequest request, CancellationToken cancellationToken)
    {
        var orders = request.Orders.Select(order =>
        {
            Guid orderId = Guid.NewGuid(), addressId = Guid.NewGuid(), baseAddressId = Guid.NewGuid();
            DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
            BaseAddress baseAddress = new(baseAddressId, createdAt, updatedIn, order.Address.ZipCode, order.Address.PublicPlace, order.Address.Neighborhood, order.Address.Locality, order.Address.Uf, order.Address.State, order.Address.Region, order.Address.MunicipalCode, null, null);
            Address address = new(addressId, createdAt, updatedIn, order.Address.Number, order.Address.Complement!, baseAddressId, orderId, null) { BaseAddress = baseAddress };
            return new Order(orderId, createdAt, updatedIn, order.Weight, order.Height, order.PriorityLevel, OrderStatusEnum.SEPARATION, addressId) { Address = address };
        });
        await _orderRepository.CreateRangeAsync(orders, cancellationToken);
        return new StatusOperationResponse("Orders awaiting separation.");
    }

    public async Task<Result<List<OrderDto>>> Handle(OrdersAwaitingSeparationRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByStatusAsync(OrderStatusEnum.SEPARATION, cancellationToken);
        return orders is not null
            ? _mapper.Map<List<OrderDto>>(orders)
            : [];
    }

    public async Task<Result> Handle(OrderSeparatedRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
            return new(new KeyNotFoundException("Order not located"));

        if (!order.Status.Equals(OrderStatusEnum.SEPARATION))
            return new(new ApplicationException("Order has already been separated"));

        await _orderRepository.UpdateAsync(order with { updatedIn = DateTime.Now.ToUniversalTime(), Status = OrderStatusEnum.EXPEDITION }, cancellationToken);
        return new(true);
    }

    public async Task<Result<List<OrderDto>>> Handle(OrdersReadyToDispatchRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByStatusAsync(OrderStatusEnum.EXPEDITION, cancellationToken);
        return orders is not null
            ? _mapper.Map<List<OrderDto>>(orders)
            : [];
    }

    public async Task<Result> Handle(OrderDispatchedRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
            return new(new KeyNotFoundException("Order not located"));

        if (!order.Status.Equals(OrderStatusEnum.EXPEDITION))
            return new(new ApplicationException("Order has already been dispatched"));

        await _orderRepository.UpdateAsync(order with { updatedIn = DateTime.Now.ToUniversalTime(), Status = OrderStatusEnum.DISPATCH }, cancellationToken);
        return new(true);
    }
}
