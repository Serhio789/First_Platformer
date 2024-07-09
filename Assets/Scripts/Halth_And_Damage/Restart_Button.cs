using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button : MonoBehaviour
{
    public void Clic_Button()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
