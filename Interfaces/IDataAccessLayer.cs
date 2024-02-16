
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Interfaces {
	public interface IDataAccessLayer {
		public void addMessage(Message m);

		public Profile getProfile(string id);
	}
}
