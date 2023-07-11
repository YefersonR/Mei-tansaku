namespace Core.Application.DTOS.Account
{
    public class GenericResponse
    {
        public bool HasError { get; set; } = false;
        public string Error{ get; set; }

    }
}
