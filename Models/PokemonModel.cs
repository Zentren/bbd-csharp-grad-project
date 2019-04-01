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
            Pokemon obj = factory.GetPokemonByName(name);
            string s = calc.getSuperEffectiveAgainst(obj.Type1, obj.Type2);
            string w = calc.getTypesSuperEffectiveAgainst(obj.Type1, obj.Type2);
            obj.setStrengths(s.Split(" "));
            obj.setWeaknesses(s.Split(" "));
            return factory.GetPokemonByName(name);
        }

    }

    }
