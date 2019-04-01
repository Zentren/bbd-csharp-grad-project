using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Project.Models {
    public class PokemonModel {
        IFirebaseConfig config = new FirebaseConfig { AuthSecret = "zqEswzoN5eplAQUWJC3GNDxsmR7KMKlJNWdu53Rd", BasePath = "https://pokedex-a0400.firebaseio.com" };
        IFirebaseClient client;
        FirebaseResponse response = null;
        TypeCalculator calc = new TypeCalculator();

        public async void Resp(string name)
        {
            response=await client.GetTaskAsync("Information/" + name);
        }

        public Pokemon poke(string name) {
            client = new FireSharp.FirebaseClient(config);
            Resp(name);
            Data obj = response.ResultAs<Data>();
            Pokemon tmp = new Pokemon(obj);
            string strengths = calc.getSuperEffectiveAgainst(tmp.Type1, tmp.Type2);
            string[] s = strengths.Split(" ");
            string weakness = calc.getTypesSuperEffectiveAgainst(tmp.Type1, tmp.Type2);
            string[] w = weakness.Split(" ");
            tmp.setStrengths(s);
            tmp.setWeaknesses(w);
            return tmp;
        }


    }

    }
