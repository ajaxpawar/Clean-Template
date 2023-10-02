using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Virtual_Models
{
    public class MovieModel
    {

        public string Id { get; set; }
        public string MovieName { get; set; }
        public decimal RentalCost { get; set; }

        

        public static explicit operator MovieModel(AppMovie entity)
        {

            return new MovieModel
            {
                Id =entity.Id.Value.ToString(),
                MovieName = entity.Name,
                RentalCost = entity.Cost
            };
        }
    }

}
