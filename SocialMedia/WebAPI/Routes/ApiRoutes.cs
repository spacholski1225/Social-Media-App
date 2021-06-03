namespace WebAPI.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class UserRoutes
        {
            public const string GetAll = Base + "/users";
            public const string GetByUserName = Base + "/users/{username}";
            public const string UpdateUser = Base + "/users/{username}";
            public const string DeleteUser = Base + "/users/{username}";
        }
        public static class IdentityRoutes
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
        }
    }
}
