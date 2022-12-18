using System.Collections.Concurrent;

namespace AoC2022;

public class Day7Solver
{
    public class FileInfo
    {
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
    }

    public class FolderInfo
    {
        public int TotalSize { get; set; }

        public string Name { get; set; }

        public List<FileInfo> Files { get; set; }

        public List<FolderInfo> SubFolders { get; set; }

        public FolderInfo ParentFolder { get; set; }
    }

    public static int CalculateSize(string input)
    {
        var data = CalculateFolderSizes(input);
        
        return data.Where(x => x.TotalSize < 100_000).Sum(x => x.TotalSize);
    }


    public static IList<FolderInfo> CalculateFolderSizes(string input)
    {
        var data = GetFolderAndFiles(input);

        var folderNames = data.Select(x => x.DirectoryName)
            .Distinct().ToList();

        var folders = folderNames
            .OrderBy(x => x)
            .Select(f => new FolderInfo
            {
                Name = f,
                TotalSize = data.Where(x => x.DirectoryName == f || x.DirectoryName.Contains(f + "/")).Sum(y => y.FileSize)
            });

        return folders.ToList();
    }

    private static IList<FileInfo> GetFolderAndFiles(string input)
    {
        var data = input.Split(Environment.NewLine)
            .Where(x => x != "$ ls")
            .Where(x => !x.StartsWith("dir "));

        // var dir = "";
        
        var dirs = new List<string>() { "root" };

        // var dirs = "/";

        var result = new List<FileInfo>();
        foreach (var d in data)
        {
            var p = d.Split(' ');
            if (int.TryParse(p[0], out var fileSize))
            {
                // var fileSize = int.Parse(d.Substring(0, d.IndexOf(' ')));

                Console.WriteLine("Add " + d + " to Dir " + dirs.Last());
                result.Add(new FileInfo
                {
                    DirectoryName = string.Join("/", dirs),
                    FileSize = fileSize,
                    FileName = d.Substring(fileSize.ToString().Length)
                });
                continue;
            }

            switch (d)
            {
                //case "$ ls":
                //    continue;
                case "$ cd ..":
                    dirs = dirs.SkipLast(1).ToList();
                    continue;
                case "$ cd /":
                    dirs = new List<string> {"root"};
                    continue;
                default:
                {
                    if (d.StartsWith("$ cd "))
                    {
                        dirs = dirs.Append(d.Substring(5)).ToList();
                        continue;
                    }

                    break;
                }
            }
        }

        return result;
    }
}