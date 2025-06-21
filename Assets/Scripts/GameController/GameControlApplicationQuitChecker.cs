using UnityEngine;

public class GameControlApplicationQuitChecker: MonoBehaviour {
    public static bool IsQuit { get; private set; }

    
    public void OnApplicationQuit() {
        IsQuit = true;
    }
}