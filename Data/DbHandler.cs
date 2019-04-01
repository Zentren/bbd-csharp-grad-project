using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Project.Data
{
    public class DbHandler 
    {
        IFirebaseConfig config;
        IFirebaseClient client;
        FirebaseResponse response;

        public DbHandler() {
            config = new FirebaseConfig { AuthSecret = "zqEswzoN5eplAQUWJC3GNDxsmR7KMKlJNWdu53Rd", BasePath = "https://pokedex-a0400.firebaseio.com" };
            client = new FireSharp.FirebaseClient(config);
            response = null;
        }

        public async void QueryByName(string name)
        {
            response = await client.GetTaskAsync("Information/" + name);
        }

        //TODO: Response with number

        public DbRecord GetRecordByName(string name) {
            QueryByName(name);
            DbRecord record = response.ResultAs<DbRecord>();
            return record;
        }
    }
}