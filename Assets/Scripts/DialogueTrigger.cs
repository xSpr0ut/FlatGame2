using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{

    public bool playerInRange;
    [SerializeField] Transform Player;
    [Header("INK JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset[] inkJSONFiles;
    // public TextAsset inkJSON;

    // storing all scripts?

    private void Awake()
    {

      //  DontDestroyOnLoad(gameObject);
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

       // Debug.Log("RUN 111");
        if (other.tag == "Player")
        {
            playerInRange = false;
            // Debug.Log("RUN 2");
        }

    }


    private void Update()
    {

        ScriptDecider();

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

        // script for deciding what ink file to play:
    private void ScriptDecider()
    {

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {

            if ((Player.transform.position.y < -3.5f) && (Player.transform.position.x > -4) && (Player.transform.position.x < 4))
            {

                inkJSON = inkJSONFiles[0];

            }
            else if ((Player.transform.position.x < -4) || (Player.transform.position.x > 4))
            {

                inkJSON = inkJSONFiles[1];

            }

        }
        else if (SceneManager.GetActiveScene().name == "InsideTheHouse")
        {

            
            if ((Player.transform.position.y < -2f) && (Player.transform.position.x < 0))
            {

                inkJSON = inkJSONFiles[2];

            } else if ((Player.transform.position.y > 2) && (Player.transform.position.x < -6.5f))
            {

                inkJSON = inkJSONFiles[3];

            } else if ((Player.transform.position.y > 2) && (Player.transform.position.x > -4))
            {

                inkJSON = inkJSONFiles[4];

            } 
            

        }

    }

}
