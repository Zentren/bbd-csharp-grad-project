using Project.Models;
using System;

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

            Pokemon pokemon = new Pokemon(
                record.Number, 
                record.Name, 
                getType(record.Type_1), 
                getType(record.Type_2), 
                record.Description, 
                record.Weight,
                record.Height,
                Convert.ToUInt32(record.Level), 
                Convert.ToUInt32(record.HP), 
                record.Pre_Evolution, 
                record.Evolution, 
                getRarity(record.Status), 
                record.Move1, 
                record.Move2,
                record.Move3, 
                record.Move4, 
                record.Image
            );    

            return pokemon;
        }

        public Rarity getRarity(string rarity) {
            if(string.IsNullOrEmpty(rarity))
                return Rarity.Unknown;

            return (Rarity) Enum.Parse(typeof(Rarity), rarity, true);
        }

        public Type getType(string type) {
            if (string.IsNullOrEmpty(type))
                return Type.Null;

            return (Type) Enum.Parse(typeof(Type), type, true);
        }


    }
}