using System;
using System.Collections.Generic;
using System.Linq;
//using System.Speech.Synthesis;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;

namespace Project.Models{
    public class Pokemon{

        IFirebaseConfig config = new FirebaseConfig { AuthSecret = "zqEswzoN5eplAQUWJC3GNDxsmR7KMKlJNWdu53Rd", BasePath = "https://pokedex-a0400.firebaseio.com" };
        IFirebaseClient client;
        FirebaseResponse response = null;

        public enum Type
        {
            Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
            Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
            Null
        }
      public enum Rarity { Common, Uncommon, Rare,Unknown };
      public string number { get; private set; }
      public string name { get; private set; }
      public Type type1 { get; private set; }
      public Type type2 { get; private set; } = Type.Null;
      public string description {get; private set;}
      public string weight {get;private set;}
      public string height {get;private set;}
      public string level { get; private set; }
      public string hp { get; private set; }
      private Pokemon evolvesFrom{get; set;} = null;
      public Pokemon evolvesInto{get; set;} = null;
      public string Pre_Evolution { get; private set; }
      public string Evolution { get; private set; }
      public Rarity rarity{get;private set;}
     
     public string move1{get;private set;}
     public string move2{get;private set;}
     public string move3{get;private set;}
     public string move4{get;private set;}
     private Rarity[] rarities = { Rarity.Common, Rarity.Rare, Rarity.Uncommon, Rarity.Unknown };
     private Type[] types= {Type.Normal,Type.Fighting,Type.Flying,Type.Poison,Type.Ground,Type.Rock,Type.Bug,Type.Ghost,
     Type.Steel,Type.Fire,Type.Water,Type.Grass,Type.Electric,Type.Psychic,Type.Ice,Type.Dragon,Type.Dark,Type.Fairy};
    //  private double[,] battleChart=new double[,] {{1,1,1,1,1,0.5,1,0,0.5,1,1,1,1,1,1,1,1,1},{2,1,0.5,0.5,1,2,0.5,0,2,1,1,1,1,0.5,2,1,2,0.5},
    //  {1,2,1,1,1,0.5,2,1,0.5,1,1,2,0.5,1,1,1,1,1},{1,1,1,0.5,0.5,0.5,1,0.5,0,1,1,2,1,1,1,1,1,2},
    //  {1,1,0,2,1,2,0.5,1,2,2,1,0.5,2,1,1,1,1,1},{1,0.5,2,1,0.5,1,2,1,0.5,2,1,1,1,1,2,1,1,1},
    //  {1,0.5,0.5,0.5,1,1,1,0.5,0.5,0.5,1,2,1,2,1,1,2,0.5},{0,1,1,1,1,1,1,2,1,1,1,1,1,2,1,1,0.5,1},
    //  {1,1,1,1,1,2,1,1,0.5,0.5,0.5,1,0.5,1,2,1,1,2},{1,1,1,1,1,0.5,2,1,2,0.5,0.5,2,1,1,2,0.5,1,1},
    //  {1,1,1,1,2,2,1,1,1,2,0.5,0.5,1,1,1,0.5,1,1},{1,1,0.5,0.5,2,2,0.5,1,0.5,0.5,2,0.5,1,1,1,0.5,1,1},
    //  {1,1,2,1,0,1,1,1,1,1,2,0.5,0.5,1,1,0.5,1,1},{1,2,1,2,1,1,1,1,0.5,1,1,1,1,0.5,1,1,0,1},
    //  {1,1,2,1,2,1,1,1,0.5,0.5,0.5,2,1,1,0.5,2,1,1},{1,1,1,1,1,1,1,1,0.5,1,1,1,1,1,1,2,1,0},
    //  {1,0.5,1,1,1,1,1,2,1,1,1,1,1,2,1,1,0.5,0.5},{1,2,1,0.5,1,1,1,1,0.5,0.5,1,1,1,1,1,2,2,1}};
         
     public Type[] weaknesses{ get; private set; }
     public Type[] strengths{ get; private set; }
     public string Image { get; private set; }


    public async void Resp(string name) {
            this.response=await client.GetTaskAsync("Information/" + name);
        }

    public double getIV(){
        Random random = new Random();  
        int attack = random.Next(1, 15); 
        int defense = random.Next(1, 15); 
        return((Convert.ToInt32(this.hp)+attack+defense)/45);
    }

    public Rarity getRarity(string rarity) {
            for (int i = 0; i < rarities.Length - 1; i++)
                if (Enum.GetName(typeof(Rarity), i) == rarity)
                    return rarities[i];
            return Rarity.Unknown;
     }
    public Type getType(string type) {
            for (int i = 0; i < types.Length-1; i++) {
                if (Enum.GetName(typeof(Type), i) == type)
                    return types[i];
            }
            return Type.Null;
        }
    public Pokemon(string name)
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
    }

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
    public Pokemon evolve() {
            return new Pokemon(this.Evolution);
        }

    public Pokemon devolve() {
            return new Pokemon(this.Pre_Evolution);
        }

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