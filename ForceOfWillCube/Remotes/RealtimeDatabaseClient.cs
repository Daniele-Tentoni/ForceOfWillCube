using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using ForceOfWillCube.Models.Sets;
using Newtonsoft.Json;

namespace ForceOfWillCube.Remotes
{
    public class RealtimeDatabaseClient
    {
        private readonly FirebaseClient firebase;

        public RealtimeDatabaseClient()
        {
            this.firebase = new FirebaseClient("https://forceofwillcube.firebaseio.com");
        }

        public List<FowSet> GetAllSetsAsync()
        {
            var sets = this.firebase.Child("Sets").OnceAsync<FowSet>().Result;
            return sets.Select(item => new FowSet
            {
                Id = item.Object.Id,
                Name = item.Object.Name,
                ReleaseDate = item.Object.ReleaseDate
            }).ToList();
        }

        /*
         * public async Task<string> CreateSetAsync(FowSet set)
        {
             var json = JsonConvert.SerializeObject(set);
            var res = await firebase.Child("Sets").PostAsync(json);
            return res.Object;
        }
        */
    }
}
