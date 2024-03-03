using System;

namespace SuperMerioWorld.game;

internal abstract class GameObject
{
    
}

internal class Merio : GameObject , ISpriteable
{
    public Merio(IntPtr texture){
        Texture = texture;
    }
    public IntPtr Texture { get; }
}