using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuMusic : MonoBehaviour
{
    public static mainMenuMusic bgMusic;
    private void Awake()
    {
        if (bgMusic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            bgMusic = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

    if (currentScene.name == "Level1Scene")
    {
        // Stops playing music in level 1 scene
        Destroy(gameObject);
    }
    }

}
//Sources Used: https://youtu.be/KIeeCko2sCU?si=W38gfMBtt9i14LNW
//https://discussions.unity.com/t/how-to-stop-music-when-loading-a-specific-scene/243169/4
