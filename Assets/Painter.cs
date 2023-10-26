using UnityEngine;

public class Painter : MonoBehaviour
{
    public GameObject lineObject;
    public float stepSize;
    LineRenderer line;

    // current color

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var copy = Instantiate(lineObject);
            line = copy.GetComponent<LineRenderer>();
            // change color
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            AddPoint(Input.mousePosition);
        }
    }

    public void AddPoint(Vector3 screenPos)
    {
        var pos = Camera.main.ScreenToWorldPoint(screenPos);
        pos.z = 0;

        if (line.positionCount == 0)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount-1,pos);
            return;

        }

        var lastPoint = line.GetPosition(line.positionCount - 1);
        if (Vector3.Distance(pos, lastPoint) > stepSize)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount-1,pos);
        }
    }
}