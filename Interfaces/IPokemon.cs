namespace Project.Models
{
    public interface IPokemon
    {
        /* TODO: Methods to make Pokemon *do stuff*
         * If and when we do, we should have a Factory which creates IPokemon
         * instances using info from the DB. Can base off Pokemon abstract class
         * to provide common functionality.
         */ 

        // Get Pokemon basic info:
        uint Number { get; }
        string Name { get; }
        Pokemon.Type PrimaryType { get; }
        Pokemon.Type SecondaryType { get; }
        string Description { get; }
        double Weight { get; }
        double Height { get; }
        uint Level { get; }
        uint Hp { get; }
        IPokemon EvolvesFrom { get; }
        IPokemon EvolvesInto { get; }
        Pokemon.Rarity RarityOf { get; }
    }
}