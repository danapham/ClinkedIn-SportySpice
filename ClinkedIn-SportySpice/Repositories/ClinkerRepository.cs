using ClinkedIn_SportySpice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;


namespace ClinkedIn_SportySpice.Repositories
{
    public class ClinkerRepository
    {
        const string ConnectionString = "Server=localhost;Database=ClinkedIn;Trusted_Connection=True;";

        //static List<Clinker> _clinkers = new List<Clinker>
        //{
        //    new Clinker {Id=1,Name="Prison Mike", ReleaseDate=new DateTime(2021,10,31), Interests = new List<string>(){"Robbing", "Stealing", "Kidnapping"} },
        //    new Clinker {Id=2,Name="Piper", ReleaseDate=new DateTime(2021,2,27), Interests = new List<string>(){"Smuggling", "Stealing", "Kidnapping"} },
        //    new Clinker {Id=3,Name="Alex", ReleaseDate=new DateTime(2021,6,15), Interests = new List<string>(){"Smuggling", "Stealing", "Kidnapping"} },
        //    new Clinker {Id=4,Name="Suzanne", ReleaseDate=new DateTime(2021,12,31), Interests = new List<string>(){"Robbing", "Embezzlement", "Corporate Fraud"} }

        //};
        public List<Clinker> GetAll()
        {
            var db = new SqlConnection(ConnectionString);

            var sql = @"SELECT *
                        FROM Clinkers";

            return db.Query<Clinker>(sql).ToList();

        }
        public Clinker GetById(int id)
        {
            var db = new SqlConnection(ConnectionString);

            var sql = @"SELECT *
                        FROM Clinkers
                        WHERE Id = @id";

            return db.QueryFirstOrDefault<Clinker>(sql, new { id });
        }
        //public List<Clinker> GetByServices(string service)
        //{
        //    var results = new List<Clinker>();
        //    results = _clinkers.Where(clinker => clinker.Services.Contains(service, StringComparer.InvariantCultureIgnoreCase)).ToList();
        //    return results;
        //}
        //public void Add(Clinker clinker)
        //{
        //    var biggestExistingId = _clinkers.Max(l => l.Id);
        //    clinker.Id = biggestExistingId + 1;
        //    _clinkers.Add(clinker);
        //}

        //public List<Clinker> GetByInterest(string interest)
        //{
        //    var clinkers = new List<Clinker>();
        //    clinkers = _clinkers.FindAll(clinker => clinker.Interests.Contains(interest, StringComparer.InvariantCultureIgnoreCase));
        //    return clinkers;
        //}
        //public bool AddEnemy(int userId, int enemyId)
        //{
        //    var userClinker = GetById(userId);
        //    var enemyClinker = GetById(enemyId);

        //    if (userClinker == null || enemyClinker == null || userClinker == enemyClinker || userClinker.Enemies.Contains(enemyId))
        //    {
        //        return false;
        //    }
        //    else if (userClinker.Friends.Contains(enemyId))
        //    {
        //        userClinker.Friends.Remove(enemyId);
        //    }

        //    userClinker.Enemies.Add(enemyClinker.Id);
        //    return true;
        //}

        //public bool AddFriend(int userId, int friendId)
        //{
        //    var userClinker = GetById(userId);
        //    var friendClinker = GetById(friendId);

        //    if (friendClinker == null || userClinker == null || userClinker == friendClinker || userClinker.Friends.Contains(friendId))
        //    {
        //        return false;
        //    }
        //    else if (userClinker.Enemies.Contains(friendId))
        //    {
        //        userClinker.Enemies.Remove(friendId);
        //    }

        //    userClinker.Friends.Add(friendClinker.Id);
        //    return true;
        //}

        //public HashSet<Clinker> GetSecondFriends(int id)
        //{
        //    var user = GetById(id);
        //    var secondFriends = new HashSet<Clinker>();

        //    if (user != null)
        //    {
        //        foreach (var friendId in user.Friends)
        //        {
        //            var friend = GetById(friendId);
        //            var secondFriendIds = friend.Friends.Where(f => !user.Friends.Contains(f)).ToList();

        //            if (secondFriendIds.Contains(user.Id))
        //            {
        //                secondFriendIds.Remove(user.Id);
        //            }

        //            secondFriendIds.ForEach(friendId => secondFriends.Add(GetById(friendId)));

        //        }
        //    }

        //    return secondFriends;
        //}

        //public bool AddInterests(int userId, string interest)
        //{
        //    var user = GetById(userId);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    user.Interests.Add(interest);
        //    return true;
        //}

        //public bool DeleteInterests(int userId, int interestId)
        //{
        //    var user = GetById(userId);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    try
        //    {
        //        var interestToRemove = user.Interests[interestId];
        //        user.Interests.Remove(interestToRemove);
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {

        //    }
        //    return true;

        //}
        //public bool UpdateInterests(int userId, int interestId, string newInterest)
        //{
        //    var user = GetById(userId);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    try
        //    {
        //        user.Interests[interestId] = newInterest;
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        AddInterests(userId, newInterest);
        //    }
        //    return true;
        //}

        //public bool RemoveService(int id, int position)
        //{
        //    var clinker = GetById(id);
        //    if (clinker == null)
        //    {
        //        return false;
        //    }
        //    var serviceToRemove = clinker.Services.ElementAtOrDefault(position);

        //    clinker.Services.Remove(serviceToRemove);
        //    return true;
        //}

        //public bool UpdateService(int id, int position, string newService)
        //{
        //    var clinker = GetById(id);
        //    if (clinker == null)
        //    {
        //        return false;
        //    }
        //    try
        //    {
        //        clinker.Services[position] = newService;
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        clinker.Services.Add(newService);
        //    }
        //    return true;
        //}
    }
}
