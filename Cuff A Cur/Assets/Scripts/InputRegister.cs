using UnityEngine;

public class InputRegister : MonoBehaviour
{
    [SerializeField] private KeyCode PunchButton = new KeyCode();
    [SerializeField] private KeyCode RestartButton = new KeyCode();
    [SerializeField] private Puncher puncher = null;
    private float force = 0;

    private void Start()
    {
        ForceBarUpdator.OnStopped += RegisterForce;
    }

    void Update()
    {
        if (Input.GetKey(PunchButton))
        {
            ForceBarUpdator.Instance.Stop();
            puncher.Punch(force);
        }
        else if (Input.GetKey(RestartButton))
        {
            ForceBarUpdator.Instance.Restart();
            PunchingObjectManager.Instance.Reset();
        }
    }

    private void RegisterForce(StoppedEventArgs eventArgs)
    {
        force = eventArgs.Force;
    }
}
