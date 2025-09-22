using UnityEngine;

public class DialogueTriggerSide : MonoBehaviour
{

    public DialogueTrigger DialogueTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {

        // if (GetComponent<BoxCollider2D>().gameObject.tag == "Player")
        if (other.tag == "Player")
        {
            DialogueTrigger.playerInRange = true;
            Debug.Log("PLAYER WALKED IN ME");

        }

    }

       private void OnTriggerExit2D(Collider2D other)
    {

       // Debug.Log("RUN 111");
        if (other.tag == "Player")
        {
            DialogueTrigger.playerInRange = false;
            // Debug.Log("RUN 2");
        }

    }



}
