using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class FileHelper<Tclass> where Tclass : class
    {
        private static string _fileName;

        public static void CreateNewFile()
        {
            _fileName = $"{typeof(Tclass).Name}.cs";
            var file = new FileInfo(_fileName);
            if (file.Exists)
            {
                Console.WriteLine($"\nDo you want to rewrite file {_fileName}?\n1. Yes\n2. No");
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    file.Delete();
                    file.Create().Close();
                }
                else
                {
                    int i = 1;
                    while (true)
                    {
                        if (new FileInfo($"{typeof(Tclass).Name}_{i}.cs").Exists) i++;
                        else break;
                    }

                    _fileName = $"{typeof(Tclass).Name}_{i}.cs";
                    file = new FileInfo(_fileName);
                    file.Create().Close();
                }
            }
            else
            {
                file.Create().Close();
            }
            WriteToFile(_fileName);
        }

        public static void WriteToFile(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine($"class {typeof(Tclass).Name}");
                    streamWriter.WriteLine("{");
                    var properties = typeof(Tclass).GetProperties();

                    foreach (var property in properties)
                    {
                        var set = property.SetMethod;

                        streamWriter.Write(property.PropertyType.Name.Contains("Int")
                            ? $"   public int {property.Name} {{ get; "
                            : $"   public {property.PropertyType.Name.ToLower()} {property.Name} {{ get; ");

                        if (set != null)
                        {
                            streamWriter.WriteLine(set.IsPrivate ? "private set; }" : "set; }");
                        }
                        else
                        {
                            streamWriter.WriteLine("}");
                        }
                    }

                    streamWriter.WriteLine("}");
                }
            }
        }
    }
}
