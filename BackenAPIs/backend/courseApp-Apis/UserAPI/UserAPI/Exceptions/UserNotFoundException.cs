using System;
namespace UserAPI.Exceptions
{
    public class UserNotFoundException:ApplicationException
    {
        public UserNotFoundException()
        {

        }
        public UserNotFoundException(string msg):base(msg)
        {

        }
    }
}
