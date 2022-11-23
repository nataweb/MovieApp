using AutoMapper;

namespace MovieApp.API.Profiles
{
    public class MoviesProfile:Profile
    {
        public MoviesProfile()
        {
            CreateMap<Models.Domain.Movies, Models.DTO.Movie>()
                .ReverseMap();
        }
    }
}                    

   

