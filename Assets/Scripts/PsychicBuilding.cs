using UnityEngine;
using UnityEngine.SceneManagement;

public class PsychicBuilding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter2D(Collider2D other)
    {

        SceneManager.LoadScene("InsideTheHouse");
        Debug.Log("COLLISION");

   }

   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
