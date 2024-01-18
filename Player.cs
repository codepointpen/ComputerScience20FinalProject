using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    private BoxCollider2D box; // initalizes the box collider to detect "unwalkable" areas like walls
    private float movementSpeed = 0.5f; // sets the speed of the character using "f", meaning force
    public Rigidbody2D rigidBody; // acts as the drive or "engine" behind the player's movement
    public Animator animate; // initalizes the animator
    private NPC_Controller npc; // the npc controller script
    Vector2 movement; // a vector that stores information in 2 dimensions; in this case, horizontal or vertical

    void Start(){ // method ran only at the very start of the program
        box = GetComponent<BoxCollider2D>(); // gets the box collider from unity
        
    }

    void Update(){ // this method is called from UNITY once per frame; sends inputs to FixedUpdate 
        movement.x = Input.GetAxisRaw("Horizontal"); // determines whether to move "-1" (left), "1" (right), or "0" (n/a) based on the input from the keyboard
        movement.y = Input.GetAxisRaw("Vertical"); // determines whether to move "-1" (down), "1" (up), or "0" (n/a) based on the input from the keyboard
        movement = movement.normalized; // prevents character from moving 40% faster diagonally due to pythagorean theorem

        animate.SetFloat("Horizontal", movement.x); // gives the computer the input on the keyboard and converts that value to a float that is later used to determine which animation to output
        animate.SetFloat("Vertical", movement.y);
        animate.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1){
            animate.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animate.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

    }
    

    void FixedUpdate(){ // works like Update(), except it works based on a fixed time interval; by default, calls 50 frames per second
        
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime); 

    }

    private bool inDialogue(){ // if the NPC_controller script is not null, return the dialogue 
        if(npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision){ // interactions with collisions

        //dialogue collisions
        npc = collision.gameObject.GetComponent<NPC_Controller>();

        if(collision.gameObject.tag == "NPC"){
            if(Input.GetKey(KeyCode.F))
                collision.gameObject.GetComponent<NPC_Controller>().ActivateDialogue();
        }

        // scene loader
        if(collision.gameObject.tag == "toArea2"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(2);
        }

        if(collision.gameObject.tag == "toArea2.1"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(3);
        }

        if(collision.gameObject.tag == "toArea3"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(1);
        }

        if(collision.gameObject.tag == "toArea4"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(4);
        }

        if(collision.gameObject.tag == "toArea5"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(5);
        }

        if(collision.gameObject.tag == "toArea6"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(6);
        }

        if(collision.gameObject.tag == "toArea7"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(7);
        }

        if(collision.gameObject.tag == "toArea8"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(8);
        }
        if(collision.gameObject.tag == "toArea9"){
            if(Input.GetKey(KeyCode.F))
                SceneManager.LoadScene(9);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){ // re state npc as null until another input is found

        npc = null;

    }


}
