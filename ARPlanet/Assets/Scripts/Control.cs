using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SpaceScene");
    }
}
