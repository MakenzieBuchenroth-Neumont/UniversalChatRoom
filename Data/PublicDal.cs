using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using UniversalChatRoom.Interfaces;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Data {
	public class PublicDal : IDataAccessLayer {
		private ApplicationDbContext db;

		public PublicDal(ApplicationDbContext indb) {
			db = indb;

			//Chatroom chat = new Chatroom();
			//chat.RoomName = "Public";
			//db.Chatrooms.Add(chat);
			//db.SaveChanges();
		}

		public void addMessage(Message m) {
			db.Messages.Add(m);
			db.SaveChanges();
		}

		public void addChatroomMessage(ChatroomMessage m) {
			db.ChatroomMessages.Add(m);
			db.SaveChanges();
		}

		public void addChatroomProfile(ChatroomProfile p) {
			db.ChatroomProfiles.Add(p);
			db.SaveChanges();
		}

		public Profile getProfileFromUser(string id) {
			return db.Profiles.Where(p => p.UserID == id).First();
		}

		public Profile getProfileFromID(int id) {
			return db.Profiles.Where(p => p.ID == id).First();
		}

		public IdentityUser getUser(string id)
		{
			return db.Users.Where(u => u.Id == id).First();
		}

        public void addProfile(Profile profile)
		{
			db.Profiles.Add(profile);
			db.SaveChanges();
		}

        public IdentityUser getUserFromProfile(Profile profile)
		{
			return db.Users.Where(u => u.Id == profile.UserID).First();
		}

		public Profile getProfileFromUser(IdentityUser user)
		{
			return db.Profiles.Where(p => p.UserID == user.Id).First();
		}

		public bool doesUserHaveProfile(string id)
		{
			return (db.Profiles.Where(p => p.UserID == id).FirstOrDefault()) != null;
		}

		public bool doesChatroomExist(string chatroomName) {
			return db.Chatrooms.Where(c => c.RoomName == chatroomName).FirstOrDefault() != null;
		}

		public void setProfileLanguage(string language, string id)
		{
			var prof = getProfileFromUser(id);
			prof.Language = language;
			db.Profiles.Update(prof);
			db.SaveChanges();
		}

		public Profile getProfileFromUserName(string userName) {
			IdentityUser user = db.Users.Where(u => u.UserName == userName).First();

			return getProfileFromUser(user.Id);
		}

		public void addChatRoom(Chatroom chatroom) {
			db.Chatrooms.Add(chatroom);
			db.SaveChanges();
		}

		public IEnumerable<Message> getMessages(Chatroom? chatroom) {
			if (chatroom == null) {
				chatroom = getPublicChatroom();
			}

			IEnumerable<ChatroomMessage> messagesinChat = db.ChatroomMessages.Where(m => m.ChatroomID == chatroom.ID).ToList();
			List<Message> messages = new List<Message>();
			foreach (ChatroomMessage message in messagesinChat) {
				messages.Add(db.Messages.Where(m => m.ID == message.MessageID).First());	
			}

			//sort message by date.

			return messages;
		}

		public Chatroom getPublicChatroom() {
			return db.Chatrooms.First();
		}

		public Chatroom getChatroomFromName(string roomName) {
			return db.Chatrooms.Where(c => c.RoomName == roomName).First();
		}

		public Chatroom getChatroomFromID(int id) {
			return db.Chatrooms.Where(c => c.ID == id).First();
		}

		public IEnumerable<Profile> getProfilesInChatroom(int chatroomId) {
			IEnumerable<ChatroomProfile> chatroomProfiles = db.ChatroomProfiles.Where(c => c.ChatroomID == chatroomId).ToList();

			List<Profile> profiles = new List<Profile>();

			foreach(ChatroomProfile chatroomProfile in chatroomProfiles) {
				profiles.Add(db.Profiles.Where(p => p.ID == chatroomProfile.ProfileID).First());
			}

			return profiles;
		}
	}
}
