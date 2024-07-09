using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Level : MonoBehaviour
{
    private float time_change_level;
    [SerializeField] private Animator _anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            _anim.SetBool("check", true);
            time_change_level -= Time.deltaTime;
            if (time_change_level < 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
