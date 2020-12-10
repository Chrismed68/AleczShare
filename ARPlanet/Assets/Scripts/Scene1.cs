using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("FaceScene");
    }
}
