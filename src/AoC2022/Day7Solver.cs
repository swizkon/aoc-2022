namespace AoC2022;

public class Day7Solver
{
    public class FileInfo
    {
        public int FileSize { get; set; }
    }

    public class FolderInfo
    {
        public string Name { get; set; }

        public List<FileInfo> Files { get; set; } = new List<FileInfo>();

        public List<FolderInfo> SubFolders { get; set; } = new List<FolderInfo>();

        public FolderInfo ParentFolder { get; set; }

        public int GetSize()
        {
            return SubFolders.Sum(s => s.GetSize()) +  Files.Sum(f => f.FileSize);

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


    public static int CalculateSize(string input)
    {
        var data2 = GetFolderAndFileSizes(input);

        var calcResult = data2.SelectMany(d => d.GetSizes());

        // return calcResult.Max(x => x.TotalSize);

        return calcResult.Where(x => x.TotalSize < 100000).Sum(x => x.TotalSize);
    }



    public static int CalculateFolderSizeToDelete(string input)
    {
        var data2 = GetFolderAndFileSizes(input);
        var calcResult = data2.SelectMany(d => d.GetSizes()).ToList();

        var totalSpace = 70000000;
        var requiredFreeSpace = 30000000;

        var freeSpace = totalSpace - calcResult.Max(x => x.TotalSize);

        return calcResult.Where(x => x.TotalSize + freeSpace >= requiredFreeSpace).Min(x => x.TotalSize);
    }

    public static IList<FolderSize> CalculateFolderSizes(string input)
    {
        var data2 = GetFolderAndFileSizes(input);

        return data2.SelectMany(d => d.GetSizes()).ToList();
    }


    private static IList<FolderInfo> GetFolderAndFileSizes(string input)
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
                currentFolder.Files.Add(new FileInfo
                {
                    FileSize = fileSize
                });
            }
        }

        return result;
    }
}