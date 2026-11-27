
namespace API.CustomExceptions
{

    public class UserRegistrationsException : Exception
    {
        public UserRegistrationsException() { }
        public UserRegistrationsException(string message) 
            : base(message) { }
    }
}