using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorLevel;
    [SerializeField] private Texture2D _cursorMenu;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            SetLevelCursor();
        }
        else
        {
           SetMenuCursor();
        }
    }

    public void SetLevelCursor()
    {
        Cursor.SetCursor(_cursorLevel, Vector2.zero, CursorMode.Auto);
    }

    public void SetMenuCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
