using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSpaceScene()
    {
        SceneManager.LoadScene("Space");
    }

    public void LoadReadMeText(){
        Application.OpenURL("http://www..com/");
    }
}
