using UnityEngine;

public class InputRegister : MonoBehaviour
{
    [SerializeField] private KeyCode PunchButton = new KeyCode();
    [SerializeField] private KeyCode RestartButton = new KeyCode();
    [SerializeField] private Puncher puncher = null;
    private float forceMagnitude = 0;

    private void Start()
    {
        ForceBarUpdator.OnStopped += RegisterForceMagnitude;
    }

    void Update()
    {
        if (Input.GetKey(PunchButton))
        {
            ForceBarUpdator.Instance.Stop();
            //puncher.Punch(force);
            ForceApplier.Instance.GetForceFromInputRegister(forceMagnitude);
            Reset();
        }
        else if (Input.GetKey(RestartButton))
        {
            ForceBarUpdator.Instance.Restart();
            PunchingObjectManager.Instance.Reset();
        }
    }

    private void RegisterForceMagnitude(StoppedEventArgs eventArgs)
    {
        forceMagnitude = eventArgs.ForceMagnitude;
    }

    private void Reset()
    {
        forceMagnitude = 0;
    }
}
