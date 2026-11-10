using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Oyun Kapatılıyor.");
        Application.Quit();
    }
}
