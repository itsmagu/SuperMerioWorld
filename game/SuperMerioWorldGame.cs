using System;

namespace SuperMerioWorld.game;

public class SuperMerioWorldGame
{
    private Merio _merio;
    public SuperMerioWorldGame(IntPtr renderer){
        _merio = new Merio(IMG_LoadTexture(renderer, "ply.png"));
    }
    public void Process(IntPtr renderer){
        SDL_SetRenderDrawColor(
            renderer,
            135,
            200,
            235,
            255
        );

        SDL_Rect dest = new SDL_Rect() {
            x = 0,
            y = 0
        };
        SDL_QueryTexture(
            _merio.Texture,
            out uint _,
            out int _,
            out dest.w,
            out dest.h
        );
        SDL_RenderCopy(
            renderer,
            _merio.Texture,
            IntPtr.Zero,
            ref dest
        );
    }
}