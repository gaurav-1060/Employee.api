namespace Employee.api.CustomExceptions
{
    public class NotFoundException:AppException
    {
        public NotFoundException():base("Entity not found",404)
        {
        }

        public NotFoundException(string message):base(message,404) 
        {
        }

        public NotFoundException(string message,Exception ex):base(message,404,ex)
        {
            
        }
    }
}
