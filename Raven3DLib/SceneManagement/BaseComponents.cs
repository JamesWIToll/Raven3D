using Arch.Core;
using OpenTK.Mathematics;

namespace Raven3DLib.SceneManagement;

public record struct Transform()
{
    public Vector3 Position = Vector3.Zero;
    public Quaternion Rotation = Quaternion.Identity;
    public Vector3 Scale = Vector3.One;
}

public record struct Relationship()
{
    public Entity Parent = Entity.Null;
    public List<Entity> Children = [];
}

public record struct Mesh()
{
    public List<Vector3> Vertices = [];
    public List<Vector3> Normals = [];
    public List<Vector2> Uvs0 = [];
    public List<Vector2> Uvs1 = [];
    public List<Vector2> Uvs2 = [];
    public List<Vector2> Uvs3 = [];
    public List<Vector2> Uvs4 = [];
    public List<Vector4> Colors = [];
}

public record struct Texture()
{
    public int TexId = 0;
    public int UvIndex = 0;
}

public record struct Material
{
    public Texture BaseTexture;
    public Vector4 BaseColorFactor;
    
    public Texture MetallicRoughnessTexture;
    public float MetallicFactor;
    public float RoughnessFactor;

    public Texture NormalTexture;
    public float NormalScale;
    
    public Texture OcclusionTexture;
    public float OcclusionStrength;
    
    public Texture EmissiveTexture;
    public Vector3 EmissiveFactor;
}

public record struct ViewData()
{
    float FieldOfView = 45.0f;
    float NearPlane = 0.1f;
    float FarPlane = 100.0f;
}

public enum LightType
{
    Directional = 0,
    Point = 1
}

public record struct Light
{
    public LightType Type;
    public Vector3 Color;
    public Vector3 Direction;
    public float Intensity;
}