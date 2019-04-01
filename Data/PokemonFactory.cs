using Project.Models;

namespace Project.Data
{
    public class PokemonFactory
    {
        DbHandler handler;
        public PokemonFactory() {
            handler = new DbHandler();
        }

        public Pokemon GetPokemonByName(string name) {
            DbRecord record = handler.GetRecordByName(name);
            Pokemon pokemon = new Pokemon();    
            return pokemon;
        }


    }
}