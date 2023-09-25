using Greetings_Backend.Model;

namespace Greetings_Backend.Repository
{
    public interface IGreetingsRepo
    {
        string PostGreetings(Greetings greetings);
        List<Greetings> GetGreetings();
        string EditGreetings(Greetings greetings);
        string DeleteGreetings(int id);


    }
}
