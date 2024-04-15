
namespace ChristmasPresents
{
    /// <summary>
    /// Class Program containing Main method
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Reading files containing list of friends and hiding places
            var friends = Friend.ReadFriends(@"files\friends.txt");
            var hidingPlaces = HidingPlace.ReadHidingPlaces(@"files\hiding_places.txt");

            // Finding the best present placement
            var presents = PresentPlacement.FindBestPresentPlacement(friends, hidingPlaces);

            // Writing recommendation to .txt file
            Recommendation.WriteRecommendation(@"files\recommendation.txt", presents);
            Console.WriteLine();

            // Reading recommendation text into console 
            Recommendation.ReadRecommendation(@"files\recommendation.txt");
        }
    }
}