using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 0f;
    public float slowdownLengthreprise = 2f;
    private bool slowmotionActivated = false;

    void Update()
    {
        if (slowdownLength > 0)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        else if (slowmotionActivated == false && slowdownLengthreprise > 0) //reprise du cours normal apres 2 sec
        {
            Time.timeScale += (1f / slowdownLengthreprise) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }

    public void DoSlowmotion()
    {
        if (!slowmotionActivated)
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            slowmotionActivated = true;
        }
    }

    public void StopSlowMotion()
    {
        if (slowmotionActivated)
        {
            Time.timeScale = 1;
            slowmotionActivated = false;
        }
    }

}