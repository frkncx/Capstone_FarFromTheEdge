using UnityEngine;

public enum MovementType
{
    Linear,
    EaseIn,
    EaseOut,
    EaseInOut,
    EaseOutBounce,
    EaseInOutBounce
}

public class EasingController : MonoBehaviour
{
    private const float n1 = 7.5625f;
    private const float d1 = 2.75f;

    [SerializeField] private MovementType movementType = MovementType.Linear;
    [SerializeField] private float durationInSeconds = 1f;

    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Vector3 endPosition = Vector3.up;

    [SerializeField] private bool useCurrentPositionAsStart = false;
    [SerializeField] private bool relativeEndPosition = false;
    [SerializeField] private bool pingPong = false;

    private float startTime = 0f;

    // Start is called before the first frame update
    public void Start()
    {
        if (useCurrentPositionAsStart) startPosition = transform.position;

        if (relativeEndPosition) endPosition += startPosition;

        startTime = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime < durationInSeconds)
        {
            float stepValue = 0f;

            switch (movementType)
            {
                case MovementType.Linear:
                    stepValue = elapsedTime / durationInSeconds;
                    break;
                case MovementType.EaseIn:
                    stepValue = Mathf.Pow((elapsedTime / durationInSeconds), 2);
                    break;
                case MovementType.EaseOut:
                    stepValue = 1 - Mathf.Pow(1 - (elapsedTime / durationInSeconds), 2);
                    break;
                case MovementType.EaseInOut:
                    stepValue = EaseInOut(elapsedTime / durationInSeconds);
                    break;
                case MovementType.EaseOutBounce:
                    stepValue = EaseOutBounce(elapsedTime / durationInSeconds);
                    break;
                case MovementType.EaseInOutBounce:
                    stepValue = EaseInOutBounce(elapsedTime / durationInSeconds);
                    break;
            }

            transform.position = Vector3.Lerp(startPosition, endPosition, stepValue);
        }
        else if (pingPong)
        {
            (startPosition, endPosition) = (endPosition, startPosition);

            startTime = Time.time;
        }
    }

    private float EaseInOut(float t)
    {
        if (t < 0.5) return 2 * Mathf.Pow(t, 2);
        // 1 - Math.pow(-2 * x + 2, 2) / 2
        else return 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
    }

    private float EaseOutBounce(float t)
    {
        if (t < 1 / d1) return n1 * Mathf.Pow(t, 2);
        else if (t < 2 / d1) return n1 * (t -= 1.5f / d1) * t + 0.75f;
        else if (t < 2.5f / d1) return n1 * (t -= 2.25f / d1) * t + 0.9375f;
        else return n1 * (t -= 2.625f / d1) * t + 0.984375f;
    }

    // x < 0.5 ? (1 - easeOutBounce(1 - 2 * x)) / 2 : (1 + easeOutBounce(2 * x - 1)) / 2;

    private float EaseInOutBounce(float t)
    {
        if (t < 0.5f) return (1 - EaseOutBounce(1 - 2 * t)) / 2;
        else return (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
}
