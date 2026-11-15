using UnityEngine;

public class defaultMusicSelection : MonoBehaviour
{
    private static bool initialized = false;

    void Awake()
    {
        if (!initialized)
        {
            PlayerPrefs.SetInt("MenuMusicMuted", 0);
            PlayerPrefs.SetInt("GameplayMusicMuted", 0);

            PlayerPrefs.Save();

            initialized = true;
        }
    }
}
//Its important to note I opened Porject settings, went to script execution order, and set this script to a low number so it has priority.