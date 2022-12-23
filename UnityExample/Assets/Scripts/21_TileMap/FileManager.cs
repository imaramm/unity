using System.IO;
using System.Text;

public class FileManager
{
    public void Save(string _path, int _rowCnt, int _colCnt, int [][] _mapInfo)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_rowCnt);
        sb.Append(',');
        sb.Append(_colCnt);
        sb.Append(',');
        for (int row = 0; row < _rowCnt; ++row)
        {
            for(int col = 0; col < _colCnt; ++col)
            {
                sb.Append(_mapInfo[row][col]);
                sb.Append(',');
            }
        }

        // ���� ��ο��� �����, �����ΰ� �ִ�.
        File.WriteAllText(_path, sb.ToString());  // �� �����
    }  

    public void Load(string _path, out int _rowCnt, out int _colCnt, out int[][] _mapInfo)
    {
        // ref / out �� �� �Լ� ���ο��� �������ٰ� ���� �־��ִ�.... out�� ������ ���� �־�����ϴ�
        // �� �� ���� ref�� ���� �ȳ־��൵ �ǰ� ~~~ 

        string read = File.ReadAllText(_path);
        // �޸��� ������ ���ڰ� �� �ٿ��������ϱ� �ɰ�������
        // Split �߶��ִ°�. (,)�޸� �������� �ڸ��°�(�ڸ� ����� �ʿ��ϴϱ� �޸��� �־��ִ°�)
        string[] split = read.Split(',');
        // Parse : ������ ����Ǿ��ִ� �����͸� �ҷ����°� �ľ�? �̶��ϴµ�
        _rowCnt = int.Parse(split[0]);
        _colCnt = int.Parse(split[1]);

        // 5���� ���� ���� �����Ҵ��� ���� ���ְ�
        _mapInfo = new int[_rowCnt][];
        for (int row = 0; row < _rowCnt; ++row)
        {
            // ���ٸ��� �����Ҵ��� �������
            _mapInfo[row] = new int[_colCnt];
            // �����Ҵ� �غ� �Ǹ��� �� ���ٿ��ٰ� ���� �־��ٲ�
            for(int col = 0; col < _colCnt; ++col)
            {
                // �׳� �� ������ �ܿ�°� ���ϴ���
                _mapInfo[row][col] = int.Parse(split[(row * _colCnt) + col + 2]);

            }

        }

    }


}// end of class FileManager


