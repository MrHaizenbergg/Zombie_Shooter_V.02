using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectionScreen;
    [SerializeField] private GameObject _selectionScreen1;
    [SerializeField] private GameObject _selectionScreen2;

    private void Start()
    {
        UpdateLevelScreen();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SaveManager.instance.currentLevel);
        Debug.Log("CurrentLevelLoad: " + SaveManager.instance.currentLevel);
    }

    private void UpdateLevelScreen()
    {
        if (SaveManager.instance.currentLevel == 1)
        {
            _selectionScreen.SetActive(true);
            _selectionScreen1.SetActive(false);
            _selectionScreen2.SetActive(false);
        }
        else if (SaveManager.instance.currentLevel == 2)
        {
            _selectionScreen.SetActive(false);
            _selectionScreen1.SetActive(true);
            _selectionScreen2.SetActive(false);
        }
        else if (SaveManager.instance.currentLevel == 3)
        {
            _selectionScreen.SetActive(false);
            _selectionScreen1.SetActive(false);
            _selectionScreen2.SetActive(true);
        }
    }

    public void SetLevel(int index)
    {    
        SaveManager.instance.currentLevel = index;
        SaveManager.instance.Save();

        UpdateLevelScreen();
    }
}
