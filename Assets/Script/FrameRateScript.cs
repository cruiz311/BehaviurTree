using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrameRateScript : MonoBehaviour
{
    protected float FrameRate = 0;
    protected float Rate;
    public float MinRate;
    public float MaxRate;
    public UnityEvent eventInvoke;
    // Start is called before the first frame update
    void Start()
    {
        Rate = Random.Range(MinRate, MaxRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (FrameRate > Rate)
        {
            eventInvoke.Invoke();
            FrameRate = 0;
        }
        FrameRate += Time.deltaTime;
    }
}
