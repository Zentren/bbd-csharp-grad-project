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
            Pokemon obj = factory.GetPokemonByName(name);
            // obj.Strengths = calc.getSuperEffectiveAgainst(obj.Type1, obj.Type2);
            // obj.Weaknesses = calc.getTypesSuperEffectiveAgainst(obj.Type1, obj.Type2);
            return factory.GetPokemonByName(name);
        }

    }

    }
