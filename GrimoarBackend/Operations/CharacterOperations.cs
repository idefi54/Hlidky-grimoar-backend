using GrimoarBackend.DTOs;

namespace GrimoarBackend.Operations
{
    public class CharacterOperations
    {

        public static IResult vypisPostavy(PostavyFiltrDto filtr)
        {
            

            throw new NotImplementedException("get it from database");

            //    Results.OK (PostavySeznamDto)
            // results.400 (chybaDto)   fucked up vstup
            // results.404 (chybaDto) nenalezeno
            //results.500 (chybadto)  neočekávaná chyba


            return Results.Ok("shit from database");
        }

    }
}
