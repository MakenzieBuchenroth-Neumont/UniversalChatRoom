using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UniversalChatRoom.Models {
	public class ChatroomProfile {
		[Required]
		public int ChatroomID {get; set;}
		[Required]
		public virtual Chatroom Chatroom {get; set;}

		[Required]
		public int ProfileID { get; set; }
		[Required]
		public virtual Profile Profile { get; set; }
	}
}
