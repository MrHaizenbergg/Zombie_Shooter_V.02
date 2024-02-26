using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    public void OpenShopScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}