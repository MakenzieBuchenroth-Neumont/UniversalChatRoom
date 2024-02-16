
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Interfaces {
	public interface IDataAccessLayer {
		public void addMessage(Message m);

		public Profile getProfile(string id);

		public void addChatroomMessage(ChatroomMessage m);

		public IEnumerable<Message> getMessages(Chatroom? chatroom);

		public void addChatRoom(Chatroom chatroom);
		}
}


