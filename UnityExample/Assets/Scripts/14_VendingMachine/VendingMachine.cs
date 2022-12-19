using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public enum EBeverageType { Cider, Coke, Soju }
    [System.Serializable]
    public struct SButton
    {
        public EBeverageType type;
        public int price;
        public int stock;

        public SButton(EBeverageType _type, int _price, int _stock)
        {
            type = _type;
            price = _price;
            stock = _stock;
        }
    }

    //[SerializeField]
    //private GameObject[] beveragePrefabs = null;

    //[SerializeField]
    //private EBeverage[] beverage = null;
    //[SerializeField]
    //private int[] beverageCnt = null;

    [SerializeField]
    private SButton[] buttons = null;
    [SerializeField]
    private int btnColCnt = 1;

    private GameObject[] beveragePrefabs = null;

    private UIManager uiMng = null;

    private void Awake()
    {
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");

        GameObject uiMngGo = GameObject.FindGameObjectWithTag("UIManager");
        if (uiMngGo != null)
        uiMng = uiMngGo.GetComponent<UIManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if(BuyBeverageWithButtonIndex(0))
        //    SpawnBeverage(buttons[0].type);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    if(BuyBeverageWithButtonIndex(1))
        //    SpawnBeverage(buttons[1].type);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    if(BuyBeverageWithButtonIndex(2))
        //    SpawnBeverage(buttons[2].type);
        //}

        //if (Input.GetKeyDown(KeyCode.M))
        //    uiMng.ShowMenu(buttons, BuyBeverage, btnColCnt);
        //if (Input.GetKeyDown(KeyCode.N))
        //    uiMng.HideMenu();


    }

   private void SpawnBeverage(EBeverageType _type)
    {
        Debug.Log("After: " + buttons[0].stock);

        GameObject go = Instantiate(beveragePrefabs[(int)_type]);

        go.transform.position = transform.position + GetRandomPositionWithRadius(2f);
    }

    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _r;
    }

    public int CheckStock(EBeverageType _type)
    {
        return 0;
    }

        // 1.������ ������ ���
        // 2.�ش� ���ᰡ ���Ǳ⿡ �����ϴ��� Ȯ��
        // 3.�ش� ���ᰡ �ִٸ� ����ľ�

    public int CheckStock(int _btnIdx)
    {

        return buttons[_btnIdx].stock;
    }

    // �ܺο��� ȣ�� �� ���� ������ϴϱ� private�� ����.
    private bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;

        --buttons[_btnIdx].stock;
        return true;
    }

    public bool BuyBeverage(int _btnIdx, out SButton _newBtnInfo)
    {
        // ����ó��
        if(buttons == null || buttons.Length == 0 || buttons.Length <= _btnIdx) 
        {
            _newBtnInfo = buttons[_btnIdx];
                return false;
        }
         
        if (BuyBeverageWithButtonIndex(_btnIdx))
        { 
            SpawnBeverage(buttons[_btnIdx].type);
            _newBtnInfo = buttons[_btnIdx];
            return true;
        }

        _newBtnInfo = buttons[_btnIdx];
        return false;
    }

    public void ShowMenu()
    {
        uiMng.ShowMenu(buttons, BuyBeverage, btnColCnt);
    }

    public void HideMenu()
    {
        uiMng.HideMenu();
    }
}
