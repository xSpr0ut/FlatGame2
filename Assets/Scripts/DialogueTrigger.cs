using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    private bool playerInRange;
    [Header("INK JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake()
    {

        playerInRange = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // if (GetComponent<BoxCollider2D>().gameObject.tag == "Player")
        if (other.tag == "Player")
        {
            playerInRange = true;
            
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {

        Debug.Log("RUN 111");
        if (other.tag == "Player")
        {
            playerInRange = false;
            Debug.Log("RUN 2");
        }

    }

    private void Update()
    {

        if (playerInRange && !(DialogueManager.GetInstance().dialogueIsPlaying))
        {

             DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

            /*

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }

            */

        }

    }



}
