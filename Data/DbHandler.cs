using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using System;

namespace Project.Data
{
    public class DbHandler 
    {
        IFirebaseConfig config;
        IFirebaseClient client;
        FirebaseResponse response;

        public DbHandler() {
            config = new FirebaseConfig { AuthSecret = "1wRJbNnc41nM318fYOCLCudiOzL4cLS6pFcSTxMN", BasePath = "https://pokemondatabase-4e361.firebaseio.com/" };
            client = new FireSharp.FirebaseClient(config);
            response = null;
        }

        public async void QueryByName(string name)
        {
            response = await client.GetTaskAsync("Information/" + name.Substring(0,1).ToUpper() + name.Substring(1).ToLower());
        }

        //TODO: Response with number

        public DbRecord GetRecordByName(string name) {
            QueryByName(name);
            while (response == null){}
            try {
                DbRecord record = response.ResultAs<DbRecord>();
                Console.WriteLine(record.Name);
                return record;
            } catch (NullReferenceException e) {
                throw new PokemonRecordNotFoundException("Pokemon does not exist");
            }
        }
    }
}
