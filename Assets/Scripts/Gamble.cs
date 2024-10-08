using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamble : MonoBehaviour
{
    [SerializeField]
    public GameObject pulled;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public float scaleFactor;
    private bool isInteractable = false;
    private bool alreadyPulled = false;
    // Update is called once per frame
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E) && !alreadyPulled) {
            pulled.transform.localScale = new Vector3(scaleFactor * pulled.transform.localScale.x, scaleFactor * pulled.transform.localScale.y, scaleFactor * pulled.transform.localScale.z);
            pulled.transform.position = (Camera.main.transform.forward * 6) + Camera.main.transform.position;
            pulled.transform.rotation = player.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
            // Debug.Log("Wahoo");
            alreadyPulled = true;

        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isInteractable = true;
            // Debug.Log("Enter");
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            isInteractable = false;
            // Debug.Log("Exit");
        }
    }
}
