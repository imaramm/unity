using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 2. �� ����
// - ���� 11��, ���� 5��
// - �����ϴ� ���� ����
// - ���� ������
// 3. �� �̵�
// - �� �����ӿ� �Ѱ��� �̵�
// - ȭ���� �¿� ���� �����ϸ� �Ʒ��� �̵�
// - Ÿ�� ��ġ���� �������� ���ӿ���
// - �� ���� �پ��� �ӵ�����
public class InvaderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject invaderPrefab = null;

    private void SpawnInvader(Vector3 _pos)
    {
        GameObject go = Instantiate(invaderPrefab, _pos, Quaternion.identity);
    }
}
