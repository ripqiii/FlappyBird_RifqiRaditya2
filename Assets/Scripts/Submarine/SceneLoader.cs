using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        // Ganti "MainScene" dengan nama scene permainan utama Anda
        SceneManager.LoadScene("MainScene");
    }
}
