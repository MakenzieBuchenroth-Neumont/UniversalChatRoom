using Microsoft.AspNetCore.Mvc;
using UniversalChatRoom.Models;
using System.Diagnostics;
using UniversalChatRoom.Models;
using UniversalChatRoom.Interfaces;
using UniversalChatRoom.Data;
using System.Security.Claims;
using DeepL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace UniversalChatRoom.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		TextTranslator tt = new TextTranslator(); // this needs to be passed into any view that uses the translator
		IDataAccessLayer dal;
		//private readonly ILogger<HomeController> _logger;
		public HomeController(IDataAccessLayer indal) {
			dal = indal;

		}

		//public HomeController(ILogger<HomeController> logger)
		//{
			//_logger = logger;
		//}

		[HttpPost]
		public IActionResult Language(string language) {
			//ViewBag.selectedLanguage = language;
			dal.setProfileLanguage(language, User.FindFirstValue(ClaimTypes.NameIdentifier));
			return RedirectToAction("Public");
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[Authorize]
		public IActionResult Public()
		{
			return View((dal.getMessages(null), tt, dal.getUser(GetCurrentUserID()), dal.getProfileFromUser(dal.getUser(GetCurrentUserID()))));
		}

		public IActionResult Test()
		{
			return View(tt);
		}

		public IActionResult Chat(string content, int chatroomID)
		{
			//add message to database
			Message m = new Message();
			m.Contents = content;
			m.username = dal.getUser(GetCurrentUserID()).UserName;
			m.language = dal.getProfileFromUser(GetCurrentUserID()).Language;
			dal.addMessage(m);

			ChatroomMessage chatroomMessage = new ChatroomMessage();
			chatroomMessage.ChatroomID = chatroomID;
			chatroomMessage.MessageID = m.ID;
			dal.addChatroomMessage(chatroomMessage);

			if(chatroomID == dal.getPublicChatroom().ID) {
				return RedirectToAction("Public", "Home");
			} else {
				TempData["dmID"] = chatroomID;
				return RedirectToAction("DM", "Home");
			}
		}

		public IActionResult SecondRegister() {
			if(!dal.doesUserHaveProfile(GetCurrentUserID())) {
				Profile profile = new Profile();
				profile.UserID = GetCurrentUserID();
				profile.Language = LanguageCode.EnglishAmerican;
				dal.addProfile(profile);

				ChatroomProfile chatroomProfile = new ChatroomProfile();
				chatroomProfile.ChatroomID = dal.getPublicChatroom().ID;
				chatroomProfile.ProfileID = profile.ID;
				dal.addChatroomProfile(chatroomProfile);
			}

			return View();
		}

		public IActionResult DM(string username) {
			if(username == null) {
				int chatroomID = (int) TempData["dmID"];

				Chatroom dm = dal.getChatroomFromID(chatroomID);

				Profile profile = dal.getProfileFromUser(GetCurrentUserID());

				IdentityUser user = dal.getUserFromProfile(profile);

				IEnumerable<Message> messages = dal.getMessages(dm);

				return View((messages, tt, user, profile, chatroomID));
			} else {
				int profID = dal.getProfileFromUserName(username).ID;

				Chatroom dm;
				if(!dal.doesChatroomExist(dal.getUser(GetCurrentUserID()).UserName + "-" + dal.getUserFromProfile(dal.getProfileFromID(profID)).UserName)) {
					if(!dal.doesChatroomExist(dal.getUserFromProfile(dal.getProfileFromID(profID)).UserName + "-" + dal.getUser(GetCurrentUserID()).UserName)) {
						dm = new Chatroom();
						dm.RoomName = dal.getUser(GetCurrentUserID()).UserName + "-" + dal.getUserFromProfile(dal.getProfileFromID(profID)).UserName;
						dal.addChatRoom(dm);

						ChatroomProfile chatProf1 = new ChatroomProfile();
						chatProf1.ProfileID = dal.getProfileFromUser(GetCurrentUserID()).ID;
						chatProf1.ChatroomID = dm.ID;
						dal.addChatroomProfile(chatProf1);

						ChatroomProfile chatProf2 = new ChatroomProfile();
						chatProf2.ProfileID = profID;
						chatProf2.ChatroomID = dm.ID;
						dal.addChatroomProfile(chatProf2);
					} else {
						dm = dal.getChatroomFromName(dal.getUserFromProfile(dal.getProfileFromID(profID)).UserName + "-" + dal.getUser(GetCurrentUserID()).UserName);
					}
				} else {
					dm = dal.getChatroomFromName(dal.getUser(GetCurrentUserID()).UserName + "-" + dal.getUserFromProfile(dal.getProfileFromID(profID)).UserName);
				}

				//Profile profile = dal.getProfileFromID(profID);

				//IdentityUser user = dal.getUserFromProfile(profile);

				Profile profile = dal.getProfileFromUser(GetCurrentUserID());

				IdentityUser user = dal.getUser(GetCurrentUserID());

				IEnumerable<Message> messages = dal.getMessages(dm);

				return View((messages, tt, user, profile, dm.ID));
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private string GetCurrentUserID() {
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
