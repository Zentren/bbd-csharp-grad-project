using System;

namespace Project.Models{
    public abstract class Pokemon : IPokemon{
      public enum Type
        {
            Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
            Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
            Unknown
        }
      public enum Rarity { Common, Uncommon, Rare }
      public enum Move { /* TODO */ }
      public uint number { get; private set; }
      public string name { get; private set; }
      public Type type1 { get; private set; }
      public Type type2 { get; private set; }
      public string description {get; private set;}
      public double weight {get;private set;}
      public double height {get;private set;}
      public uint level { get; private set; }
      public uint hp { get; private set; }
      public IPokemon evolvesFrom{get;}
      public IPokemon evolvesInto{get;}
      public Rarity rarity{get;private set;}
      public IPokemon(string name){
        this.name=name;
        //get imfo from database
     }
      public IPokemon(int number){
         this.number=number;
         //get imfo from database
     }
     public Image image{get;}=null;
     public bool firstForm{get;private set;}
     public bool finalForm{get;private set;}
     public Move move1{get;private set;}
     public Move move2{get;private set;}
     public Move move3{get;private set;}
     public Move move4{get;private set;}
     public Type[] weaknesses{get;}
     public Type[] strengths{get;}
     public void setImage(string url){
         this.image = Image.FromFile(url);
     }

     public void evolve(){
         if(this.finalForm){
             this.evolvesInto = null;
         }else this.evolvesInto = new IPokemon(this.number+1);
     }
     public void devolve(){
         if(this.finalForm){
             this.evolvesFrom = null;
         } else this.evolvesFrom = new IPokemon(this.number-1);
     }
     public void setWeaknesses(){
         return;
     }
     public void setStrengths(){
         return;
     }

    }
}