using Microsoft.AspNetCore.Identity;
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Interfaces {
	public interface IDataAccessLayer {
		public void addMessage(Message m);

		public Profile getProfileFromUser(string id);

		public Profile getProfileFromID(int id);

		public IdentityUser getUser(string id);

		public void addChatroomMessage(ChatroomMessage m);

		public void addChatroomProfile(ChatroomProfile p);

		public IEnumerable<Message> getMessages(Chatroom? chatroom);

		public void addChatRoom(Chatroom chatroom);
		
		public void addProfile(Profile profile);

		public IdentityUser getUserFromProfile(Profile profile);

		public Profile getProfileFromUser(IdentityUser user);

		public Profile getProfileFromUserName(string userName);

		public bool doesUserHaveProfile(string id);

		public bool doesChatroomExist(string chatroomName);

		public void setProfileLanguage(string language, string id);

		public Chatroom getPublicChatroom();

		public Chatroom getChatroomFromName(string roomName);

		public Chatroom getChatroomFromID(int id);

		public IEnumerable<Profile> getProfilesInChatroom(int chatroomId);
	}
}


