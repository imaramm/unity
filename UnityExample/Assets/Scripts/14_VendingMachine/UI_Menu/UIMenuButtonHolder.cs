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
    // Template -> Generic �Ϲ�ȭ ���α׷���.
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
    //    // �� ���� ���ϴ�
    //    int lineCnt = btnTotalCnt / btnColCnt;
    //    lineCnt += btnTotalCnt % btnColCnt > 0 ? 1 : 0;
    //    // �������� if������ ������ ��
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

    // c#���� �迭�� �⺻�� �����̴�.
    public void BuildButtons(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt, Vector2 _backPanelSize)
    {
        btnTotalCnt = _btnInfos.Length;
        btnColCnt = _btnColCnt;

        if (btnTotalCnt <= 0) btnTotalCnt = 1;
        if (btnColCnt <= 0) btnColCnt = 1;
        if (btnTotalCnt < btnColCnt)
            btnColCnt = btnTotalCnt;

        // ���� ���� ���ϱ� 
        float backPanelWidth = _backPanelSize.x;
        float backPanelHeight = _backPanelSize.y;
        // ����
        float horizontalOffset = backPanelWidth / btnColCnt;
        // ������ ���� ���ϰ�
        float horizontalOffsetHalf = horizontalOffset * 0.5f;

        int lineCnt = btnTotalCnt / btnColCnt;
        lineCnt += (btnTotalCnt % btnColCnt) > 0 ? 1 : 0;

        float verticalOffset = backPanelHeight / lineCnt;
        float verticalOffsetHalf = verticalOffset * 0.5f;
        // ��ư ũ��
        float btnWidth = horizontalOffset * 0.9f;
        float btnHeight = verticalOffset * 0.9f;

        // ���� ��ġ ���ϴ°�
        float startPosX = (backPanelWidth * 0.5f * -1f) + horizontalOffsetHalf;
        //float posX = - (backPanelWidth * 0.5f) + horizontalOffsetHalf;
        float startPosY = (backPanelHeight * 0.5f) - verticalOffsetHalf;

        // ������ ��ư����
        DestroyButtons();


        for (int i = 0; i < btnTotalCnt; ++i)
        {
            GameObject btnGo = Instantiate(menuBtnPrefab);
            // �ڽ����� �߰����ְ�
            btnGo.transform.SetParent(transform);
            UIMenuButton btn = btnGo.GetComponent<UIMenuButton>();

            // ��ġ ��� 
            //btnGo.GetComponent<RectTransform>().localPosition = 
            //    new Vector3 (startPosX + (horizontalOffset * (i % btnColCnt)), 
            //    startPosY + (verticallOffset * (i / btnColCnt);

            btn.SetLocalPosition(
                startPosX + (horizontalOffset * (i % btnColCnt)), startPosY - (verticalOffset * (i / btnColCnt)));
            btn.SetSize(btnWidth, btnHeight);

            // ������ �ʱ�ȭ(Lazy Initialization)
            btn.Init(i, _btnInfos[i], _onClickCallback);
            //btn.UpdateInfo(_btnInfos[i]);


            // ����Ʈ�� ���ӿ�����Ʈ �߰�
            btnList.Add(btnGo);
        }
    }
    private void DestroyButtons()
    {
        // node�ȿ� ���ӿ�����Ʈ���� �ı�
        foreach (GameObject btnGo in btnList)
            Destroy(btnGo);
        // node ���ִ� �۾�
        btnList.Clear();
    }
}
