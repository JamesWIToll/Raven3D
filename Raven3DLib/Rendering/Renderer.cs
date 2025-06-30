using OpenTK.Graphics.OpenGL4;
using Raven3DLib.SceneManagement;

namespace Raven3DLib.Rendering;

public class Renderer
{
    private readonly ShaderProgram _shaderProgram;
    
    public Renderer()
    {
        _shaderProgram = new ShaderProgram("./Shaders/Base.vert", "./Shaders/Base.vert");
    }

    public void RenderScene(Scene scene)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        
        
    }
}