namespace WebAPI.Security.Auths
{
    public static class AuthOptions
    {
        public static readonly string ISSUER = "https://localhost:7119"; // издатель токена
        public static readonly string AUDIENCE = "MyAuthClient"; // потребитель токена
        public static readonly string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
    }
}