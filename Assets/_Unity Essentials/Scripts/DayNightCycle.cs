using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day Cycle Settings")]
    [Tooltip("How many real-time seconds it takes for a full day to pass")]
    [SerializeField] private float dayDurationInSeconds = 120f;

    [Header("Rotation Settings")]
    [Tooltip("Starting rotation on the X axis (0 = midnight, 90 = sunrise, 180 = noon, 270 = sunset)")]
    [SerializeField] private float startXRotation = 0f;

    [Header("Debug")]
    [SerializeField] private bool showDebugInfo = false;

    private float currentRotationAngle;
    private float rotationSpeed;

    private void Start()
    {
        // Calculate the rotation speed based on day duration
        // 360 degrees per full day cycle
        rotationSpeed = 360f / dayDurationInSeconds;

        // Set initial rotation
        currentRotationAngle = startXRotation;
        transform.rotation = Quaternion.Euler(currentRotationAngle, -30f, 0f);
    }

    private void Update()
    {
        // Calculate rotation for this frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        currentRotationAngle = (currentRotationAngle + rotationThisFrame) % 360f;

        // Apply rotation to the light
        // Rotate around the X axis to simulate sun movement
        transform.rotation = Quaternion.Euler(currentRotationAngle, -30f, 0f);

        // Optional debug info
        if (showDebugInfo)
        {
            float dayProgress = currentRotationAngle / 360f;
            Debug.Log($"Day Progress: {dayProgress:P1} | Angle: {currentRotationAngle:F1}°");
        }
    }

    // Public methods to control the cycle from other scripts
    public void SetDayDuration(float newDuration)
    {
        dayDurationInSeconds = Mathf.Max(0.1f, newDuration);
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    public float GetDayProgress()
    {
        return currentRotationAngle / 360f;
    }

    public void ResetRotation(float newStartX)
    {
        currentRotationAngle = newStartX;
    }

    // Draw a visualization in the editor
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            // Draw the rotation path in the editor
            Gizmos.color = Color.yellow;
            Vector3 center = transform.position;
            float radius = 5f;

            // Draw a circle representing the sun's path
            int segments = 32;
            Vector3 prevPoint = center + Quaternion.Euler(0, -30f, 0) * new Vector3(radius, 0, 0);

            for (int i = 1; i <= segments; i++)
            {
                float angle = (i / (float)segments) * 360f;
                Vector3 point = center + Quaternion.Euler(angle, -30f, 0) * new Vector3(radius, 0, 0);
                Gizmos.DrawLine(prevPoint, point);
                prevPoint = point;
            }
        }
    }
}