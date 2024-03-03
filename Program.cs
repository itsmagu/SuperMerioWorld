global using static System.Console; // All files should be able to log to console
global using static SDL2.SDL;       // All files should be able to call SDL2
global using static SDL2.SDL_image;
using System;
using SuperMerioWorld.game;

#region Initalize Engine
// Init SDL2
if (SDL_Init(SDL_INIT_VIDEO) < 0) WriteLine($"SDL_Init ERROR : {SDL_GetError()}");
if (IMG_Init(IMG_InitFlags.IMG_INIT_PNG) < 0) WriteLine($"IMG_Init ERROR : {IMG_GetError()}");
// Create Window
IntPtr window = SDL_CreateWindow(
    "Super Merio World",
    SDL_WINDOWPOS_UNDEFINED,
    SDL_WINDOWPOS_UNDEFINED,
    256,
    224,
    SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE
);
if (window == IntPtr.Zero) WriteLine($"CreateWindow() ERROR : {SDL_GetError()}");
// Create Renderer
IntPtr renderer = SDL_CreateRenderer(
    window,
    -1,
    SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC
);
if (renderer == IntPtr.Zero) WriteLine($"CreateRenderer() ERROR : {SDL_GetError()}");
#endregion

#region MainLoop
bool quitOnNext = false;
SuperMerioWorldGame CurrentGame = new SuperMerioWorldGame(renderer);
while (!quitOnNext){
    #region Input
    // Poll events that are create every input
    while (SDL_PollEvent(out SDL_Event @event) == 1){
        switch (@event.type){
        case SDL_EventType.SDL_QUIT:
            quitOnNext = true;
            break;
        }
    }
    #endregion
    #region Rendering
    SDL_RenderClear(renderer);
    CurrentGame.Process(renderer);
    SDL_RenderPresent(renderer);
    #endregion
}
#endregion
#region Quit
SDL_DestroyRenderer(renderer);
SDL_DestroyWindow(window);
SDL_Quit();
#endregion