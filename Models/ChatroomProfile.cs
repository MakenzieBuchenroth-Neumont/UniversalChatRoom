using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UniversalChatRoom.Models {
	public class ChatroomProfile {
		[Required]
		public int ChatroomID {get; set;}
		[Required]
		public virtual Chatroom Chatroom {get; set;}

		[MaxLength(450), Required]
		public string ProfileID {get; set;}
		[Required]
		public virtual IdentityUser Profile {get; set;}
	}
}
