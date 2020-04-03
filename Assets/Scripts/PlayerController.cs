using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator myAnimator;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start() {

        // calling instance checks if there is a duplicate character when the secene changes, if so it destroys it.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // indicates that the gameObject(being the "Player"), gameObject relates to whatever the script relates to.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        myAnimator.SetFloat("moveX", theRB.velocity.x);
        myAnimator.SetFloat("moveY", theRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        } 
    }
}
