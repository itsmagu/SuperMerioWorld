using System;

namespace SuperMerioWorld.game;

public interface ISpriteable
{
    IntPtr Texture { get; }
    IVector2 AtlasSpriteCount { get; }
    IVector2 AtlasCellSize { get; }
    IVector2 CurrentFrame { get; set; }
    SDL_Rect SrcRect { get; }
}