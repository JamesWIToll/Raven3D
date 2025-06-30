#version 460
out vec4 FragColor;


in vec2 TexCoord;
in vec3 Normal;
in vec3 FragPos;
in vec4 VertColor;

struct Material
{
    sampler2D BaseTexture;
    int BaseTextureUVID;
    vec4 BaseColorFactor;

    sampler2D MetallicRoughnessTexture;
    int MRTextureUVID;
    float MetallicFactor;
    float RoughnessFactor;
    
    sampler2D NormalTexture;
    int NormalTextureUVID;
    float NormalScale;
    
    sampler2D OcclusionTexture;
    int OcclusionTextureUVID;
    float OcclusionStrength;
    
    sampler2D EmissiveTexture;
    int EmissiveTextureUVID;
    vec3 EmissiveFactor;
};

uniform bool useTexture;
uniform bool useVertColors;
uniform Material material;

void main() {
    vec4 color = vec4(1.0f);
    if (useVertColors) { color = color * VertColor; }
    if (useTexture) { color = color * texture2D(material.BaseTexture, TexCoord); }
    FragColor = color;
}