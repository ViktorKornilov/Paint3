using UnityEngine;

public class Painter : MonoBehaviour
{
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        AddPoint(Input.mousePosition);
    }

    public void AddPoint(Vector3 screenPos)
    {
        line.positionCount++;
        var pos = Camera.main.ScreenToWorldPoint(screenPos);
        pos.z = 0;
        line.SetPosition(line.positionCount-1,pos);
    }
}