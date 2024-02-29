using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalChatRoom.Models {
	public class Message {
		[Key]
		public int ID {get; set;}

		// This is how you make foreign keys
		// It is weird, but it works
		
		[Required] public string username {get; set;}
		[Required] public string language {get; set;}

		[MaxLength(250), Required]
		public string Contents {get; set;}
	}
}
