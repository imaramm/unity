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

    

    private List<Tile> tileList = new List<Tile>();


    public void Building(int _rowCnt, int _colCnt, int[][] _mapInfo)
    {
        

        float tileW = 1f;
        float tileH = 1f;
        float tileWHalf = tileW * 0.5f;
        float tileHHalf = tileH * 0.5f;

        // ���� ��ġ
        float StartPosX = ((_colCnt * tileW) * 0.5f * -1f) + 0.5f;
        float StartPosY = ((_rowCnt * tileH) * 0.5f) - 0.5f;

        // ���ͷ� �������� ���ϴϱ�
        Vector3 StartPos = new Vector3(StartPosX, StartPosY, 0f);

        // ������ġ�� �̿��ؼ� �ݺ��� ������
        for (int r = 0; r < _rowCnt; ++r)
        {
            for (int c = 0; c < _colCnt; ++c)
            {
                float rowOffset = r * tileH; // Y�� ���
                // ���ߵǴ� ����
                float colOffset = c * tileW; // X�� ���

                Vector3 tilePos = new Vector3(StartPos.x + colOffset, StartPos.y - rowOffset, StartPos.z);


                GameObject tileGo = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                Tile tile = tileGo.GetComponent<Tile>();
                int tileIdx = _mapInfo[r][c];
                tile.SetSprite(tileImgs[tileIdx]);

                tileList.Add(tile);
            }
        }

    } // end of Building


    public Vector3 GetPosWithIdx(Character.Tileidx _tileIdx, int _colCnt)
    {
        Tile tile = tileList[(_tileIdx.y * _colCnt) + _tileIdx.x];
        return tile.GetPosition();
    }

   


} // end of class TileMapBuilder
