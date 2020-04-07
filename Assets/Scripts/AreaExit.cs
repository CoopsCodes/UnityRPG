using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    public string areaTransitionName;

    public AreaEntrance theEntrance;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(areaToLoad);

            // script to set the trigger points to be the area that a player loads in at.
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
