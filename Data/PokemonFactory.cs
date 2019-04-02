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
                CheckNull(record.Number, "Number"), 
                CheckNull(record.Name, "Name"), 
                GetType(record.Type_1,true), 
                GetType(record.Type_2), 
                CheckNull(record.Description, "Description"), 
                CheckNull(record.Weight, "Weight"),
                CheckNull(record.Height, "Height"),
                CheckNullInt(record.Level,"Level"), 
                CheckNullInt(record.HP, "HP"), 
                record.Pre_Evolution, 
                record.Evolution, 
                GetRarity(record.Status), 
                CheckNull(record.Move1, "Move 1"), 
                record.Move2,
                record.Move3, 
                record.Move4, 
                CheckNull(record.Image, "Image")
            );    

            return pokemon;
        }

        private Rarity GetRarity(string rarity) {
            try {
                return (Rarity) Enum.Parse(typeof(Rarity), rarity, true);
            } catch (ArgumentException e) {
                return Rarity.Unknown;
            }
        }

        private Type GetType(string type, bool required=false) {
            try {
                return (Type) Enum.Parse(typeof(Type), type, true);
            } catch (ArgumentException e) {
                if (!required) {
                    return Type.Null;
                }
                throw new InvalidPokemonRecordException("Record found with invalid Type");
            }
        }

        private string CheckNull(string fieldContent, string fieldName) {
            if (string.IsNullOrEmpty(fieldContent))
                throw new InvalidPokemonRecordException("Record found with invalid field: " + fieldName);
            else return fieldContent;
        }

        private uint CheckNullInt(string fieldContent, string fieldName) {
            if (string.IsNullOrEmpty(fieldContent))
                throw new InvalidPokemonRecordException("Record found with invalid field: " + fieldName);
            else return Convert.ToUInt32(fieldContent);
        }


    }
}