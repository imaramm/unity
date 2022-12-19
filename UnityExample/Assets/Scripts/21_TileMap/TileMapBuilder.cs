using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapBuilder : MonoBehaviour
{
    // 0 :Grass , 1:Road, 2:Water, 3:Stone
    public enum EType { Grass,Road,Water,Stone}

    [SerializeField]
    private Sprite[] tileImgs = null;
    [SerializeField]
    private GameObject tilePrefab = null;

    // ���� ���� ����
    private int colCnt = 5;
    private int rowCnt = 5;


    // �� 2���� �迭
    // private int[][]
    private int[,] mapInfo =
    {
        {1,0,0,2,2},
        {1,1,0,2,2},
        {0,1,1,0,2},
        {3,0,1,1,0},
        {3,3,0,1,1}
    };

    private List<Tile> tileList = new List<Tile>();


    public void Building()
    {
        float tileW = 1f;
        float tileH = 1f;
        float tileWHalf = tileW * 0.5f;
        float tileHHalf = tileH * 0.5f;

        // ���� ��ġ
        float StartPosX = ((colCnt * tileW) * 0.5f * -1f) + 0.5f;
        float StartPosY = ((rowCnt * tileH) * 0.5f) - 0.5f;

        // ���ͷ� �������� ���ϴϱ�
        Vector3 StartPos = new Vector3(StartPosX, StartPosY, 0f);

        // ������ġ�� �̿��ؼ� �ݺ��� ������
        for (int r = 0; r < rowCnt; ++r)
        {
            for (int c = 0; c < colCnt; ++c)
            {
                float rowOffset = r * tileH; // Y�� ���
                // ���ߵǴ� ����
                float colOffset = c * tileW; // X�� ���

                Vector3 tilePos = new Vector3(StartPos.x + colOffset, StartPos.y - rowOffset, StartPos.z);


                GameObject tileGo = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                Tile tile = tileGo.GetComponent<Tile>();
                int tileIdx = mapInfo[r, c];
                tile.SetSprite(tileImgs[tileIdx]);

                tileList.Add(tile);
            }
        }

    } // end of Building


    public Vector3 GetPosWithIdx(Character.Tileidx _tileIdx)
    {
        Tile tile = tileList[(_tileIdx.y * colCnt) + _tileIdx.x];
        return tile.GetPosition();
    }

    public bool CheckCanMove(Character.Tileidx _tileIdx)
    {
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1) return false;

        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1) return false;

        int tileInfo = mapInfo[_tileIdx.y, _tileIdx.x];

        if (tileInfo == (int)EType.Water || tileInfo == (int)EType.Stone) return false;

        return true;
    }


} // end of class TileMapBuilder
