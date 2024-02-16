using System.ComponentModel.DataAnnotations;

namespace UniversalChatRoom.Models {
	public class Chatroom {
		[Key]
		public int ID {get; set;}

		[MaxLength(25), Required]
		public string RoomName {get; set;}
	}
}
