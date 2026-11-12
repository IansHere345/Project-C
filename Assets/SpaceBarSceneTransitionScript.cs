using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBarSceneTransitionScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
            //Pressing Space Bar always leads to the same scene.
        }
    }
}
