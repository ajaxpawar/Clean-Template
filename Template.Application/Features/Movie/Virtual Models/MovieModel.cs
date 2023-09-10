using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Virtual_Models
{
        public class MovieModel
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
            public decimal RentalCost { get; set; }

            public static explicit operator MovieModel(AppMovie entity)
            {
                return new MovieModel
                {
                    Id = entity.Id,
                    MovieName = entity.Name,
                    RentalCost = entity.Cost
                };
            }
        }
    
}
