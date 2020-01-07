using UnityEngine;

public class ForceBarUpdator : MonoBehaviour
{
    // event delegate
    public delegate void OnStoppedEvent(StoppedEventArgs eventArgs);
    public static event OnStoppedEvent OnStopped;

    // static variables
    private static ForceBarUpdator instance = null;
    public static ForceBarUpdator Instance { get { return instance; } }

    // changable private variables in inspector
    [SerializeField] private float maxForceMagnitude = 10000;
    [SerializeField] private float secondToFilled = 0;
    [SerializeField] private float maxBarWidth = 500;
    [SerializeField] private RectTransform fillBar = null;

    // private variables
    private float forceMagnitude;
    private Vector3 currentScale = Vector3.zero;
    private UpdatorState state = UpdatorState.Up;

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        UpdateFillBar();
    }

    private void Reset()
    {
        state = UpdatorState.Up;
        currentScale = fillBar.localScale;
        currentScale.x = 0;
    }

    private void UpdateFillBar()
    {
        if (state == UpdatorState.Stop) return;

        state = StateValueLerping.GetLerpingState(state, currentScale.x);
        currentScale.x = Mathf.Min(StateValueLerping.StateLerping01(state, currentScale.x, secondToFilled) * maxBarWidth, maxBarWidth) / maxBarWidth;
        fillBar.localScale = currentScale;
    }

    public void Stop()
    {
        if (state == UpdatorState.Stop)
            return;
        state = UpdatorState.Stop;
        //force = ForceEvaluator.Evaluate(maxForce, currentScale.x, EvaluateMethod.Parabola);
        forceMagnitude = ForceEvaluator.Evaluate(maxForceMagnitude, currentScale.x, EvaluateMethod.Linear);
        OnStopped.Invoke(new StoppedEventArgs(state, currentScale.x, forceMagnitude));
    }

    public void Restart()
    {
        Reset();
    }
}

public class StoppedEventArgs
{
    public StoppedEventArgs(UpdatorState state, float lerpValue, float forceMagnitude)
    {
        LerpValue = lerpValue;
        ForceMagnitude = forceMagnitude;
    }
    
    public float LerpValue { get; }
    public float ForceMagnitude { get; }
}