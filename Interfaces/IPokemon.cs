using Project.Models;

namespace Project.interfaces
{
    public interface IPokemon
    {
        /* TODO: Methods to make Pokemon *do stuff*
         * If and when we do, we should have a Factory which creates IPokemon
         * instances using info from the DB. Can base off Pokemon abstract class
         * to provide common functionality.
         */ 

        // Get Pokemon basic info:
        string Number { get; }
        string Name { get; }
        Type Type1 { get; }
        Type Type2 { get; }
        string Description { get; }
        string Weight { get; }
        string Height { get; }
        uint Level { get; }
        uint Hp { get; }
        string PreEvolution{ get; }
        string Evolution{ get; }
        Rarity RarityOf { get; }
        string Image { get;}
    }
}