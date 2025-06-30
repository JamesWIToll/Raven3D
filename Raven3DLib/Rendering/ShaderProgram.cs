using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Raven3DLib.Rendering;

public class ShaderProgram
{
    private readonly int _programId = 0;
    
    public ShaderProgram(string vertexShaderPath, string fragmentShaderPath)
    {
        string vCode = File.ReadAllText(vertexShaderPath);
        string fCode = File.ReadAllText(fragmentShaderPath);
        
        int vShaderId = GL.CreateShader(ShaderType.VertexShader);
        int fShaderId = GL.CreateShader(ShaderType.FragmentShader);
        
        GL.ShaderSource(vShaderId, vCode);
        GL.ShaderSource(fShaderId, fCode);
        
        GL.CompileShader(vShaderId);
        GL.CompileShader(fShaderId);
        
        _programId = GL.CreateProgram();
        GL.AttachShader(_programId, vShaderId);
        GL.AttachShader(_programId, fShaderId);
        GL.LinkProgram(_programId);
        
        GL.DeleteShader(vShaderId);
        GL.DeleteShader(fShaderId);
    }
    
    public void Use()
    {
        GL.UseProgram(_programId);
    }

    public void Destroy()
    {
        GL.UseProgram(0);
        GL.DeleteProgram(_programId);
    }
    
    public void SetBool(string name, bool value)
    {
        GL.Uniform1(GL.GetUniformLocation(_programId, name), value ? 1 : 0);
    }
    
    public void SetInt(string name, int value)
    {
        GL.Uniform1(GL.GetUniformLocation(_programId, name), value);
    }
    
    public void SetFloat(string name, float value)
    {
        GL.Uniform1(GL.GetUniformLocation(_programId, name), value);
    }
    
    public void SetVec2(string name, Vector2 value)
    {
        GL.Uniform2(GL.GetUniformLocation(_programId, name), value);
    }
    
    public void SetVec3(string name, Vector3 value)
    {
        GL.Uniform3(GL.GetUniformLocation(_programId, name), value);
    }
    
    public void SetVec4(string name, Vector4 value)
    {
        GL.Uniform4(GL.GetUniformLocation(_programId, name), value);
    }

    public void SetMat3(string name, Matrix3 value)
    {
        GL.UniformMatrix3(GL.GetUniformLocation(_programId, name), false, ref value);
    }
    
    public void SetMat4(string name, Matrix4 value)
    {
        GL.UniformMatrix4(GL.GetUniformLocation(_programId, name), false, ref value);
    }
}