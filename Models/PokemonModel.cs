using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Project.Data;
using System;

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
            try {
                // Pokemon obj = factory.GetPokemonByName(name);
                // string s = calc.getSuperEffectiveAgainst(obj.Type1, obj.Type2);
                // string w = calc.getTypesSuperEffectiveAgainst(obj.Type1, obj.Type2);
                return factory.GetPokemonByName(name);
            } catch (Exception e) {
                throw e;
            }
        }

    }

    }
