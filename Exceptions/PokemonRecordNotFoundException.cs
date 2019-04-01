using System;

public class PokemonRecordNotFoundException : Exception
{
   public PokemonRecordNotFoundException(string message)
      : base(message)
   {
   }
}