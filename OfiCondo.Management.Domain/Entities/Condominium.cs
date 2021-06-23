namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Condominium: AuditableEntity
    {
        /// <summary>
        /// identifier
        /// </summary>
        [Key]
        public Guid CondominiumId { get; set; }
        /// <summary>
        /// Name of the block (condominium).
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        /// <summary>
        /// Address of the block (condominium).
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Quantity of Units.
        /// </summary>
        [Required]
        public int Quantity { get; set; }
        /// <summary>
        /// Relation between Account and Blocks.
        /// </summary>
        [Required]
        public Guid? AccountId { get; set; }
        /// <summary>
        /// Relation of Account.
        /// </summary>
        public Account Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Expense> Expenses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Income> Incomes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Minute> Minutes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Message> Messages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Unit> Units { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Fee>  Fees { get; set; }

    }
}
