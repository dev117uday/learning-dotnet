namespace AspJwt.Settings
{
	public class PgSettings
	{
		public string User { get; set; }
		public string Password { get; set; }
		public string Database { get; set; }
		public string Host { get; set; }
		public string Port { get; set; }
		public string ConnectionString
		{
			get
			{
				return $"User ID={User};Password={Password};Host={Host};Port={Port};Database={Database};Pooling=true;";
			}
		}
	}
}