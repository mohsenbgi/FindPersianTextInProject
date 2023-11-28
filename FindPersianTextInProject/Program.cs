Console.WriteLine("Enter project full path:");
var projectPath = Console.ReadLine().ToString();

var directories1 = GetDirectories(projectPath);

var Files = new List<string>();

foreach (var d in directories1)
{
    Files.AddRange(Directory.GetFiles(d).Where(x => (x.EndsWith(".cs") || x.EndsWith(".cshtml") || x.EndsWith(".js")) && (!x.Contains("Migrations"))));
}

List<string> GetDirectories(string path)
{

    var directories1 = new List<string>();

    directories1.Add(path);

    var newDiectory = new List<string>();
    newDiectory.AddRange(directories1);

    var tempDirectory = new List<string>();

    while (true)
    {
        foreach (var item in newDiectory)
        {
            tempDirectory.AddRange(Directory.GetDirectories(item));
        }

        if (tempDirectory.Count == 0) break;

        newDiectory.Clear();
        newDiectory.AddRange(tempDirectory);
        directories1.AddRange(tempDirectory);
        tempDirectory.Clear();
    }

    return directories1;
}

var filesWithPersianText = new List<string>();
var persianCharacters = "ضصثقفغعهخحجچگکمنتالبیسشظطزرذدئو";

foreach (var file in Files)
{
    try
    {
        var lines = File.ReadAllLines(file).ToList();

        foreach (var line in lines)
        {
            if (line.Any(c => persianCharacters.Contains(c)))
            {
                filesWithPersianText.Add(file);
                break;
            }
        }
    }
    catch (Exception)
    {

    }
}

foreach (var file in filesWithPersianText)
{
    Console.WriteLine(file);
}
