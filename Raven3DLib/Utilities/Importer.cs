using System.Text;
using System.Text.Json;

namespace Raven3DLib.Utilities;

public static class Importer
{

    public static void ImportGLB(string filePath)
    {
        var fStream = File.OpenRead(filePath);
        byte[] buffer = new byte[fStream.Length];
        var numBytes = fStream.Read(buffer);
        fStream.Close();
        
        var sizeDataJSON = BitConverter.ToUInt32(buffer.AsSpan(12, 4).ToArray());
        var dataJSONStr = Encoding.ASCII.GetString(buffer.AsSpan(20, (int)sizeDataJSON).ToArray());
        var dataJSON = JsonSerializer.Deserialize<JsonDocument>(dataJSONStr);
        
        var sizeDataBIN = BitConverter.ToUInt32(buffer.AsSpan(20 + (int)sizeDataJSON, 4).ToArray());
        var dataBIN = buffer.AsSpan(24 + (int)sizeDataJSON, (int)sizeDataBIN).ToArray();

        var sceneID = dataJSON.RootElement.GetProperty("scene").GetInt32();
        var scene = dataJSON.RootElement.GetProperty("scenes").EnumerateArray().ElementAt(sceneID);
        var sceneNodes = scene.GetProperty("nodes").EnumerateArray();
        var nodes = dataJSON.RootElement.GetProperty("nodes").EnumerateArray();
        
        foreach (var jsonElement in sceneNodes)
        {
            var node = nodes.ElementAt(jsonElement.GetInt32());
        }
    }
}