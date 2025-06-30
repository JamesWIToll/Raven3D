using Arch.Core;
using OpenTK.Mathematics;

namespace Raven3DLib.SceneManagement;

public class Scene
{
    private readonly World _sceneWorld = World.Create();
    private readonly Entity _root;

    public Scene()
    {
        _root = _sceneWorld.Create(new Transform(), new Relationship());
    }

    public void translateEntity(Entity entity, Vector3 translation)
    {
        _sceneWorld.Get<Transform>(entity).Position += translation;
    }

    public void setEntityScale(Entity entity, Vector3 scale)
    {
        _sceneWorld.Get<Transform>(entity).Scale = scale;
    }

    public void rotateEntityAngleAxis(Entity entity, Vector3 axis, float degrees)
    {
        _sceneWorld.Get<Transform>(entity).Rotation += Quaternion.FromAxisAngle(axis, float.DegreesToRadians(degrees));
    }

    public Entity AddEmpty(Transform transform, Entity parent = default)
    {
        if (parent == default)
        {
            parent = _root;
        }
        
        var entity = _sceneWorld.Create(transform, new Relationship(){ Parent = parent });
        
        _sceneWorld.Get<Relationship>(parent).Children.Add(entity);
        
        return entity;
    }

    public Entity AddRenderable(Mesh mesh, Material material, Transform transform, Entity parent = default)
    {
        if (parent == default)
        {
            parent = _root;
        }
        
        var entity = _sceneWorld.Create(transform, mesh, material, new Relationship(){ Parent = parent });
        
        _sceneWorld.Get<Relationship>(parent).Children.Add(entity);
        
        return entity;
    }

    public Entity AddCamera(ViewData viewData, Transform transform, Entity parent = default)
    {
        if (parent == default)
        {
            parent = _root;
        }

        var entity = _sceneWorld.Create(transform, viewData, new Relationship() { Parent = parent });
        
        _sceneWorld.Get<Relationship>(parent).Children.Add(entity);
        
        return entity;
    }


    public Entity AddLight(Light light, Transform transform, Entity parent = default)
    {
        if (parent == default)
        {
            parent = _root;
        }
        
        var entity = _sceneWorld.Create(transform, light, new Relationship() { Parent = parent });
        
        _sceneWorld.Get<Relationship>(parent).Children.Add(entity);
        
        return entity;
    }
    
}