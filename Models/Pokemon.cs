using System;
using System.Collections.Generic;
using System.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Project.Models{
    public class Pokemon{

        IFirebaseConfig config = new FirebaseConfig { AuthSecret = "zqEswzoN5eplAQUWJC3GNDxsmR7KMKlJNWdu53Rd", BasePath = "https://pokedex-a0400.firebaseio.com" };
        IFirebaseClient client;
        public enum Type
        {
            Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
            Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
            Unknown,Null
        }
      public enum Rarity { Common, Uncommon, Rare }
      public enum Move { /* TODO */ }
      public uint number { get; private set; }
      public string name { get; private set; }
      public Type type1 { get; private set; }
      public Type type2 { get; private set; } = Type.Null;
      public string description {get; private set;}
      public double weight {get;private set;}
      public double height {get;private set;}
      public uint level { get; private set; }
      public uint hp { get; private set; }
      private Pokemon evolvesFrom = null;
      public Pokemon evolvesInto = null;
      public Rarity rarity{get;private set;}
     

     public bool firstForm{get;private set;}
     public bool finalForm{get;private set;}
     public Move move1{get;private set;}
     public Move move2{get;private set;}
     public Move move3{get;private set;}
     public Move move4{get;private set;}
     private Type[] types= {Type.Normal,Type.Fighting,Type.Flying,Type.Poison,Type.Ground,Type.Rock,Type.Bug,Type.Ghost,
     Type.Steel,Type.Fire,Type.Water,Type.Grass,Type.Electric,Type.Psychic,Type.Ice,Type.Dragon,Type.Dark,Type.Fairy};
     private double[,] battleChart=new double[,] {{1,1,1,1,1,0.5,1,0,0.5,1,1,1,1,1,1,1,1,1},{2,1,0.5,0.5,1,2,0.5,0,2,1,1,1,1,0.5,2,1,2,0.5},
     {1,2,1,1,1,0.5,2,1,0.5,1,1,2,0.5,1,1,1,1,1},{1,1,1,0.5,0.5,0.5,1,0.5,0,1,1,2,1,1,1,1,1,2},
     {1,1,0,2,1,2,0.5,1,2,2,1,0.5,2,1,1,1,1,1},{1,0.5,2,1,0.5,1,2,1,0.5,2,1,1,1,1,2,1,1,1},
     {1,0.5,0.5,0.5,1,1,1,0.5,0.5,0.5,1,2,1,2,1,1,2,0.5},{0,1,1,1,1,1,1,2,1,1,1,1,1,2,1,1,0.5,1},
     {1,1,1,1,1,2,1,1,0.5,0.5,0.5,1,0.5,1,2,1,1,2},{1,1,1,1,1,0.5,2,1,2,0.5,0.5,2,1,1,2,0.5,1,1},
     {1,1,1,1,2,2,1,1,1,2,0.5,0.5,1,1,1,0.5,1,1},{1,1,0.5,0.5,2,2,0.5,1,0.5,0.5,2,0.5,1,1,1,0.5,1,1},
     {1,1,2,1,0,1,1,1,1,1,2,0.5,0.5,1,1,0.5,1,1},{1,2,1,2,1,1,1,1,0.5,1,1,1,1,0.5,1,1,0,1},
     {1,1,2,1,2,1,1,1,0.5,0.5,0.5,2,1,1,0.5,2,1,1},{1,1,1,1,1,1,1,1,0.5,1,1,1,1,1,1,2,1,0},
     {1,0.5,1,1,1,1,1,2,1,1,1,1,1,2,1,1,0.5,0.5},{1,2,1,0.5,1,1,1,1,0.5,0.5,1,1,1,1,1,2,2,1}};
         
     public Type[] weaknesses{ get; private set; }
     public Type[] strengths{ get; private set; }
     public string url { get; private set; }

    public Pokemon(string name)
        {
            this.name = name;
            url = this.name + ".jpg";
            client = new FireSharp.FirebaseClient(config);
            //get imfo from database
        }
    public Pokemon(uint number)
        {
            this.number = number;
            url = name + ".jpg";
            client = new FireSharp.FirebaseClient(config);
            //get imfo from database
        }


    public void evolve(){
         if(finalForm){
             evolvesInto = null;
         }else evolvesInto = new Pokemon(number+1);
    }

    public void devolve(){
         if(finalForm){
             evolvesFrom = null;
         } else evolvesFrom = new Pokemon(number-1);
    }

    public void strengthsAndWeaknesses() {
            strengths = setStrengths();
            List<Type> w=setWeaknesses();
            if (type2 != Type.Null) {
                int i = Array.IndexOf(types, type1);
                int j = Array.IndexOf(types, type2);
                for (int k = 0; k < w.ToArray().Length; k++) {
                    int m = Array.IndexOf(types, w[k]);
                    if (battleChart[m, i] < 2 || battleChart[m, j] < 2)
                        w.RemoveAt(k);
                }
            }
            weaknesses = w.ToArray();

    }

    public List<Type> setWeaknesses() {
            List<Type> tmp = new List<Type>();
            int i = Array.IndexOf(types, type1);
            for (int j = 0; j < 18; j++)
                if (battleChart[i, j]>1)
                    tmp.Add(types[j]);
            if (type2 != Type.Null)
            {
                i = Array.IndexOf(types, type2);
                for (int j = 0; j < 18; j++)
                    if (battleChart[i, j] > 1)
                        tmp.Add(types[j]);
            }
           tmp = tmp.Distinct().ToList();
           return tmp;
     }
        public Type[] setStrengths() {
            List<Type> tmp = new List<Type>();
            int i = Array.IndexOf(types, type1);
            for (int j = 0; j < 18; j++)
                if (battleChart[i, j] > 1)
                    tmp.Add(types[j]);

            if (type2 != Type.Null)
            {
                i = Array.IndexOf(types, type2);
                for (int j = 0; j < 18; j++)
                    if (battleChart[i, j] > 1)
                        tmp.Add(types[j]);
            }
            tmp = tmp.Distinct().ToList();
            return tmp.ToArray();
     }

    }
}