using Humanizer.Localisation;
using UniversalChatRoom.Interfaces;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Data {
	public class PublicDal : IDataAccessLayer {
		private ApplicationDbContext db;

		public PublicDal(ApplicationDbContext indb) {
			db = indb;
		}

		public void addMessage(Message m) {
			db.Messages.Add(m);
			db.SaveChanges();
		}

		public Profile getProfile(string id) {
			return db.Profiles.Where(p => p.UserID == id).FirstOrDefault();
		}

		public static void AddProfile(Profile profile) {
			//db.Profiles.Add(profile);
			//db.SaveChanges();
		}

		public IEnumerable<Message> getMessages(Chatroom? chatroom) {
			if (chatroom == null) {
				chatroom = db.Chatrooms.First();
			}
			IEnumerable<ChatroomMessage> messagesinChat = db.ChatroomMessages.Where(m => m.ChatroomID == chatroom.ID ).ToList();
			List<Message> messages = new List<Message>();
			foreach (ChatroomMessage message in messagesinChat) {
				messages.Add(db.Messages.Where(m => m.ID == message.MessageID).First());	
			}

			//sort message by date.

			return messages;

		}
	}
}
