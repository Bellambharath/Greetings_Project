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

        public string DeleteGreetings(int id)
        {
            Greetings greetings=_context.Greetings.Where(x=>x.Id==id).FirstOrDefault();
            if(greetings==null)
            {
                throw new Exception("Id not valid");
            }
            _context.Greetings.Remove(greetings);
            _context.SaveChanges();
            return "Deleted Successfully";
        }



        public string EditGreetings(Greetings greetings)
        {
            Greetings greet = _context.Greetings.Where(x => x.Id == greetings.Id).FirstOrDefault();
            if(greetings==null)
            {
                throw new Exception("Id not valid");
            }
            greet.FirstName=greetings.FirstName;
            greet.LastName=greetings.LastName;
            _context.SaveChanges();
            return "Updated Successfully";
        }

        public List<Greetings> GetGreetings()
        {

            List<Greetings> greeting = _context.Greetings.ToList();

            return greeting;


        }

        public string PostGreetings(Greetings greetings)
        {

            _context.Greetings.Add(greetings);
            _context.SaveChanges();
            return "Details Added Successfully";
        }
    }
}
