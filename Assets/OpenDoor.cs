using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    public GameObject objDoor;
    void OnTriggerEnter2D(Collider2D other)
    {

        objDoor.SetActive(true);

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
