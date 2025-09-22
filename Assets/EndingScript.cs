using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D other)
    {

        SceneManager.LoadScene("TheEnd");

   }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
