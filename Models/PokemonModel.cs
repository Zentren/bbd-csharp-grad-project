using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Project.Data;

namespace Project.Models {
    public class PokemonModel {
        TypeCalculator calc = new TypeCalculator();
        PokemonFactory factory = new PokemonFactory();
        // Pokemon pokemon;

        public PokemonModel() {
            // pokemon = null;
        }

        public Pokemon GetPokemonByName(string name) {
            return factory.GetPokemonByName(name);
        }

    }

    }
