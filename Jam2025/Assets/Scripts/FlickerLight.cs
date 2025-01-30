using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{

    [SerializeField] private Light light;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float timer;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clipOn;
    [SerializeField] private AudioClip clipOff;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        Flicking();
    }

    public void Flicking()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            light.enabled = !light.enabled;
            timer = Random.Range(minTime,maxTime);
            if (light.enabled) audioSource.PlayOneShot(clipOn);
            else audioSource.PlayOneShot(clipOff);

        }
    }
}
