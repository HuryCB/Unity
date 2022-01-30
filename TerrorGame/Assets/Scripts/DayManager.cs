using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayManager : MonoBehaviour
{
    public GameObject globalLight;
    private Light2D worldLight;
    public float dayDuration;
    private float currentDaytime;
    private int globalDay = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentDaytime = Time.time;
        worldLight = globalLight.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TimeController();
    }
    private void TimeController()
    {
        currentDaytime += (Time.deltaTime);

        if (currentDaytime >= 60 * dayDuration)
        {
            currentDaytime = 0;
            globalDay++;
            Debug.Log(globalDay);
        }

        if (currentDaytime > 40 * dayDuration)
        {
            Night();
        }
        else if (currentDaytime > 20 * dayDuration)
        {
            Dusk();
        }
        else
        {
            Day();
        }

        //if (darkening)
        //{
        //    float temp = (worldLight.intensity + Time.time) / (60 * dayDuration);
        //    worldLight.intensity = temp;
        //    if(worldLight.intensity >= 1)
        //    {
        //        darkening = false;
        //    }
        //}
    }
    private void Night()
    {
        worldLight.intensity = 0;
    }
    private void Day()
    {
        worldLight.intensity = 1;
    }

    private void Dusk()
    {
        worldLight.intensity = 0.5f;
    }
}
