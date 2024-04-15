namespace ChristmasPresents;

/// <summary>
/// Class Recommendation with methods for writing recommended present placement into text file
/// and
/// reading list of recommendations from the text file information were written
/// </summary>
public class Recommendation
{
    
    // Writing recommended present placement
    public static void WriteRecommendation(string filePath, List<PresentPlacement> placement)
    {
        try
        {
            using var writer = new StreamWriter(filePath);
            foreach (var assignment in placement)
            {
                writer.WriteLine(
                    $"{assignment.FriendName}--{assignment.HidPlaceLocationName}--{assignment.Probability:F}");
            }
        }
        catch (FileNotFoundException)
        {
            CreateFile(filePath);
        }
    }

    // Reading recommendation text into console 
    public static void ReadRecommendation(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found");
            CreateFile(filePath);
        }

        using var file = new StreamReader(filePath);
        while (file.ReadLine() is { } ln)
        {
            Console.WriteLine(ln);
        }
        file.Close();
    }

    private static void CreateFile(string filePath)
    {
        // Create the file
        File.Create(filePath).Dispose();
    }
}