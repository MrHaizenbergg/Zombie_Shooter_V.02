using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnCurrentLevel : MonoBehaviour
{
    public void ReturnLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
