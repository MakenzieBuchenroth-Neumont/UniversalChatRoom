﻿using Microsoft.AspNetCore.Mvc;
using UniversalChatRoom.Models;
using System.Diagnostics;
using UniversalChatRoom.Models;
using UniversalChatRoom.Interfaces;
using UniversalChatRoom.Data;
using System.Security.Claims;
using DeepL;

namespace UniversalChatRoom.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;
        //private readonly ILogger<HomeController> _logger;
        TextTranslator tt = new TextTranslator();
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

        public IActionResult Public()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View(tt);
        }

        public IActionResult Chat(string content)
        {
            //add message to database
            Message m = new Message();
            m.Contents = content;
            m.ProfileID = dal.getProfile(User.FindFirstValue(ClaimTypes.NameIdentifier)).ID;
            ChatroomMessage chatroomMessage = new ChatroomMessage();
            dal.addMessage(m);
			chatroomMessage.ChatroomID = 1;
            chatroomMessage.MessageID = m.ID;
            dal.addChatroomMessage(chatroomMessage);



			return RedirectToAction("Public", "Home");
        }

        public IActionResult SecondRegister() {
            if(!dal.doesUserHaveProfile(User.FindFirstValue(ClaimTypes.NameIdentifier))) {
                Profile profile = new Profile();
                profile.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                profile.Language = LanguageCode.English;
                dal.addProfile(profile);
			}

            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
