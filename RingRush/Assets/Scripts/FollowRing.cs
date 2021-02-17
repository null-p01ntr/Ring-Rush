using UnityEngine;

public class FollowRing : MonoBehaviour
{
    public GameObject Ring;
    public float cameraHeight = 20.0f;

    void Update()
    {
        Vector3 pos = (Ring.transform.position);
        pos.z += cameraHeight;
        transform.position = pos;
    }
}
