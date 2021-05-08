using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕? 난 루시야!:0", "이런 근사한 마을은 처음이지?:2"}); // Npc A

        talkData.Add(2000, new string[] {"요! 내 이름은 실눈매애앤!:0", "사나이 중의 사나이지...:3", "옆에 있는 호수 보여?:1", "그거 우리집꺼야. ㅋ:2"}); // Npc B

        talkData.Add(100, new string[] {"나는 그저 평범한 나무상자야..."}); // 상자

        talkData.Add(200, new string[] {"누군가 사용한 흔적이 남아있는 책상."}); // 책상

        talkData.Add(300, new string[] {"썸딩 스페셜한 강이야."}); // 강

        // Quest Talk
        talkData.Add(10 + 1000, new string[] {"어서 와~ 난 루시라고 해!:0", "이 마을에는 놀라운 전설이 하나 있는데:1", "오른쪽 호수 쪽에 있는 실눈맨이 알려줄 거야!:1"});

        talkData.Add(11 + 1000, new string[] {"어서 오른쪽 호수 쪽에 있는 실눈맨한테 가봐!:1"});
        
        talkData.Add(11 + 2000, new string[] {"요! 내 이름은 실눈매애앤!:0", "사나이 중의 사나이지...:3", "혹시 전설의 호수, '라마강'의 비밀을 들으러 온거야?:1", "알려줄 수야 있긴 한데...:0", "요 근처에 잃어버린 내 동전을 찾아주면 알려주지!:2"});

        talkData.Add(20 + 1000, new string[] {"실눈맨의 동전?:1", "자기의 물건을 막 흘리면 못 쓰지!:3", "나중에 실눈맨에게 한 마디 해야 겠어!:3"});

        talkData.Add(20 + 2000, new string[] {"아직도 못 찾았어? 얼른 찾아줘...!:1"});

        talkData.Add(20 + 5000, new string[] {"동전을 발견하였습니다!"});

        talkData.Add(21 + 2000, new string[] {"우와, 내 동전이다! 찾아줘서 고마워!:2"});

        // Portrait Data
        // 0:Normal, 1:Speak, 2:Happy, 3:Angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); // Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex); // Get First Quest Talk
        }

        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
