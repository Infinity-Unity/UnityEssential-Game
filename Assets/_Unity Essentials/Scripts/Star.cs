using UnityEngine;

public class Star : MonoBehaviour
{

    void Start()
    {
        StarController.Instance.RegisterStar(gameObject);
    }

}
