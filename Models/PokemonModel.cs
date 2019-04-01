using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Project.Data;
using System;

namespace Project.Models {
    public class PokemonModel {
        public PokemonFactory factory;
        public TypeCalculator calculator;
        public Pokemon pokemon;

        public PokemonModel() {
            factory = new PokemonFactory();
            pokemon = null;
        }

        public Pokemon GetPokemonByName(string name) {
            try {
                pokemon = factory.GetPokemonByName(name);
                return pokemon;
            } catch (Exception e) {
                throw e;
            }
        }

        public string[] GetPokemonEffectiveness() {
            string[] effectiveness = new string[2];
            if (pokemon.Type2 == Type.Null) {
                effectiveness[0] = (calculator.getSuperEffectiveAgainst(pokemon.Type1));
                effectiveness[1] = (calculator.getNotVeryEffectiveAgainst(pokemon.Type1));
                effectiveness[2] = (calculator.getTypesImmuneToIt(pokemon.Type1));
            } else { 
                effectiveness[0] = (calculator.getSuperEffectiveAgainst(pokemon.Type1,pokemon.Type2));
                effectiveness[1] = (calculator.getNotVeryEffectiveAgainst(pokemon.Type1,pokemon.Type2));
                effectiveness[2] = (calculator.getTypesImmuneToIt(pokemon.Type1,pokemon.Type2));
            }
            return effectiveness;
        }

    }
}
