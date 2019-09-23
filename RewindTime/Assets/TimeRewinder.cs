using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewinder : MonoBehaviour
{
    public List<RotPos> timePosList = new List<RotPos>();
    public bool isTimeRewind = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            TimeRewindSet(true);
        if (Input.GetKeyUp(KeyCode.Return))
            TimeRewindSet(false);

    }

    private void TimeRewindSet(bool b)
    {
        isTimeRewind = b;
        rb.isKinematic = b;
    }

    private void FixedUpdate()
    {
        if (isTimeRewind)
            TimeRewind();
        else
            Record();
    }

    private void Record()
    {
        if(timePosList.Count > Mathf.Round(5f / Time.fixedDeltaTime))
            timePosList.RemoveAt(timePosList.Count - 1);

        RotPos rp = new RotPos(transform.position, transform.rotation);
        timePosList.Insert(0, rp);
    }

    private void TimeRewind()
    {
        if (timePosList.Count <= 0)
        {
            TimeRewindSet(false);
            return;
        }

        transform.position = timePosList[0].position;
        transform.rotation = timePosList[0].rotation;

        timePosList.RemoveAt(0);
    }

}
