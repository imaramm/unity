using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArraySortExample : MonoBehaviour
{
    public class Human : IComparable
    {
        public int age = 0;
        public string name = string.Empty;  // ← 이렇게 넣어주는걸 권장함
        public float height = .0f;

        public Human(int _age, string _name, float _height)
        {
            age = _age;
            name = _name;
            height = _height;
        }

        int IComparable.CompareTo(object _obj)
        {
            // 어떤식으로 정렬을 할건지 정해줘야하고.           
            Human human = (Human)_obj as Human; // ← C#에서 권장하는 형변환 방법
            if (this.age < human.age) return 1;
            else if (this.age > human.age) return -1;

            return 0;
        }
    }

    public class HeightCompare : IComparer<Human>
    {
        int IComparer<Human>.Compare(Human _lhs, Human _rhs)
        {
            Human lhsHuman = _lhs as Human;
            Human rhsHuman = _rhs as Human;

            if (lhsHuman.height > rhsHuman.height) return 1;
            else if (lhsHuman.height < rhsHuman.height) return -1;
            else return 0;
        }
    }

    private int[] iArr = { 3, 6, 8, 1, 4 };
    private Human[] humans = new Human[]
    {
        new Human(29,"Chang",181.0f),
        new Human(28,"Kim",142.0f),
        new Human(35,"Lee",173.0f),
    };

    private void Start()
    {
        Array.Sort<int>(iArr);

        //foreach (int i in iArr)
        //    Debug.Log(i);

        Array.Sort<Human>(humans, new HeightCompare());

        foreach (Human human in humans)
            Debug.Log(human.age + " / " + human.name + " / " + human.height);
    }
}
