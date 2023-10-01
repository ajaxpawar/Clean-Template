using HashidsNet;
using Template.Application.Services.LocalServices;

namespace Template.Infrastructure.Services.LocalServices
{
    public class HashingService : IHashingService
    {
        private readonly IHashids _hashids;

        public HashingService(IHashids hashids)
        {
            _hashids = hashids;
        }

        public int Decode(string hashids)
        {
            int id = 0;
            int[] idarray = _hashids.Decode(hashids);
            if (!IsIdsContainsArray(idarray)) throw new KeyNotFoundException("Invalid Id");
            id = idarray[0];
            return id;
        }

        private static bool IsIdsContainsArray(int[] idarray)
        {
            return idarray.Length != 0;
        }

        public string Encode(int id)
        {
            return _hashids.Encode(id);
        }
    }
}