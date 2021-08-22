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
            public const string Refresh = Base + "/identity/refresh";
        }
        public static class PostRoutes
        {
            public const string GetPostById = Base + "/posts/{postId}";
            public const string GetPosts = Base + "/posts";
            public const string CreatePost = Base + "/posts";
            public const string UpdatePost = Base + "/posts/{postId}";
            public const string DeletePost = Base + "/posts/{postId}";
            public const string LatestPosts = Base + "/posts/latest";
            public const string AddComment= Base + "/posts/addcomment";
        }
        public static class ProfileRoutes
        {
            public const string GetFriendProfile = Base + "/profile/{friendId}";
        }
        public static class FriendRoutes
        {
            public const string AddFriend = Base + "/friend/addfriend";
            public const string DeleteFriend = Base + "/friend/deletefriend";
            public const string GetFriend = Base + "/friend/getfriend";
            public const string GetListOfFriends = Base + "/friend/getfriends";
            
        }
    }
}
