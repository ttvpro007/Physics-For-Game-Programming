using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformation : Transformation
{
    [SerializeField] Vector3 scale = Vector3.one;

    public override Matrix4x4 Apply()
    {
        Vector4 Column0 = new Vector4(scale.x, 0, 0, 0);
        Vector4 Column1 = new Vector4(0, scale.y, 0, 0);
        Vector4 Column2 = new Vector4(0, 0, scale.z, 0);
        Vector4 Column3 = new Vector4(0, 0, 0, 1);

        return new Matrix4x4(Column0, Column1, Column2, Column3);
    }
}
