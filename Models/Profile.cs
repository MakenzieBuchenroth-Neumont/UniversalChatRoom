using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UniversalChatRoom.Models {
	public class Profile {
		[Key]
		public int ID {get; set;}

		[MaxLength(450), Required]
		public string UserID {get; set;}
		[Required]
		public virtual IdentityUser User {get; set;}

		[MaxLength(5), Required]
		public string Language {get; set;}
	}
}
