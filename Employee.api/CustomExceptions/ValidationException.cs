namespace Employee.api.CustomExceptions
{
    public class ValidationException:AppException
    {
        public ValidationException(string message):base(message,400)
        {
            
        }
    }
}
