using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhEngine.Core;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float currentTime = 0f;
    public float CurrentTime => currentTime;
    protected override void InitAfterAwake()
    {

    }
    public void Update()
    {
        currentTime += Time.deltaTime;
    }
}
