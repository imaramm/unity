using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructExample : MonoBehaviour
{
    [System.Serializable]
    // Function Call Overhead : �Լ� ȣ�� ���
    // ����ü = Value Type(�����)
    public struct SStruct
    {
       // ����ü�� �ʱ�ȭ�� �ȵȴ�.
       //int sInt = 0;
       //private int sInt;   // �̷��� �ؾ���. (private, �Լ����� public����) 
        public int sInt { get; set; }
        public float sFloat;
        public bool sBool;

        // ����ü�� default�����ڸ� ���� �� ����.
        // ������ �Ű������� �޾ƾ��Ѵ�.
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
    // Ŭ���� = Reference Type(����)
    public class CClass
    {
        [SerializeField] // private�� �Ǿ������ϱ� �ܺη� ������ �ɷ��� SerializeFiled�� �ٿ����Ѵ�.
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
        // �̷��� �ʱ�ȭ�� �����ϴ�.
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

    // ref : ����������� �ްڴ�~ �ؼ� ���ΰ�. �����Ͷ� ���������� ����.
    //private void ChangeValue(ref int value)
    //{
    //    value = 1000;
    //}


    // ref�� �ٸ��� out�� ������ ���� �ٲ���Ѵ�.
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
