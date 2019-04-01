using System;
using System.Collections.Generic;
using System.Linq;
//using System.Speech.Synthesis;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;

namespace Project.Models{
    public class Pokemon : IPokemon {

        //IFirebaseConfig config = new FirebaseConfig { AuthSecret = "zqEswzoN5eplAQUWJC3GNDxsmR7KMKlJNWdu53Rd", BasePath = "https://pokedex-a0400.firebaseio.com" };
        //IFirebaseClient client;
        //FirebaseResponse response = null;

        // public enum Type
        // {
        //     Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
        //     Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
        //     Null
        // }
      public enum Rarity { Common, Uncommon, Rare,Unknown };
      public uint Number { get; private set; }
      public string Name { get; private set; }
      public Type Type1 { get; private set; }
      public Type Type2 { get; private set; } = Type.Null;
      public string Description {get; private set;}
      public double Weight {get;private set;}
      public double Height {get;private set;}
      public uint Level { get; private set; }
      public uint Hp { get; private set; }

      public string Pre_Evolution { get; private set; }
      public string Evolution { get; private set; }
      public Rarity RarityOf{get;private set;}
     
     public string move1{get;private set;}
     public string move2{get;private set;}
     public string move3{get;private set;}
     public string move4{get;private set;}
    // private Rarity[] rarities = { Rarity.Common, Rarity.Rare, Rarity.Uncommon, Rarity.Unknown }; 
     public Type[] Weaknesses{ get; private set; }
     public Type[] Strengths{ get; private set; }
     public string Image { get; private set; }
    public double IV { get; private set; }


    //public async void Resp(string name) {
      //      this.response=await client.GetTaskAsync("Information/" + name);
     //   }

    /*public void setStrengths(List<Type> tmp)
       {
            this.Strengths = tmp.ToArray();
        }

        public void setWeakness(List<Type> tmp) {
            this.Weaknesses = tmp.ToArray();
        }*/

     public double getIV(){
        Random random = new Random();  
        int attack = random.Next(1, 15); 
        int defense = random.Next(1, 15); 
        return((Convert.ToInt32(this.Hp)+attack+defense)/45);
     }

     public Rarity getRarity(string rarity) {
         if(string.IsNullOrEmpty(rarity))
         return Rarity.Unknown;
         return (Rarity) Enum.Parse(typeof(Rarity), rarity, true);
     }
     public Type getType(string type) {
            // for (int i = 0; i < types.Length-1; i++) {
            //     if (Enum.GetName(typeof(Type), i) == type)
            //         return types[i];
            // }

            if (string.IsNullOrEmpty(type))
                return Type.Null;

            return (Type) Enum.Parse(typeof(Type), type, true);
        }

      public Pokemon(Data obj) {
            this.Name = obj.Name;
            this.Number = Convert.ToUInt32(obj.Number);
            this.Image = obj.Image;
            this.Type1 = getType(obj.Type_1);
            this.Type2 = getType(obj.Type_2);
            this.move1 = obj.Move1;
            this.move2 = obj.Move2;
            this.move3 = obj.Move3;
            this.move4 = obj.Move4;
            this.Description = obj.Description;
            this.Weight = Convert.ToUInt32(obj.Weight);
            this.Height = Convert.ToUInt32(obj.Height);
            this.Level = Convert.ToUInt32(obj.Level);
            this.Hp = Convert.ToUInt32(obj.HP);
            this.Pre_Evolution = obj.Pre_Evolution;
            this.Evolution = obj.Evolution;
            this.RarityOf = getRarity(obj.Status);
            this.IV = getIV();
        }

        public void setStrengths(string[] str) {
            this.Strengths = new Type[str.Length];
            for(int i=0;i<str.Length;i++)
                this.Strengths[i]= (Type)Enum.Parse(typeof(Type), str[i], true);

        }

        public void setWeaknesses(string[] str)
        {
            this.Weaknesses = new Type[str.Length];
            for (int i = 0; i < str.Length; i++)
                this.Weaknesses[i] = (Type)Enum.Parse(typeof(Type), str[i], true);

        }
        /* public Pokemon(string name)
             {
                 client = new FireSharp.FirebaseClient(config);
                 Resp(name);
                 Data obj = response.ResultAs<Data>();
                 this.name = obj.Name;
                 this.number = obj.Number;
                 this.Image = obj.Image;
                 this.type1 = getType(obj.Type_1);
                 this.type2 = getType(obj.Type_2);
                 this.move1 = obj.Move1;
                 this.move2 = obj.Move2;
                 this.move3 = obj.Move3;
                 this.move4 = obj.Move4;
                 this.description = obj.Description;
                 this.weight = obj.Weight;
                 this.height = obj.Height;
                 this.level = obj.Level;
                 this.hp = obj.HP;
                 this.Pre_Evolution = obj.Pre_Evolution;
                 this.Evolution = obj.Evolution;
                 this.rarity = getRarity(obj.Status);
                 //strengthsAndWeaknesses();
         }*/

        // public infoToSpeech(){
        //     SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        //         synthesizer.Volume = 100;  // 0...100
        //         synthesizer.Rate = -2;     // -10...10

        //         // Synchronous
        //         synthesizer.Speak(this.name);

        //         synthesizer.Speak("Pokedex number "+this.number.ToString());

        //         synthesizer.Speak("Type "+this.type);
        //         // Asynchronous
        //         synthesizer.SpeakAsync(this.description);
        // }

        //  public Pokemon evolve() {
        //         return new Pokemon(Data Evo);
        //     }

        //  public Pokemon devolve() {
        //         return new Pokemon(Data Pre);
        //     }

        // public void strengthsAndWeaknesses() {
        //         strengths = setStrengths();
        //         List<Type> w=setWeaknesses();
        //         if (type2 != Type.Null) {
        //             int i = Array.IndexOf(types, type1);
        //             int j = Array.IndexOf(types, type2);
        //             for (int k = 0; k < w.ToArray().Length; k++) {
        //                 int m = Array.IndexOf(types, w[k]);
        //                 if (battleChart[m, i] < 2 || battleChart[m, j] < 2)
        //                     w.RemoveAt(k);
        //             }
        //         }
        //         weaknesses = w.ToArray();

        // }

        // public List<Type> setWeaknesses() {
        //         List<Type> tmp = new List<Type>();
        //         int i = Array.IndexOf(types, type1);
        //         for (int j = 0; j < 18; j++)
        //             if (battleChart[i, j]>1)
        //                 tmp.Add(types[j]);
        //         if (type2 != Type.Null)
        //         {
        //             i = Array.IndexOf(types, type2);
        //             for (int j = 0; j < 18; j++)
        //                 if (battleChart[i, j] > 1)
        //                     tmp.Add(types[j]);
        //         }
        //        tmp = tmp.Distinct().ToList();
        //        return tmp;
        //  }
        //     public Type[] setStrengths() {
        //         List<Type> tmp = new List<Type>();
        //         int i = Array.IndexOf(types, type1);
        //         for (int j = 0; j < 18; j++)
        //             if (battleChart[i, j] > 1)
        //                 tmp.Add(types[j]);

        //         if (type2 != Type.Null)
        //         {
        //             i = Array.IndexOf(types, type2);
        //             for (int j = 0; j < 18; j++)
        //                 if (battleChart[i, j] > 1)
        //                     tmp.Add(types[j]);
        //         }
        //         tmp = tmp.Distinct().ToList();
        //         return tmp.ToArray();
        //  }

    }

}