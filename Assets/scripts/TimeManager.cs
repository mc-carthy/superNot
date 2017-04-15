using UnityEngine;

public class TimeManager : MonoBehaviour {

	private static float timeFactor = 1f;
    public static float TimeFactor
    {
        get { return timeFactor; }
    }

    private static float targetTimeFactor;
    public static float TargetTimeFactor
    {
        get { return targetTimeFactor; }
        set { targetTimeFactor = value; }
    }

    public static float TimeFactorDelta
    {
        get
        {
            return maxTimeScale - minTimeScale;
        }
    }

    private static float maxTimeScale = 1f;
    public static float MaxTimeScale 
    {
        get { return maxTimeScale; }
    }
    
    private static float minTimeScale = 0.05f;
    public static float MinTimeScale 
    {
        get { return minTimeScale; }
    }

    private float timeStep = 0.05f;
    private int timeDir;

    private void Update()
    {
        AdjustTimeFactor();
    }

    private void AdjustTimeFactor()
    {
        if (timeFactor != targetTimeFactor)
        {
            timeDir = (targetTimeFactor > timeFactor) ? 1 : -1;
            timeFactor += timeStep * timeDir;
            timeFactor = Mathf.Clamp(timeFactor, minTimeScale, maxTimeScale);
            Time.timeScale = timeFactor;
            Time.fixedDeltaTime = 0.02f * timeFactor;
        }
    }

}
