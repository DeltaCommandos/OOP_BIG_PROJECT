using OOP_BIG_PROJECT.Models;
namespace OOP_BIG_PROJECT.ViewModels
{
    public class ChatViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; } // Идентификатор получателя сообщения
        public string ReceiverName { get; set; } // Имя получателя сообщения для отображения в заголовке чата
        public List<Messages> Messages { get; set; } // Список сообщений в чате
        public string Content { get; set; } // Содержимое нового сообщения для отправки
    }
}