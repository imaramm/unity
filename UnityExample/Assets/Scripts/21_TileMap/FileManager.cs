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

        // 저장 경로에는 상대경로, 절대경로가 있다.
        File.WriteAllText(_path, sb.ToString());  // ← 상대경로
    }  

    public void Load(string _path, out int _rowCnt, out int _colCnt, out int[][] _mapInfo)
    {
        // ref / out 둘 다 함수 내부에서 변수에다가 값을 넣어주는.... out은 무조건 값을 넣어줘야하는
        // 둘 다 참조 ref는 값을 안넣어줘도 되고 ~~~ 

        string read = File.ReadAllText(_path);
        // 메모장 보면은 숫자가 다 붙여져잇으니깐 쪼개놔야함
        // Split 잘라주는거. (,)콤마 기준으로 자르는거(자를 방법이 필요하니깐 콤마를 넣어주는거)
        string[] split = read.Split(',');
        // Parse : 기존의 저장되어있던 데이터를 불러오는걸 파씽? 이라하는디
        _rowCnt = int.Parse(split[0]);
        _colCnt = int.Parse(split[1]);

        // 5줄을 먼저 담을 동적할당을 먼저 해주고
        _mapInfo = new int[_rowCnt][];
        for (int row = 0; row < _rowCnt; ++row)
        {
            // 한줄마다 동적할당을 해줘야함
            _mapInfo[row] = new int[_colCnt];
            // 동적할당 준비가 되면은 그 한줄에다가 값을 넣어줄꺼
            for(int col = 0; col < _colCnt; ++col)
            {
                // 그냥 이 공식을 외우는게 편하다함
                _mapInfo[row][col] = int.Parse(split[(row * _colCnt) + col + 2]);

            }

        }

    }


}// end of class FileManager


