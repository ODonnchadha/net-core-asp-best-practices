namespace GlobalTicket.Management.Domain.Entities
{
    using GlobalTicket.Management.Domain.Common;
    using System;
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int TotalOrder { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
