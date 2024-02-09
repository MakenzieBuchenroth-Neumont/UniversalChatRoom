using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Data {
	public class ApplicationDbContext : IdentityDbContext {
		public DbSet<Message> Messages {get; set;}
		public DbSet<Chatroom> Chatrooms {get; set;}
		public DbSet<ChatroomMessage> ChatroomMessages {get; set;}
		public DbSet<ChatroomProfile> ChatroomProfiles {get; set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			//
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);

			builder.Entity<ChatroomMessage>().HasKey(chatMess => new {chatMess.ChatroomID, chatMess.MessageID});
			builder.Entity<ChatroomProfile>().HasKey(chatProf => new {chatProf.ChatroomID, chatProf.ProfileID});
		}
	}
}
