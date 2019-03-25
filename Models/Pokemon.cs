using System;

namespace Project.Models
{
    public abstract class Pokemon : IPokemon
    {
        public enum Type
        {
            Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
            Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy,
            Unknown
        }

        public enum Rarity { Common, Uncommon, Rare }

        public enum Move { /* TODO */ }

        public uint Number { get; private set; }
        public string Name { get; private set; }
        public Type PrimaryType { get; private set; }
        public Type SecondaryType { get; private set; }
        public string Description { get; private set; }
        public double Weight { get; private set; }
        public double Height { get; private set; }
        public uint Level { get; private set; }
        public uint Hp { get; private set; }
        public IPokemon EvolvesFrom { get; private set; }
        public IPokemon EvolvesInto { get; private set; }
        public Rarity RarityOf { get; private set; }
    }
}