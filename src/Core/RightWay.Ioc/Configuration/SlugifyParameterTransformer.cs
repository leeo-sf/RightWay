using Microsoft.AspNetCore.Routing;

namespace RightWay.Ioc.Configuration;

internal class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
        => value?.ToString()?.ToLowerInvariant();
}