using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Raven3DLib;
using Raven3DLib.Utilities;

namespace Raven3DTest;

internal static class Program
{
    public static void Main(string[] args)
    {
        Importer.ImportGLB("./Resources/die.glb");

        // using var app = new RavenApp("Raven3D", 1280, 720, new Vector3(0.1f, 0.2f, 0.3f));
        // app.Run();
    }
}