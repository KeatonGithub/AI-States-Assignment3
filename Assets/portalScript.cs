using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Escaped!");
        }
    }
}
