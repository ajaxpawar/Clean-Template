using HashidsNet;
using Template.Application.Services.LocalServices;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Virtual_Models
{
    public class MovieModel
    {

        public string Id { get; set; }
        public string MovieName { get; set; }
        public decimal RentalCost { get; set; }

        public static MovieModel ToMovieModel(AppMovie entity, IHashingService hashingService)
        {
            return new MovieModel
            {
                Id = hashingService.Encode(entity.Id),
                MovieName = entity.Name,
                RentalCost = entity.Cost
            };
        }

        public static explicit operator MovieModel(AppMovie entity)
        {

            var hashid = new Hashids("ajax", 11);
            return new MovieModel
            {
                Id = hashid.Encode(entity.Id),
                MovieName = entity.Name,
                RentalCost = entity.Cost
            };
        }
    }

}
