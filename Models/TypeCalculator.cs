using System.Collections.Generic;
using System;
using System.Text;

namespace Project.Models
{
    public class TypeCalculator
        {
            private const int NumberOfTypes = 18;
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
            public static Dictionary<Type, float[]> Effectiveness = null;

            /* 
                Populate Pokemon Type Effectiveness Dictionary
            */
            private static void Populate()
            {
                if (Effectiveness != null) return;
                
                Effectiveness = new Dictionary<Type, float[]>();
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
                for (int i = 0; i < NumberOfTypes; i++)
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
            if (Type2 == Type.Null)
                return getSuperEffectiveAgainst(Type1);
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (CombinedEffectiveness[i] >= 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            /*
                Return string of Pokemon Types which are super effective against the given:
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesSuperEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            public String getTypesSuperEffectiveAgainst(Type Type1, Type Type2)
            {
            if (Type2 == Type.Null)
                return getTypesSuperEffectiveAgainst(Type1);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] >= 2)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
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
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[Type1][i] == 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            public String getNotVeryEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (CombinedEffectiveness[i] <= 0.5F)
                    {
                        if (((Type)i!=Type1) || ((Type)i!=Type2)) {
                            sb.Append(((Type)i).ToString());
                            sb.Append(" ");
                        }
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            /*
                Return string of Pokemon Types which are not very effective against the given
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesNotVeryEffectiveAgainst(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            public String getTypesNotVeryEffectiveAgainst(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] <= 0.5F)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            /*
                Return string of Pokemon Types which are IMMUNE to the given: 
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getTypesImmuneToIt(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[Type1][i] == 0)
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                }
                // var check = Shorten(sb.ToString());
                // return check;
                return sb.ToString();
            }

            public String getTypesImmuneToIt(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                float[] CombinedEffectiveness = CombineEffectiveness(Type1, Type2);

                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (CombinedEffectiveness[i] == 0) {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            /*
                Return string of Pokemon Types which the given type is immune to
                    1. Single Type Pokemon
                    2. Dual Type Pokemon
            */

            public String getImmuneTo(Type Type1)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] == 0)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
            }

            public String getImmuneTo(Type Type1, Type Type2)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    if (Effectiveness[(Type)i][(int)Type1] * Effectiveness[(Type)i][(int)Type2] == 0)
                    {
                        sb.Append(((Type)i).ToString());
                        sb.Append(" ");
                    }
                }
                var check = Shorten(sb.ToString());
                return check;
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
                float[] PokemonEffectivenes = new float[NumberOfTypes];
                for (int i = 0; i < NumberOfTypes; i++)
                {
                    PokemonEffectivenes[i] = Effectiveness[type1][i] * Effectiveness[type2][i];
                }
                return PokemonEffectivenes;
            }

        }


}