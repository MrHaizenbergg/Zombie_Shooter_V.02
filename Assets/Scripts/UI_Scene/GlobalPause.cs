using UnityEngine;

public class GlobalPause : MonoBehaviour
{
    public static void SetPause()
    {
        Time.timeScale = 0f;
    }

    public static void ClosePause()
    {
        Time.timeScale = 1f;
    }
}
