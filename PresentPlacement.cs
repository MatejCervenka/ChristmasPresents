namespace ChristmasPresents;

/// <summary>
/// Present placement class containing information about the placement of each present
/// </summary>
public class PresentPlacement
{
    public string FriendName { get; }
    public string HidPlaceLocationName { get; }
    public double Probability { get; }

    // PresentPlacement Constructor
    private PresentPlacement(string friendName, string hidPlaceLocationName, double probability)
    {
        FriendName = friendName;
        HidPlaceLocationName = hidPlaceLocationName;
        Probability = probability;
    }
    
    // Find the best present placement
    public static List<PresentPlacement> FindBestPresentPlacement(List<Friend> friends, List<HidingPlace> hidingPlaces)
    {
        var placement = new List<PresentPlacement>();

        foreach (var friend in friends)
        {
            var bestHidingPlace = HidingPlace.FindBestHidingPlace(hidingPlaces);
            var bestHiddenPresentPlacement = new PresentPlacement(friend.Name, bestHidingPlace.LocationName,
                friend.Probability * bestHidingPlace.Probability);
            placement.Add(bestHiddenPresentPlacement);
            hidingPlaces.Remove(bestHidingPlace);
        }

        return placement;
    }
}