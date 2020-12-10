
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene2 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("PortalScene");
    }
}
