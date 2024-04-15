namespace ChristmasPresents;

/// <summary>
/// Class Hiding Place with methods for reading list of hiding places from text file
/// </summary>
public class HidingPlace
{
    public string LocationName { get; }
    public double Probability { get; }

    // Hiding Place Constructor
    private HidingPlace(string locationName, double probability)
    {
        LocationName = locationName;
        Probability = probability;
    }

    // Reading hiding places from hiding_places.txt
    public static List<HidingPlace> ReadHidingPlaces(string filePath)
    {
        var hidingPlaces = new List<HidingPlace>();

        if (!File.Exists(filePath))
        {
            CreateFile(filePath);
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Wardrobe;0.9\nFridge;0.5\nNightstand;0.7\nToilet;0.25\nDrawer;0.1\nOven;0.3");
        }

        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line != null)
            {
                var parts = line.Split(';');

                var hidingPlace = new HidingPlace(parts[0], Convert.ToDouble(parts[1]));
                hidingPlaces.Add(hidingPlace);
            }
            else
            {
                Console.WriteLine("Line is null");
            }
        }

        return hidingPlaces;
    }

    // Find the best hiding place
    public static HidingPlace FindBestHidingPlace(List<HidingPlace> hidingPlaces)
    {
        var bestHidingPlace = hidingPlaces[0];

        for (var i = 1; i < hidingPlaces.Count; i++)
        {
            if (hidingPlaces[i].Probability < bestHidingPlace.Probability)
            {
                bestHidingPlace = hidingPlaces[i];
            }
        }

        return bestHidingPlace;
    }

    private static void CreateFile(string filePath)
    {
        // Create the file
        File.Create(filePath).Dispose();
    }
}