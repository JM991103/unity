using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;
    ScorePanel scorePanel;

    int score;
    int hiScore;

    public int Score { get => score; set => score = value; }


    public Player Player { get => player; }

    protected override void Initialize()
    {
        player = FindObjectOfType<Player>();
        scorePanel = FindObjectOfType<ScorePanel>();

        Load();
    }

    public void Save()
    {
        SaveData savedata = new();          // SaveData라는 클래스타입의 변수 savedata를 만들어 주고 new 키워드를 사용해 인스턴스화 해준다.
                                            // (SaveData는) MonoBehaviour가 없고 [Serializable]를 사용해 직렬화 시켜준다. ex) json 사용가능

        if (Score > scorePanel.HiScore)
        {
            savedata.bestScore = Score;         // savedata에 있는 bsetScore 변수에 Score 값을 넣어준다.


            string saveDataJson = JsonUtility.ToJson(savedata);     // 문자열 타입으로 saveDataJson변수에 savedata를 json형태로 변환해 저장한다.

            string path = $"{Application.dataPath}/Save/";          // path변수에 에셋 까지의 경로 + 새로운 폴더 까지의 경로를 저장한다.
            if (!Directory.Exists(path))    // 만약 해당 경로에 폴더가 없으면
            {
                Directory.CreateDirectory(path);    // 그 경로에 폴더를 하나 만들어라
            }
            string fullPath = $"{path}Save.json";   // fullPath 변수에 path경로에 이름.josn형식을 기억시킨다.
            File.WriteAllText(fullPath, saveDataJson);  // 지정한 경로에 있는 json형식의 파일에 saveDataJson(json형태로 변환한것)을 저장한다.
        }
    }

    void Load()
    {
        string path = $"{Application.dataPath}/Save/";  // 경로 확인용
        string fullPath = $"{path}Save.json";           // 전체 경로 확인용
        if (Directory.Exists(path) && File.Exists(fullPath))    // 해당 폴더가 있고, 파일도 있으면
        {
            string json = File.ReadAllText(fullPath);   // Json형식의 데이터 읽기
            SaveData loadData = JsonUtility.FromJson<SaveData>(json);
            scorePanel.HiScore = loadData.bestScore;   // 읽어온 데이터로 최고점수 기록 변경
        }
    }
}
