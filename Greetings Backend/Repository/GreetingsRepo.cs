using Greetings_Backend.Data;
using Greetings_Backend.Model;

namespace Greetings_Backend.Repository
{
    public class GreetingsRepo : IGreetingsRepo
    {
        private readonly Greetings_BackendContext _context;

        public GreetingsRepo(Greetings_BackendContext context)
        {
            _context = context;
        }
        public string GetGreetings()
        {

            List<Greetings> greeting = _context.Greetings.ToList();
            if (greeting == null)
            {
                return "Enter the Details,There is No Data";
            }
            else
            {
                return $"Hello,{greeting[greeting.Count-1].FirstName} {greeting[greeting.Count - 1].LastName}";
                

            }
        }

        public string PostGreetings(Greetings greetings)
        {
            
            _context.Greetings.Add(greetings);
            _context.SaveChanges();
            return "Details Added Successfully, Retrive To Show the Details";
        }
    }
}
