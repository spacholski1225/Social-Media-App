# Social-Media-App
## General info
Api for the application that allows employees to communicate within the company, is modeled on social profiles, i.e. it contains all the necessary functions to conduct discussions between users or keeping track of the latest information. The goal of this project is to create Api with documentation and then use it to build one site in two application types, i.e. desktop and web.

## Technology for now:
- .Net 5.0
- ASP.NET Web API
- JWT
- MS Sql Server 
- xUnit

## Tools for now:
- Postman
- Git
- Sql Server Management Studio

# Documentation
## Prerequisites
Before using Web Api, make sure that you have .net 5.0 installed on your computer.
## Instalation
First, download the zip or clone repository.
```
git clone https://github.com/spacholski1225/Social-Media-App.git
```
After that run visual studio and set WebAPI as startup project or run console in folder with application and run
```
dotnet run
```
Then run postman or another program for testing API and make a request.

# IdentityController

```
public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
```
This method as a parameter takes request body it means Email and Password with a standard strong password. This method creates a new user and returned Ok or BadRequest. It depends from that if the user was created successfully. If the method returned Ok result additionally it generated JWT token.

```
public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
```
As a parameter takes request body it means Email and Password. If credentials are correct then it generated JWT token.

```
public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
```
As a parameter takes request JWT Token and returned refresk Token.

# UserController

```
public IActionResult GetUsers()
```
This method returns all users if they already exist.

```
public async Task<IActionResult> GetUserByUserName([FromRoute] string username)
```
As a parameter takes username from the endpoint route and returns user or NotFound if a user does not exist.

```
public async Task<IActionResult> UpdateUser([FromBody] IdentityUser identityUser, string username)
```
As a parameter takes IdentityUser from the request body and takes username. This method updates the existing user about new data.

```
public async Task<IActionResult> DeleteUser([FromRoute] string username)
```
This method as a parameter takes the username of the existing user from the endpoint route and deletes it.

# PostController
```
public IActionResult CreatePost([FromBody] CreatePostRequest request)
```
As a parameter takes request from body with Name as a post content.

```
public async Task<List<Post>> GetPosts()
```
This method returns all posts.

```
public async Task<Post> GetPosts([FromRoute]Guid postId)
```
As a parameter takes post ID from the route. This method returns a specific post.

```
public async Task<IActionResult> UpdatePost([FromRoute]Guid postId, [FromBody] UpdatePostRequest request)
```
This method updates post. As a parameter postId takes post Id from route to update. As request takes new content from body.

```
public async Task<IActionResult> DeletePost([FromRoute]Guid postId)
```
As a parameter takes post ID. This method deletes a specific post.

```
public IActionResult AddCommentToPost([FromBody] CommentPostRequest request)
```
This method adds comment to specific post. As a request paramter takes Comment it means comment content and Post Id.

```
public List<Comments> DisplayPostComments([FromBody] CommentPostRequest request)
```
This method displays all comments from a specific post. As a parameter takes Post Id.

# ProfileController

```
public async Task<IActionResult> GetFriendProfile([FromRoute] string friendId)
```
This method display friend profile. As a parameter from route takes friendId.

# FriendController

```
public async Task<IActionResult> AddFriendAsync([FromBody] GetFriendIdRequest request)
```
This method adds friend to user. As a parameter takes request. Body request had FriendId.

```
public async Task<IActionResult> DeleteFriendAsync([FromBody] GetFriendIdRequest request)
```
This method takes as a parameter request within body contains FriendId. Method deletes user from friends.

```
public IActionResult GetListOfFriends([FromBody] GetUserIdRequest request)
```
This method returns list friends of current user. As a parameter takes request within body contains UserId.
