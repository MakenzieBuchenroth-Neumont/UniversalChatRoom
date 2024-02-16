﻿using UniversalChatRoom.Interfaces;
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
	}
}
