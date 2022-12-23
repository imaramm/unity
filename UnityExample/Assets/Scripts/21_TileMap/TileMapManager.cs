using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    // 0 :Grass , 1:Road, 2:Water, 3:Stone
    public enum EType { Grass, Road, Water, Stone }

    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    // 빈 정보를 가진 변수들 일단 한번 만들어보공 테스트위해
    private int rowCnt = 0;
    private int colCnt = 0;
    private int[][] mapInfo = null;

    // 가로 세로 갯수
    //private int colCnt = 5;
    //private int rowCnt = 5;


    // ↓ 2차원 배열
    // private int[][]
    //private int[,] mapInfo =
    //private int[][] mapInfo = new int[5][]
    //{
    //    new int[5]{1,0,0,2,2},
    //    new int[5]{1,1,0,2,2},
    //    new int[5]{0,1,1,0,2},
    //    new int[5]{3,0,1,1,0},
    //    new int[5]{3,3,0,1,1}
    //};
    //{

    //    {1,0,0,2,2},
    //    {1,1,0,2,2},
    //    {0,1,1,0,2},
    //    {3,0,1,1,0},
    //    {3,3,0,1,1}
    //};

    private void Start()
    {
        FileManager fm = new FileManager();

        // 저장하는거
        //fm.Save("Stage.map",rowCnt,colCnt,mapInfo);

        //mapBuilder.Building( rowCnt, colCnt, mapInfo);

        fm.Load("Stage.map", out rowCnt, out colCnt, out mapInfo);
        mapBuilder.Building(rowCnt, colCnt, mapInfo);


        UpdateCharpos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx.x += 1;

            if (CheckCanMove(curIdx))
            {
                character.MoveRight();
                UpdateCharpos();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx.x -= 1;

            if (CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharpos();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx.y += 1;

            if (CheckCanMove(curIdx))
            {
                character.MoveDown();
                UpdateCharpos();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx.y -=1;

            if(CheckCanMove(curIdx))
            {
                character.MoveUp();
                UpdateCharpos();
            }
        }
    }

    private void UpdateCharpos()
    {
        Character.Tileidx tileIdx = character.GetCurIndex();

        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx, colCnt);

        character.SetPosition(tilePos);
    }

    public bool CheckCanMove(Character.Tileidx _tileIdx)
    {
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1) return false;

        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1) return false;

        int tileInfo = mapInfo[_tileIdx.y][_tileIdx.x];

        if (tileInfo == (int)EType.Water || tileInfo == (int)EType.Stone) return false;

        return true;
    }

}// end of class TileMapManager
