namespace Models
{
    public class Users 
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }

        public Users() { }

        public Users(int userID, string userName, string userPassword, string userEmail, string userRole)
        {
            UserID = userID;
            UserName = userName;
            UserPassword = userPassword;
            UserEmail = userEmail;
            UserRole = userRole;
        }

    }
}
