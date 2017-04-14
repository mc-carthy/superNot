using UnityEngine;
using System;

public class Clock : MonoBehaviour {

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f,
        subSecondsToDegrees = 360f / 1000f;

    [SerializeField]
	private Transform 
        secondHand,
        subSecondHand;

    private float time;

    private void Update ()
    {
        time += Time.deltaTime;
        secondHand.localRotation = Quaternion.Euler(0f, 0f, time * -secondsToDegrees);
        subSecondHand.localRotation = Quaternion.Euler(0f, 0f, ((time % 1) * 1000) * -subSecondsToDegrees);
    }

}
