namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Attachment: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid AttachmentId { get; set; }
        /// <summary>
        /// Name of the attachment.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// Data of the files.
        /// </summary>
        [Required]
        public byte[] Data { get; set; }

    }
}
