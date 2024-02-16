
using UniversalChatRoom.Models;

namespace UniversalChatRoom.Interfaces {
	public interface IDataAccessLayer {
		public void addMessage(Message m);

		public Profile getProfile(string id);

		public void addProfile(Profile profile);

		public bool doesUserHaveProfile(string id);

		public void setProfileLanguage(string language, string id);
	}
}
