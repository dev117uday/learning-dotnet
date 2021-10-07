namespace GoogleAuth.Models
{
    public class Profile
    {
        public string sub { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
    }

    public class Token
    {
        public string id_token { get; set; }
        public string scope { get; set; }
        public Profile profile { get; set; }
    }
}