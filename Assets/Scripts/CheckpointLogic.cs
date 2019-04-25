using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointLogic : MonoBehaviour
{

    public GameObject firstCheckpoint;
    public GameObject currentCheckpoint;
    public Text checkpointText;

    public Color deactivatedColor;
    public Color activatedColor;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentCheckpoint = firstCheckpoint;
        checkpointText.enabled = false;
        deactivatedColor = new Color(1f, 0f, 0f, 1f);
        activatedColor = new Color(0f, 1f, 0f, 1f);
    }

    // Update checkpoint when next one reached
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Checkpoint") && other.gameObject != currentCheckpoint && !IsCheckpointActive(other.gameObject))
        {
            currentCheckpoint = other.gameObject;
            activateCheckpoint(currentCheckpoint);
        }
    }

    bool IsCheckpointActive(GameObject checkpoint) 
    {
        if(checkpoint.GetComponent<Renderer>().material.color.Equals(activatedColor))
        {
            return true;
        } else 
        {
            return false;
        }
    }

    void activateCheckpoint(GameObject checkpoint)
    {
        checkpoint.GetComponent<Renderer>().material.color = activatedColor;
        StartCoroutine(ShowMessage(3));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Water")) 
        {
            double x = currentCheckpoint.GetComponent<Rigidbody>().position.x;
            double y = currentCheckpoint.GetComponent<Rigidbody>().position.y + 0.5;
            double z = currentCheckpoint.GetComponent<Rigidbody>().position.z;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;             
            transform.position = new Vector3((float) x, (float) y, (float) z);
        }
    }

    IEnumerator ShowMessage(float delay) 
    {
        checkpointText.enabled = true;
        yield return new WaitForSeconds(delay);
        checkpointText.enabled = false;
    }
}
