using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        None,
        Login,
        Lobby,
        Game,
    }
    public enum Sound
    {
        BGM,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        Drag,
    }
    public enum CameraMode
    {
        Quater,
    }

    public enum MouseEvent
    {
        Press,
        Click,
    }
}
