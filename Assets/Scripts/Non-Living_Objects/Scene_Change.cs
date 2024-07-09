using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public int namber_Scene_New;

    public void Next_Scene_Clik()
    {
        SceneManager.LoadScene(namber_Scene_New);
    }
}
