using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Greetings_Backend.Data;
using Greetings_Backend.Model;
using Greetings_Backend.Repository;
using Newtonsoft.Json;

namespace Greetings_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IGreetingsRepo _repo;

        public GreetingsController(IGreetingsRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Greetings
        [HttpGet]
        public List<Greetings> GetGreetings()
        {
          
            return _repo.GetGreetings();
        }

       

        // POST: api/Greetings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public string PostGreetings(Greetings greetings)
        {

            return JsonConvert.SerializeObject(_repo.PostGreetings(greetings));
            
        }
        [HttpDelete]
        public string DeleteGreetings(int id)
        {
            return JsonConvert.SerializeObject(_repo.DeleteGreetings(id));
        }
        [HttpPut]
        public string UpdateGreetings(Greetings greetings)
        {
            return JsonConvert.SerializeObject(_repo.EditGreetings(greetings));
        }
        
    }
}
