namespace ChristmasPresents;
/// <summary>
/// Class Friend with methods for reading list of friends from text file
/// </summary>
public class Friend
{
    public string Name { get; }
    public double Probability { get; }

    // Friend Constructor
    private Friend(string name, double probability)
    {
        Name = name;
        Probability = probability;
    }

    // Reading friends from friends.txt
    public static List<Friend> ReadFriends(string filePath)
    {
        List<Friend> friends = new List<Friend>();

        if (!File.Exists(filePath))
        {
            CreateFile(filePath);
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("John;0.8\nThomas;0.7\nJacob;0.2\nGeorge;0.4\nMartin;0.5\nJoe;0.1");
        }

        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line != null)
            {
                var parts = line.Split(';');

                var friend = new Friend(parts[0], Convert.ToDouble(parts[1]));
                friends.Add(friend);
            }
            else
            {
                Console.WriteLine("Line is null");
            }
        }

        return friends;
    }

    private static void CreateFile(string filePath)
    {
        // Create the file
        File.Create(filePath).Dispose();
    }
}