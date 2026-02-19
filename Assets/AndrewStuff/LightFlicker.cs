using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timer = 2.0f;
    public float timerReset = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.GetComponent<Light>().enabled = true;
            timer = timerReset;
        }
        else if (timer <= 0.5f)
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
