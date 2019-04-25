using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourse1 : MonoBehaviour
{

    private Color defaultColor;
    private Color deathColor;
    private Color warningColor;
    private float warningSeconds;
    private float transparentSeconds;
    private float opaqueSeconds;

    private float secondsCounter;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = new Color(0f, 1f, 0.9f, 1f);
        warningColor = new Color(1, 0.6f, 0f, 1f);
        deathColor = new Color(1f, 0f, 0f, 0.2f);

        gameObject.GetComponent<Renderer>().material.color = defaultColor;
        ResetModeTimes();
    }

    // Update is called once per frame
    void Update()
    {
        secondsCounter += Time.deltaTime;

        if (secondsCounter > opaqueSeconds && secondsCounter <= warningSeconds)
        {
            gameObject.GetComponent<Renderer>().material.color = warningColor;
        }

        if (secondsCounter > warningSeconds && secondsCounter <= transparentSeconds)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Renderer>().material.color = deathColor;
        }

        if (secondsCounter >= transparentSeconds)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
            gameObject.GetComponent<Renderer>().material.color = defaultColor;
            ResetModeTimes();
        }
    }

    void ResetModeTimes()
    {
        opaqueSeconds = Random.Range(5.0f, 20.0f);
        warningSeconds = opaqueSeconds + 3f;
        transparentSeconds = warningSeconds + Random.Range(2.0f, 8.0f);
        secondsCounter = 0f;
    }
}
