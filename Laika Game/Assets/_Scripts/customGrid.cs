using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGrid : MonoBehaviour
{
    [SerializeField]
    private float size = 1.0f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        float xCount, yCount, zCount;
        position -= transform.position;
        xCount = Mathf.RoundToInt(position.x / size);
        yCount = Mathf.RoundToInt(position.y / size);
        zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size, (float)yCount * size, (float)zCount * size);

        result += transform.position;

        return result;
    }

}
