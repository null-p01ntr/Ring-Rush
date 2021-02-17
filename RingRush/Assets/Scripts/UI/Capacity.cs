using UnityEngine;
using UnityEngine.UI;

public class Capacity : MonoBehaviour
{
    static public Text capacity;
    public GameObject Ring;

    private void Start()
    {
        capacity = GetComponent<Text>();
    }

    void Update()
    {
        capacity.text = (Ring.transform.childCount-1).ToString() + "/50";
    }
}
