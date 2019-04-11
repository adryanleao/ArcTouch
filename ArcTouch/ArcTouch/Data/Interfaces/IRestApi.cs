using ArcTouch.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcTouch.Data.Interfaces
{
    public interface IRestApi
    {
        //[Get("/todos/{id}")]
        //Task<Usuario> GetTodos(long id);

        [Get("/configuration/languages?api_key=1f54bd990f1cdfb230adb312546d765d")]
        Task<ICollection<Language>> GetLanguages();

        [Get("/genre/movie/list?api_key=1f54bd990f1cdfb230adb312546d765d&language={lang}")]
        Task<Categories> Categories(string lang);

        [Get("/discover/movie?api_key=1f54bd990f1cdfb230adb312546d765d&with_genres={genres}&page=1&language={lang}")]
        Task<Movies> MoviesList(string genres, string lang);

        [Get("/movie/{id}?api_key=1f54bd990f1cdfb230adb312546d765d&language={lang}")]
        Task <DetailMovie> DetailMovies(string id, string lang);
    }
}
