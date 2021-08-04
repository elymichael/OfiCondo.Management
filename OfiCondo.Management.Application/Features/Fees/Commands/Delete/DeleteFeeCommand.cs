namespace OfiCondo.Management.Application.Features.Fees.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteFeeCommand: IRequest
    {
        public Guid FeeId { get; set; }
    }
}
