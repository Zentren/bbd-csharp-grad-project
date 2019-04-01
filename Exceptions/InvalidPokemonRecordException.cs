using System;

public class InvalidPokemonRecordException : Exception
{
   public InvalidPokemonRecordException(string message)
      : base(message)
   {
   }
}