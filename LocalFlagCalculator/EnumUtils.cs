using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;

public static class EnumUtils
{
    public static string GetEnumDisplayName(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return attribute != null ? attribute.Description : value.ToString();
    }
}


public class DynamicEnum
{
    public string EnumName { get; set; }
    public List<EnumValue> Values { get; set; }
}

public class EnumValue
{
    public string Name { get; set; }
    public string Value { get; set; }  // Przechowujemy przesunięcie bitowe jako string
    public string DisplayName { get; set; }

    // Obliczanie wartości przesunięcia bitowego
    public int GetCalculatedValue()
    {
        if (Value.Contains("<<"))
        {
            var parts = Value.Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int baseValue) &&
                int.TryParse(parts[1].Trim(), out int shiftAmount))
            {
                return baseValue << shiftAmount;
            }
        }
        // Jeśli nie jest to przesunięcie bitowe, spróbuj zwykłego parsowania
        if (int.TryParse(Value, out int intValue))
        {
            return intValue;
        }

        throw new ArgumentException($"Invalid value format: {Value}");
    }
}


public class EnumLoader
{
    // Load enums from JSON file or create an example if not found
    public List<DynamicEnum> LoadEnums(string filePath)
    {
        if (!File.Exists(filePath))
        {
            CreateExampleFile(filePath);
            throw new FileNotFoundException($"Resource file not found. Example created: {filePath}");
        }

        string json = File.ReadAllText(filePath);
        var dynamicEnums = JsonConvert.DeserializeObject<RootEnum>(json);
        return dynamicEnums?.DynamicEnums ?? new List<DynamicEnum>();
    }

    // Create a sample JSON file if it doesn't exist
    private void CreateExampleFile(string filePath)
    {
        var exampleEnum = new RootEnum
        {
            DynamicEnums = new List<DynamicEnum>
                {
                    new DynamicEnum
                    {
                        EnumName = "ExampleFlags",
                        Values = new List<EnumValue>
                        {
                            new EnumValue { Name = "FLAG_EXAMPLE_ONE", Value = "1 << 0", DisplayName = "Example One" },
                            new EnumValue { Name = "FLAG_EXAMPLE_TWO", Value = "1 << 1", DisplayName = "Example Two" },
                            new EnumValue { Name = "FLAG_EXAMPLE_THREE", Value = "1 << 2", DisplayName = "Example Three" }
                        }
                    }
                }
        };

        // Ensure Resources directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        string json = JsonConvert.SerializeObject(exampleEnum, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Example enum file created at: {filePath}");
    }
}

public class RootEnum
{
    public List<DynamicEnum> DynamicEnums { get; set; }
}


public static class EnumBuilderHelper
{
    public static Type CreateEnum(string enumName, List<EnumValue> values)
    {
        var assemblyName = new AssemblyName("DynamicEnumsAssembly");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

        // Define new enum with base type 'int'
        EnumBuilder enumBuilder = moduleBuilder.DefineEnum(enumName, TypeAttributes.Public, typeof(int));

        // Add values to the enum (ensure proper type casting)
        foreach (var value in values)
        {
            int calculatedValue = value.GetCalculatedValue();
            enumBuilder.DefineLiteral(value.Name, calculatedValue);  // Upewniamy się, że przekazujemy int
        }

        return enumBuilder.CreateType();
    }
}


