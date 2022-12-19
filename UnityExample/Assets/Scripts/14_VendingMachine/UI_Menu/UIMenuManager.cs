using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    // 인스펙터로 바로 찾아오는 방법.
    [SerializeField]
    // 자식 찾는 방법 2.
    public RectTransform backPanelTr = null;
    private UIMenuButtonHolder btnHolder = null;

    private void Awake()

    {   // 자식 찾는 방법 1.
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }

    public void Init(VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        btnHolder.BuildButtons(_btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta);
    }
}
