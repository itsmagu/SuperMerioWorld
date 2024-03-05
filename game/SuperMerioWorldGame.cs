using System;

namespace SuperMerioWorld.game;

public class SuperMerioWorldGame(IntPtr renderer)
{
    private Merio _merio = new Merio(
        IMG_LoadTexture(renderer, "ply.png"),
        new IVector2(10),
        new IVector2(4, 8)
    );
    public void Process(IntPtr renderer){
        SDL_Rect dest = new SDL_Rect() {
            x = 0,
            y = 0,
            h = _merio.AtlasCellSize.y,
            w = _merio.AtlasCellSize.x
        };
        SDL_Rect src = new SDL_Rect() {
            x = _merio.CurrentFrame.x * _merio.AtlasCellSize.x,
            y = _merio.CurrentFrame.y * _merio.AtlasCellSize.y,
            h = _merio.AtlasCellSize.y,
            w = _merio.AtlasCellSize.x
        };
        SDL_RenderCopy(
            renderer,
            _merio.Texture,
            ref src,
            ref dest
        );
        SDL_SetRenderDrawColor(
            renderer,
            255,
            0,
            0,
            255
        );
        SDL_RenderDrawRect(renderer, ref dest);
        // _merio.CurrentFrame = _merio.CurrentFrame == new IVector2(4, 8) ? new(4, 7) :
        //     new IVector2(4, 8);
    }
}