using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    // �ν����ͷ� �ٷ� ã�ƿ��� ���.
    [SerializeField]
    // �ڽ� ã�� ��� 2.
    public RectTransform backPanelTr = null;
    private UIMenuButtonHolder btnHolder = null;

    private void Awake()

    {   // �ڽ� ã�� ��� 1.
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }

    public void Init(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        btnHolder.BuildButtons(_btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta);
    }
}
