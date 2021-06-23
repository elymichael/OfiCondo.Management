namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Expense : AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid ExpenseId { get; set; }
        /// <summary>
        /// Record's date.
        /// </summary>
        [Required]
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// Amount.
        /// </summary>
        [Required]
        public double Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? CategoryId { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? PayeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Payee Payee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PaymentMethodId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(800)]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AttachmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Attachment Attachment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? CondominiumId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
