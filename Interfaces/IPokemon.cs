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
        Type Type1 { get; }
        Type Type2 { get; }
        string Description { get; }
        double Weight { get; }
        double Height { get; }
        uint Level { get; }
        uint Hp { get; }
        string PreEvolution{ get; }
        string Evolution{ get; }
        Rarity RarityOf { get; }
        string Image { get;}
        // Type[] Weaknesses{ get;}
        // Type[] Strengths{ get;}
    }
}