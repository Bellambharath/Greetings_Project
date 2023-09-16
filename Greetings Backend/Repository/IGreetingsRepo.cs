using Greetings_Backend.Model;

namespace Greetings_Backend.Repository
{
    public interface IGreetingsRepo
    {
        string PostGreetings(Greetings greetings);
        string GetGreetings();


    }
}
