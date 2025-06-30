using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Raven3DLib.Rendering;
using Raven3DLib.SceneManagement;

namespace Raven3DLib;

public class RavenApp : GameWindow
{
    public Scene MainScene { get; set; }
    
    private Renderer _renderer;
    
    public RavenApp(string appName, int width, int height, Vector3 clearColor) : 
    base(GameWindowSettings.Default, new NativeWindowSettings()
    {
        ClientSize = (width, height),
        Title = appName
    })
    {
        GL.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, 1.0f);
        _renderer = new Renderer();
    }
    
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        
        _renderer.RenderScene(MainScene);
        
        SwapBuffers();
    }
    
}