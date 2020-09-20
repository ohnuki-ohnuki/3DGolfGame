using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private int currentIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Goal!");
            // Time.timeScale = 0;
            if (currentIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
               SceneManager.LoadScene(currentIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            //Debug.Log("Goal!");
            //Time.timeScale = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
