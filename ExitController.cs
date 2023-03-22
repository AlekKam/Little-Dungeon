using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SaveGems();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
        }
    }


}
