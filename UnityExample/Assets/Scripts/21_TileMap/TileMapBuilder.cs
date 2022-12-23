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

        // 시작 위치
        float StartPosX = ((_colCnt * tileW) * 0.5f * -1f) + 0.5f;
        float StartPosY = ((_rowCnt * tileH) * 0.5f) - 0.5f;

        // 벡터로 만들어놔야 편하니깐
        Vector3 StartPos = new Vector3(StartPosX, StartPosY, 0f);

        // 시작위치를 이용해서 반복문 돌리기
        for (int r = 0; r < _rowCnt; ++r)
        {
            for (int c = 0; c < _colCnt; ++c)
            {
                float rowOffset = r * tileH; // Y랑 계산
                // 가야되는 간격
                float colOffset = c * tileW; // X랑 계산

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
