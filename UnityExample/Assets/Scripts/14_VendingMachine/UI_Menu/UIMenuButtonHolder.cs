using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButtonHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBtnPrefab = null;

    private readonly float hOffset = 80f;
    private readonly float vOffset = 80f;

    //[SerializeField]
    private int btnTotalCnt = 10;
    //[SerializeField]
    private int btnColCnt = 4;

    // Array -> List
    // Template -> Generic 일반화 프로그래밍.
    private List<GameObject> btnList = new List<GameObject>();

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {

    // Test

    //    }
    //}

    #region Test Functions
    //public void CreateMenuButton(VendingMachine.EBeverageType _type, int _price, int _stock, UIMenuButton.OnClickDelegate _onClickCallback,Vector3 _pos)  
    //{
    //    if (menuBtnPrefab == null) return;

    //    GameObject go = Instantiate(menuBtnPrefab);
    //    //go.transform.parent = transform;
    //    go.transform.SetParent(transform);
    //    go.GetComponent<RectTransform>().localPosition = _pos;

    //    go.GetComponent<UIMenuButton>().UpdateInfo( _type, _price, _stock, _onClickCallback);
    //}

    //private void BuildTestButtons()
    //{
    //    // 줄 수를 구하는
    //    int lineCnt = btnTotalCnt / btnColCnt;
    //    lineCnt += btnTotalCnt % btnColCnt > 0 ? 1 : 0;
    //    // 위에꺼를 if문으로 적은거 ↙
    //    //if (btnTotalCnt % btnColCnt > 0)
    //    //    lintCnt += 1;



    //    Vector3 startPos = new Vector3(-((hOffset * (btnColCnt - 1)) * 0.5f), (vOffset * (lineCnt - 1)) * 0.5f, 0f);

    //    for (int i = 0; i < btnTotalCnt; ++i)
    //    {
    //        // 0 1 2 3 
    //        // 0 1 0 1 %2

    //        // 0 1 2 3
    //        // 0 0 1 1 /2
    //        Vector3 pos = startPos + new Vector3(hOffset * (i % btnColCnt), -(vOffset * (i / btnColCnt)), 0f);
    //        CreateMenuButton(VendingMachine.EBeverageType.Cider, 1000, 5, null, pos);
    //    }
    //}
    #endregion

    // c#에서 배열은 기본이 참조이다.
    public void BuildButtons(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt, Vector2 _backPanelSize)
    {
        btnTotalCnt = _btnInfos.Length;
        btnColCnt = _btnColCnt;

        if (btnTotalCnt <= 0) btnTotalCnt = 1;
        if (btnColCnt <= 0) btnColCnt = 1;
        if (btnTotalCnt < btnColCnt)
            btnColCnt = btnTotalCnt;

        // 가로 간격 구하기 
        float backPanelWidth = _backPanelSize.x;
        float backPanelHeight = _backPanelSize.y;
        // 간격
        float horizontalOffset = backPanelWidth / btnColCnt;
        // 간격의 반을 구하고
        float horizontalOffsetHalf = horizontalOffset * 0.5f;

        int lineCnt = btnTotalCnt / btnColCnt;
        lineCnt += (btnTotalCnt % btnColCnt) > 0 ? 1 : 0;

        float verticalOffset = backPanelHeight / lineCnt;
        float verticalOffsetHalf = verticalOffset * 0.5f;
        // 버튼 크기
        float btnWidth = horizontalOffset * 0.9f;
        float btnHeight = verticalOffset * 0.9f;

        // 시작 위치 구하는거
        float startPosX = (backPanelWidth * 0.5f * -1f) + horizontalOffsetHalf;
        //float posX = - (backPanelWidth * 0.5f) + horizontalOffsetHalf;
        float startPosY = (backPanelHeight * 0.5f) - verticalOffsetHalf;

        // 기존의 버튼정리
        DestroyButtons();


        for (int i = 0; i < btnTotalCnt; ++i)
        {
            GameObject btnGo = Instantiate(menuBtnPrefab);
            // 자식으로 추가해주고
            btnGo.transform.SetParent(transform);
            UIMenuButton btn = btnGo.GetComponent<UIMenuButton>();

            // 위치 계산 
            //btnGo.GetComponent<RectTransform>().localPosition = 
            //    new Vector3 (startPosX + (horizontalOffset * (i % btnColCnt)), 
            //    startPosY + (verticallOffset * (i / btnColCnt);

            btn.SetLocalPosition(
                startPosX + (horizontalOffset * (i % btnColCnt)), startPosY - (verticalOffset * (i / btnColCnt)));
            btn.SetSize(btnWidth, btnHeight);

            // 게으른 초기화(Lazy Initialization)
            btn.Init(i, _btnInfos[i], _onClickCallback);
            //btn.UpdateInfo(_btnInfos[i]);


            // 리스트에 게임오브젝트 추가
            btnList.Add(btnGo);
        }
    }
    private void DestroyButtons()
    {
        // node안에 게임오브젝트들을 파괴
        foreach (GameObject btnGo in btnList)
            Destroy(btnGo);
        // node 없애는 작업
        btnList.Clear();
    }
}
