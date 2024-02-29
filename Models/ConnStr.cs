using System;
using System.Configuration;

namespace UniversalChatRoom.Models
{
	public class ConnStr
	{
		public static string Get()
		{
			var uriString = System.Configuration.ConfigurationManager.AppSettings["postgres://bcexmemu:sqIeoOPIjENgt_m4Massh2f9Xqt4XeS3@kashin.db.elephantsql.com/bcexmemu"] ?? "postgres://localhost/mydb";
			var uri = new Uri(uriString);
			var db = uri.AbsolutePath.Trim('/');
			var user = uri.UserInfo.Split(':')[0];
			var passwd = uri.UserInfo.Split(':')[1];
			var port = uri.Port > 0 ? uri.Port : 5432;
			var connStr = string.Format("Server=kashin.db.elephantsql.com;Database=bcexmemu;User Id=zane.ammerman@gmail.com;Password=sqIeoOPIjENgt_m4Massh2f9Xqt4XeS3;Port=5432",
				uri.Host, db, user, passwd, port);
			return connStr;
		}
	}
}