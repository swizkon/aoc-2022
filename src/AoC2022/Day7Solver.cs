namespace AoC2022;

public class Day7Solver
{
    public class FolderInfo
    {
        public string Name { get; set; }

        public List<int> FileSizes { get; set; } = new List<int>();

        public List<FolderInfo> SubFolders { get; set; } = new List<FolderInfo>();

        public FolderInfo ParentFolder { get; set; }

        public int GetSize()
        {
            return SubFolders.Sum(s => s.GetSize()) +  FileSizes.Sum(f => f);
        }

        public IEnumerable<FolderSize> GetSizes()
        {
            var subTree = SubFolders.SelectMany(x => x.GetSizes()).ToList();
            
            return subTree.Prepend(new FolderSize
            {
                Name = Name,
                TotalSize = GetSize()
            });
        }
    }

    public class FolderSize
    {
        public int TotalSize { get; set; }

        public string Name { get; set; }
    }

    public static int CalculateSize(string input) =>
        GetFolderAndFileSizes(input)
            .SelectMany(d => d.GetSizes())
            .Where(x => x.TotalSize < 100000)
            .Sum(x => x.TotalSize);


    public static int CalculateFolderSizeToDelete(string input)
    {
        var calcResult = GetFolderAndFileSizes(input)
            .SelectMany(d => d.GetSizes())
            .ToList();

        const int totalSpace = 70000000;
        const int requiredFreeSpace = 30000000;

        var freeSpace = totalSpace - calcResult.Max(x => x.TotalSize);

        return calcResult.Where(x => x.TotalSize + freeSpace >= requiredFreeSpace).Min(x => x.TotalSize);
    }

    public static IList<FolderSize> CalculateFolderSizes(string input)
    {
        var data2 = GetFolderAndFileSizes(input);

        return data2.SelectMany(d => d.GetSizes()).ToList();
    }
    
    private static IEnumerable<FolderInfo> GetFolderAndFileSizes(string input)
    {
        var data = input.Split(Environment.NewLine)
            .Where(x => x != "$ ls")
            .Where(x => !x.StartsWith("dir "));

        var currentFolder = new FolderInfo
        {
            Name = "root"
        };
        
        var result = new List<FolderInfo>
        {
            currentFolder
        };

        foreach (var d in data)
        {
            switch (d)
            {
                case "$ cd ..":
                    currentFolder = currentFolder.ParentFolder;
                    continue;

                case "$ cd /":
                    currentFolder = result.First(x => x.Name == "root");
                    continue;

                default:
                {
                    if (d.StartsWith("$ cd "))
                    {
                        var subFolderName = d.Substring(5);

                        if (currentFolder.SubFolders.All(x => x.Name != subFolderName))
                            currentFolder.SubFolders.Add(new FolderInfo{Name = subFolderName, ParentFolder = currentFolder});

                        currentFolder = currentFolder.SubFolders.First(x => x.Name == subFolderName);

                        continue;
                    }

                    break;
                }
            }

            var p = d.Split(' ');
            if (int.TryParse(p[0], out var fileSize))
            {
                currentFolder.FileSizes.Add(fileSize);
            }
        }

        return result;
    }
}