namespace OfiCondo.Management.Api.Utility
{
    using System;
        public enum StrategyTypeEnum
    {
        IpAddress,
        PerUser,
        PerApiKey
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RateLimitDecorator: Attribute
    {
        public StrategyTypeEnum StrategyType { get; set; }
    }
}
