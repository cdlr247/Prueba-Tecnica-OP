using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class JSONConverter
{
    public static List<Registro> DeserializeJson(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Registro>>(jsonData);
        }
        catch (Exception ex)
        {
            // Manejar errores de deserialización
            Console.WriteLine($"Error deserializando el JSON: {ex.Message}");
            return null;
        }
    }

    public static void SerializeJson(string filePath, List<Registro> data)
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
        catch (Exception ex)
        {
            // Manejar errores de serialización
            Console.WriteLine($"Error serializando el JSON: {ex.Message}");
        }
    }
}