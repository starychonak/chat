using System;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Contracts.DTO;
using Library.Contracts.DTO.Impl;

namespace Library.Data.Entities
{
    /**
     * <summary>
     *  Таблица базы данных, хранящая информацию о сообщениях
     * </summary>
     */
    public class Message : IDto<MessageDTO>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        
        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int DialogId { get; set; }

        public virtual Dialog Dialog { get; set; }

        public virtual User Author { get; set; }

        public MessageDTO ToDto()
        {
            return new MessageDTO(Id, Author.ToDto(), Text, Date, DialogId);
        }
    }
}