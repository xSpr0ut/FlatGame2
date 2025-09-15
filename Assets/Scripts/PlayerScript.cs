using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // to store the player transform component later on
    private Transform playerTransform;
    public float moveSpeed = 2.5f;

    // runs before start
    private void Awake(){
    
        playerTransform = GetComponent<Transform>();
    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Translate(translation: Vector3.right * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A)){
            playerTransform.Translate(translation: Vector3.left * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.W)){
            playerTransform.Translate(translation: Vector3.up * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            playerTransform.Translate(translation: Vector3.down * moveSpeed * Time.deltaTime);
        }

        // wrong code:
      //  playerTransform.position = new Vector3(Mathf.Clamp(playerBody.position.x, -8, 8), Mathf.Clamp(playerBody.position.y, -4.5f, -2.5f), playerTransform.position.z);

        // clamping position to prevent player going off screen:
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -8, 8);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -4.5f, -2.5f);
        transform.position = currentPosition;


    }
}
