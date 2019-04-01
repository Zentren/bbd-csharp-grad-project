using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Project.Data;

namespace Project.Models {
    public class PokemonModel {
        TypeCalculator calc;
        PokemonFactory factory;
        // Pokemon pokemon;

        public PokemonModel() {
            calc = new TypeCalculator();
            factory = new PokemonFactory();
        }

        public Pokemon GetPokemonByName(string name) {
            return factory.GetPokemonByName(name);
        }

    }

    }
