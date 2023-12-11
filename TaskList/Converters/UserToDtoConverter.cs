namespace TaskList.Converters
{
    public static class UserToDtoConverter
    {
        public static Domain.User StringToUser(this string userName)
        {
            return new Domain.User()
            {
                FullName = userName
            };
        }

        public static string UserToString(this Domain.User user)
        {
            if (user == null)
                return "";
            return user.FullName;
        }
    }
}
