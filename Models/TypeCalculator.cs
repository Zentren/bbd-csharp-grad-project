/* 
    --POKEMON TYPE CLASS--

    Functions::
        For given single types and dual types:
            List types it is super effective against
            List types super effective against it
            List types it is not very effective against
            List types not very effectuve against it
            List types it is immune to 
            List types immune to it

        Calculate Effeciveness modifier between:
            Two single types
            A single type against a dual type
        (less usefull, as these modifiers would only be used in an attack which can only be of a single type:)
            Dual type against a single type
            Dual type against a dual type

        Combine Effectiveness of two different types to create a new list of the combined effectiveness ratings

    Example Usage::
        Console.WriteLine("Meet Blaziken!");
        Type Type1 = Type.Fire;
        Type Type2 = Type.Fighting;
        Console.WriteLine($"Type: {Type1} and {Type2} pokemon \n");
        Console.WriteLine("Super effective against: " + TypeController.getSuperEffectiveAgainst(Type1, Type2));
        Console.WriteLine("Not very effective against: " + TypeController.getNotVeryEffectiveAgainst(Type1, Type2));
        Console.WriteLine("Types immune to it: " + TypeController.getTypesImmuneToIt(Type1, Type2));
        Console.WriteLine("Types super effective against it: " + TypeController.getTypesSuperEffectiveAgainst(Type1, Type2));
        Console.WriteLine("Types not very effective against it: " + TypeController.getTypesNotVeryEffectiveAgainst(Type1, Type2));
        Console.WriteLine("Types it is immune to : " + TypeController.getImmuneTo(Type1, Type2));

        Console.WriteLine("\nMeet Pidgy!");
        Type Type3 = Type.Ghost;
        Console.WriteLine($"Type: {Type3} pokemon \n");
        Console.WriteLine("Super effective against: " + TypeController.getSuperEffectiveAgainst(Type3));
        Console.WriteLine("Not very effective against: " + TypeController.getNotVeryEffectiveAgainst(Type3));
        Console.WriteLine("Types immune to it: " + TypeController.getTypesImmuneToIt(Type3));
        Console.WriteLine("Types super effective against it: " + TypeController.getTypesSuperEffectiveAgainst(Type3));
        Console.WriteLine("Types not very effective against it: " + TypeController.getTypesNotVeryEffectiveAgainst(Type3));
        Console.WriteLine("Types it is immune to : " + TypeController.getImmuneTo(Type3));

        Console.WriteLine("\nType Multipliers!");
        Console.WriteLine(Type.Ghost + " type attacks " + Type.Fighting + " type with a x" + TypeController.getEffectivenessAgainst(Type.Ghost, Type.Fighting));
        Console.WriteLine(Type.Ghost + " type attacks " + Type.Normal + " type with a x" + TypeController.getEffectivenessAgainst(Type.Ghost, Type.Normal));
        Console.WriteLine(Type.Fighting  + " type attacks " + Type.Normal + " and "+ Type.Ghost + " type with a x" + TypeController.getEffectivenessAgainstDualType(Type.Fighting, Type.Steel, Type.Normal));
        
*/
using System.Collections.Generic;
using System;
using System.Text;

namespace Project.Models
{
    public class TypeCalculator
        {
            /* 
                Class Constructor
            */
            public TypeCalculator()
            {
                Populate();
            }

            /* 
                Dictionary of Pokemon Type Effectiveness
            */
            public static Dictionary<Type, float[]> Effectiveness = new Dictionary<Type, float[]>();

            /* 
                Populate Pokemon Type Effectiveness Dictionary
            */
            private static void Populate()
            {
                Effectiveness.Add(Type.Normal, new float[] { 1, 1, 1, 1, 1, 0.5F, 1, 0, 0.5F, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                Effectiveness.Add(Type.Fighting, new float[] { 2, 1, 0.5F, 0.5F, 1, 2, 0.5F, 0, 2, 1, 1, 1, 1, 0.5F, 2, 1, 2, 0.5F });
                Effectiveness.Add(Type.Flying, new float[] { 1, 2, 1, 1, 1, 0.5F, 2, 1, 0.5F, 1, 1, 2, 0.5F, 1, 1, 1, 1, 1 });
                Effectiveness.Add(Type.Poison, new float[] { 1, 1, 1, 0.5F, 0.5F, 0.5F, 1, 0.5F, 0, 1, 1, 2, 1, 1, 1, 1, 1, 2 });
                Effectiveness.Add(Type.Ground, new float[] { 1, 1, 0, 2, 1, 2, 0.5F, 1, 2, 2, 1, 0.5F, 2, 1, 1, 1, 1, 1 });
                Effectiveness.Add(Type.Rock, new float[] { 1, 0.5F, 2, 1, 0.5F, 1, 2, 1, 0.5F, 2, 1, 1, 1, 1, 2, 1, 1, 1 });
                Effectiveness.Add(Type.Bug, new float[] { 1, 0.5F, 0.5F, 0.5F, 1, 1, 1, 0.5F, 0.5F, 0.5F, 1, 2, 1, 2, 1, 1, 2, 0.5F });
                Effectiveness.Add(Type.Ghost, new float[] { 0, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0.5F, 1 });
                Effectiveness.Add(Type.Steel, new float[] { 1, 1, 1, 1, 1, 2, 1, 1, 0.5F, 0.5F, 0.5F, 1, 0.5F, 1, 2, 1, 1, 2 });
                Effectiveness.Add(Type.Fire, new float[] { 1, 1, 1, 1, 1, 0.5F, 2, 1, 2, 0.5F, 0.5F, 2, 1, 1, 2, 0.5F, 1, 1 });
                Effectiveness.Add(Type.Water, new float[] { 1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 0.5F, 0.5F, 1, 1, 1, 0.5F, 1, 1 });
                Effectiveness.Add(Type.Grass, new float[] { 1, 1, 0.5F, 0.5F, 2, 2, 0.5F, 1, 0.5F, 0.5F, 2, 0.5F, 1, 1, 1, 0.5F, 1, 1 });
                Effectiveness.Add(Type.Electric, new float[] { 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 2, 0.5F, 0.5F, 1, 1, 0.5F, 1, 1 });
                Effectiveness.Add(Type.Psychic, new float[] { 1, 2, 1, 2, 1, 1, 1, 1, 0.5F, 1, 1, 1, 1, 0.5F, 1, 1, 0, 1 });
                Effectiveness.Add(Type.Ice, new float[] { 1, 1, 2, 1, 2, 1, 1, 1, 0.5F, 0.5F, 0.5F, 2, 1, 1, 0.5F, 2, 1, 1 });
                Effectiveness.Add(Type.Dragon, new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 0.5F, 1, 1, 1, 1, 1, 1, 2, 1, 0 });
                Effectiveness.Add(Type.Dark, new float[] { 1, 0.5F, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0.5F, 0.5F });
                Effectiveness.Add(Type.Fairy, new float[] { 1, 2, 1, 0.5F, 1, 1, 1, 1, 0.5F, 0.5F, 1, 1, 1, 1, 1, 2, 2, 1 });
            }

            /*
                Return string of Pokemon Types which the given
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
                will be super effective against
            */

            public String getSuperEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[Type1][i] == 2)
                    {
                        sb.Append(((Type)i).ToString());

                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }
            public string Shorten(string sb)
            {

                int startIndex = 0;    
                int endIndex = sb.ToString().Length - 1;    
                string Reduced = sb.ToString().Substring(startIndex, endIndex);    
               return Reduced;
            }
            public String getSuperEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < 18; i++)
                {
                    if (CombinedEffectiveness[i] >= 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            /*
                Return string of Pokemon Types which are super effective against the given:
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesSuperEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            public String getTypesSuperEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] >= 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            /*
                Return string of Pokemon Types which the given
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
                will not be very effective against
            */

            public String getNotVeryEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[Type1][i] == 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            public String getNotVeryEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < 18; i++)
                {
                    if (CombinedEffectiveness[i] <= 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            /*
                Return string of Pokemon Types which are not very effective against the given
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesNotVeryEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            public String getTypesNotVeryEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] <= 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            /*
                Return string of Pokemon Types which are IMMUNE to the given: 
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesImmuneToIt(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[Type1][i] == 0)
                        sb.Append(((Type)i).ToString());
                }
                return sb.ToString();
            }

            public String getTypesImmuneToIt(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < 18; i++)
                {
                    if (CombinedEffectiveness[i] == 0)
                        sb.Append(((Type)i).ToString());
                }
                return sb.ToString();
            }

            /*
                Return string of Pokemon Types which the given type is immune to
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getImmuneTo(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 0)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            public String getImmuneTo(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 18; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] == 0)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
            }

            /*
                For determining the effectiveness multiplier between specific types
                    1. Between two single type pokemon
                    2. Between a single type and a dual type pokemon
                    3. Between a dual type and a single type pokemon
                    4. Between two double type pokemon        
            */
            public float getEffectivenessAgainst(Type Type1, Type EffectiveAgainst)
            {
                return Effectiveness[Type1][(int)EffectiveAgainst];
            }

            public float getEffectivenessAgainstDualType(Type Type1, Type EffectiveAgainst1, Type EffectiveAgainst2)
            {
                return Effectiveness[Type1][(int)EffectiveAgainst1] * Effectiveness[Type1][(int)EffectiveAgainst2];
            }

            public float getDualTypeEffectivenessAgainst(Type Type1, Type Type2, Type EffectiveAgainst)
            {
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);
                return CombinedEffectiveness[(int)EffectiveAgainst];
            }

            public float getEffectivenessAgainst(Type Type1, Type Type2, Type EffectiveAgainst1, Type EffectiveAgainst2)
            {
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);
                return CombinedEffectiveness[(int)EffectiveAgainst1] * CombinedEffectiveness[(int)EffectiveAgainst2];
            }

            /* 
                Calculate effectiveness list for dual type pokemon
            */

            public float[] CombineEffectiveness(Type type1, Type type2)
            {
                float[] PokemonEffectivenes = new float[18];
                for (int i = 0; i < 18; i++)
                {
                    PokemonEffectivenes[i] = Effectiveness[type1][i] * Effectiveness[type2][i];
                }
                return PokemonEffectivenes;
            }

        }


}