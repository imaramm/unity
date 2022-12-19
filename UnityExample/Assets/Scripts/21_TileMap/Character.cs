using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public struct Tileidx
    {
        public int x, y;
        public Tileidx(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    private Tileidx tileIdx = new Tileidx(0, 0);

    public void MoveUp()
    {
        --tileIdx.y;
    }

    public void MoveDown()
    {
        ++tileIdx.y;
    }

    public void MoveLeft()
    {
        --tileIdx.x;
    }

    public void MoveRight()
    {
        ++tileIdx.x;
    }

    public Tileidx GetCurIndex()
    {
        return tileIdx;
    }

    public void SetPosition(Vector3 _pos)
    {
        _pos.z = -1f;
        transform.position = _pos;
    }

} // end of class Character
