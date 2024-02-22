using Microsoft.AspNetCore.Identity;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Interfaces {
	public interface IDataAccessLayer {
		public void addMessage(Message m);

		public Profile getProfile(string id);

		public IdentityUser getUser(string id);

		public void addChatroomMessage(ChatroomMessage m);

		public IEnumerable<Message> getMessages(Chatroom? chatroom);

		public void addChatRoom(Chatroom chatroom);
		
		public void addProfile(Profile profile);

		public IdentityUser getUserFromProfile(Profile profile);

		public bool doesUserHaveProfile(string id);

		public void setProfileLanguage(string language, string id);
	}
}


