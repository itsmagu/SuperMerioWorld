using System;

namespace SuperMerioWorld.game;

internal class Merio : GameObject, ISpriteable
{
    private IVector2 _currentFrame;
    public Merio(IntPtr texture, IVector2 atlasSpriteCount, IVector2 currentFrame){
        Texture = texture;
        AtlasSpriteCount = atlasSpriteCount;
        SDL_QueryTexture(
            Texture,
            out uint _,
            out int _,
            out int w,
            out int h
        );
        AtlasCellSize = new IVector2(w / atlasSpriteCount.x, h / atlasSpriteCount.y);
        SrcRect = new SDL_Rect() {
            h = AtlasCellSize.y,
            w = AtlasCellSize.x
        };
        CurrentFrame = currentFrame;
    }
    public IntPtr Texture { get; }
    public IVector2 AtlasSpriteCount { get; }
    public IVector2 AtlasCellSize { get; }
    public IVector2 CurrentFrame {
        get => _currentFrame;
        set {
            _currentFrame = value;
            SrcRect = SrcRect with { // Side Effect to change sprite
                x = AtlasCellSize.x * _currentFrame.x,
                y = AtlasCellSize.y * _currentFrame.y
            };
        }
    }
    public SDL_Rect SrcRect { get; private set; }
}