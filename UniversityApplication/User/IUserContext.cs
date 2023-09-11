namespace UniversityApplication.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}