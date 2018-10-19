using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================

            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            
            // var localArtist = from match in Artists
            // where match.Hometown == "Mount Vernon"
            // select new {match.ArtistName, match.Age};
            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject( 
            // localArtist, Formatting.Indented ));  
            
            var localArtist = Artists.Where(match => match.Hometown == "Mount Vernon");
            
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            
            // var youngArtist = (from match in Artists
            // orderby match.Age ascending 
            // select new {match.RealName}).First();
            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject( youngArtist.RealName, Formatting.Indented ));

            // var youngArtist = Artists.OrderBy(match => match.Age).First();


            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            
            var williamArtists = Artists.Where(avocado => avocado.RealName.Contains("William"));
            
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            
            var eightChars = Groups.Where(avocado => avocado.GroupName.Count() < 8 );
            
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            
            var oldArtists = Artists.OrderByDescending(avocado => avocado.Age).Take(3);
            
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================

            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
        }
    }
}
