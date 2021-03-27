using ClinkedIn_SportySpice.Models;
using ClinkedIn_SportySpice.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn_SportySpice.Controllers
{
    [Route("api/clinkers")]
    [ApiController]
    public class ClinkersController : ControllerBase
    {
        ClinkerRepository _repo;
        public ClinkersController()
        {
            _repo = new ClinkerRepository();
        }
        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clinker = _repo.GetById(id);
            if (clinker == null)
            {
                return NotFound("No clinker found.");
            }
            return Ok(_repo.GetById(id));
        }
        [HttpGet("search/service/{service}")]
        public IActionResult GetByServices(string service)
        {
            var clinkers = _repo.GetByServices(service);

            if (clinkers.Count == 0)
            {
                return NotFound("No clinkers matched your search request.");
            }

            return Ok(clinkers);
        }
        [HttpPost]
        public IActionResult AddClinker(Clinker clinker)
        {
            _repo.Add(clinker);
            return Created($"api/clinkers/{clinker.Name}", clinker);
        }

        //[HttpPut("{id}/add-enemy/{enemyId}")]
        //public IActionResult AddEnemy(int id, int enemyId)
        //{
        //    var usersExist = _repo.AddEnemy(id, enemyId);
        //    if (usersExist)
        //    {
        //        return Created($"api/clinkers/{id}/add-enemy/{enemyId}", "Enemy successfully added");
        //    }

        //    return NotFound("Cannot add enemy as requested.");
        //}

        //[HttpPut("{id}/add-friend/{friendId}")]
        //public IActionResult AddFriend(int id, int friendId)
        //{
        //    var usersExist = _repo.AddFriend(id, friendId);
        //    if (usersExist)
        //    {
        //        return Created($"api/clinkers/{id}/add-friend/{friendId}", "Friend successfully added");
        //    }
        //    return NotFound("Cannot add friend as requested.");

        //}

        //[HttpGet("{id}/second-friends")]
        //public IActionResult GetSecondFriends(int id)
        //{
        //    var result = _repo.GetSecondFriends(id);
        //    if (result.Count == 0)
        //    {
        //        return NotFound("No clinkers matched your search request.");
        //    }
        //    return Ok(result);
        //}

        //[HttpPut("{id}/services")]
        //public IActionResult ListService(int id, [FromBody] string service)
        //{
        //    var clinker = _repo.GetById(id);
        //    if (clinker == null)
        //    {
        //        return NotFound("Service cannot be listed as requested.");
        //    }
        //    clinker.Services.Add(service);

        //    return Ok(_repo.GetById(id));
        //}

        //GET to /api/clinkers/{interest}
        [HttpGet("search/interest/{interest}")]
        public IActionResult GetByInterest(string interest)
        {
            var clinkers = _repo.GetByInterest(interest);

            if (clinkers.Count == 0)
            {
                return NotFound("No clinkers matched your search request.");
            }

            return Ok(clinkers);
        }

        //[HttpPut("{id}/interests")]
        //public IActionResult AddInterest(int id, [FromBody] string interest)
        //{
        //    var userExists = _repo.AddInterests(id, interest);
        //    if (userExists)
        //    {
        //    return Ok(_repo.GetById(id).Interests);
        //    }
        //    return NotFound("User not found.");
        //}

        //// GET to /api/clinkers/{id}/days-left
        //[HttpGet("{id}/days-left")]
        //public IActionResult GetDaysLeft(int id)
        //{
        //    var clinker = _repo.GetById(id);
        //    if (clinker == null)
        //    {
        //        return NotFound("User not found.");
        //    }
        //    DateTime today = DateTime.Now;
        //    var releaseDate = clinker.ReleaseDate;
        //    double daysLeft = Math.Round(releaseDate.Subtract(today).TotalDays);

        //    if (daysLeft == 1)
        //    {
        //        return Ok($"You have {daysLeft} day left in your sentence!");
        //    } 
        //    else
        //    {
        //        return Ok($"You have {daysLeft} days left in your sentence.");
        //    }
        //}
        //[HttpDelete("{id}/interests/{interestId}")]
        //public IActionResult DeleteInterest(int id, int interestId)
        //{
        //    var userExists = _repo.DeleteInterests(id, interestId);
        //    if (userExists)
        //    {
        //    return Ok(_repo.GetById(id).Interests);
        //    }
        //    return NotFound("User not found.");
        //}

        //[HttpPut("{id}/interests/{interestId}")]
        //public IActionResult UpdateInterest(int id, int interestId, [FromBody] string newInterest)
        //{
        //    var userExists = _repo.UpdateInterests(id, interestId, newInterest);
        //    if (userExists)
        //    {
        //        return Ok(_repo.GetById(id).Interests);
        //    }
        //    return NotFound("User not found.");
        //}

        //// DELETE to /api/clinkers/{id}/services/{position}
        //[HttpDelete("{id}/services/{position}")]
        //public IActionResult RemoveService(int id, int position)
        //{
        //    var userExists = _repo.RemoveService(id, position);
        //    if (userExists)
        //    {
        //    return Ok();
        //    }
        //    return NotFound("User not found.");
        //}

        //// PUT to /api/clinkers/{id}/services/{position}
        //[HttpPut("{id}/services/{position}")]
        //public IActionResult UpdateService(int id, int position, [FromBody] string newService)
        //{
        //    var userExists = _repo.UpdateService(id, position, newService);
        //    if (userExists)
        //    {
        //    return Ok(_repo.GetById(id));
        //    }
        //    return NotFound("User not found.");
        //}

    }
}
