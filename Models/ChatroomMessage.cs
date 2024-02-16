using System.ComponentModel.DataAnnotations;

namespace UniversalChatRoom.Models {
	public class ChatroomMessage {
		[Required]
		public int ChatroomID {get; set;}
		[Required]
		public virtual Chatroom Chatroom {get; set;}

		[Required]
		public int MessageID {get; set;}
		[Required]
		public virtual Message Message {get; set;}
	}
}
