using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructExample : MonoBehaviour
{
    [System.Serializable]
    // Function Call Overhead : 함수 호출 비용
    // 구조체 = Value Type(가평식)
    public struct SStruct
    {
       // 구조체는 초기화가 안된다.
       //int sInt = 0;
       //private int sInt;   // 이렇게 해야함. (private, 함수에는 public선언) 
        public int sInt { get; set; }
        public float sFloat;
        public bool sBool;

        // 구조체는 default생성자를 만들 수 없다.
        // 무조건 매개변수로 받아야한다.
        public SStruct(int _sInt, float _sFloat, bool _sBool)
        {
            sInt = _sInt;
            sFloat = _sFloat;
            sBool = _sBool;
        }
       
       public void SFunc()
       {
            Debug.Log("Struct Function! : " + sInt);
       }
    }

    [System.Serializable]
    // 클래스 = Reference Type(참조)
    public class CClass
    {
        [SerializeField] // private로 되어있으니깐 외부로 노출이 될려면 SerializeFiled를 붙여야한다.
        private int cInt = 0;
        public int CInt
        {
            get { return cInt; }
            set { cInt = value; }
        }
        public CClass()
        {
            cInt = 10;
        }
       public void CFunc()
       {
            Debug.Log("Class Function! : " + cInt);
       }
    }

   
    [SerializeField]
    private SStruct sStruct = new SStruct();
    [SerializeField]
    private CClass cClass = new CClass();
    [SerializeField]
    private MeshRenderer mr = null;
    public int iValue;


    private void Start()
    {
        SStruct s = new SStruct();
        // 이렇게 초기화도 가능하다.
        //SStruct s = new SStruct { sInt = 10 };
        s.sInt = 100;
        ChangeValue(s); 
        s.SFunc();

        CClass c = new CClass();
        c.CInt = 200;
        ChangeValue(c);
        c.CFunc();

        int value = 0;
        //ChangeValue(ref value);
        ChangeValue(out value);


        //Physics.Raycast()


        Debug.Log("Value :" + value);

    }


    // Call-By-Value
    private void ChangeValue(SStruct _s)
    {
        _s.sInt = 500;
    }

    // Call-By-Reference
    private void ChangeValue(CClass _c)
    {
        _c.CInt = 600;
    }

    // ref : 참조방식으로 받겠다~ 해서 붙인거. 포인터랑 마찬가지의 역할.
    //private void ChangeValue(ref int value)
    //{
    //    value = 1000;
    //}


    // ref랑 다르게 out은 무조건 값을 바꿔야한다.
    private void ChangeValue(out int _value)
    {
        _value = 2000;
    }


    private void ChangePosition(Vector3 _pos)
    {
        _pos.x = 100f;
    }

    private void ChangePosition(Transform _tr)
    {
        _tr.position = new Vector3(100f, 0f, 0f);
    }
}
