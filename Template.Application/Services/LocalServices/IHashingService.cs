namespace Template.Application.Services.LocalServices
{
    public interface IHashingService
    {
        string Encode(int id);
        int Decode(string hashids);
    }
}