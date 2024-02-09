using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Data {
	public class ApplicationDbContext : IdentityDbContext {
		public DbSet<Message> Messages {get; set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			//
		}
	}
}
