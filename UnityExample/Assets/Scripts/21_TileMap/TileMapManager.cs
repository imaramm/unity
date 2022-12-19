using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    private void Start()
    {
        mapBuilder.Building();

        UpdateCharpos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx.x += 1;

            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveRight();
                UpdateCharpos();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Character.Tileidx curIdx = character.GetCurIndex();
            curIdx. 1;

            if (mapBuilder.CheckCanMove(curIdx))
            {
                character.MoveRight();
                UpdateCharpos();
            }
        }
    }

    private void UpdateCharpos()
    {
        Character.Tileidx tileIdx = character.GetCurIndex();

        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx);

        character.SetPosition(tilePos);
    }
}// end of class TileMapManager
