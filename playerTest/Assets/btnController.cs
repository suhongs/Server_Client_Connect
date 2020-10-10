using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnController : MonoBehaviour
{
    public InputField userName;
    public playUserInfo player;
    public Text statusText;

    public TCPManager man;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void btnClick()
    {
        if (userName.text == "")
        {
            statusText.text = "닉네임을 입력하세요";
            return;
        }

        statusText.text = "서버에 접속중입니다...";
        
        player.userName = System.Convert.ToString(userName.text);

        man.connect();
        man.nameSend();


    }
}
