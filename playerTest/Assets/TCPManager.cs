using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net.Sockets;
using UnityNetwork;
using UnityEngine.UI;
using System.Linq.Expressions;

public class TCPManager : MonoBehaviour
{
    private NetworkStream m_networkStream;
    private TcpClient m_client;

    private byte[] sendBuffer = new byte[1024 * 4];
    private byte[] readBuffer = new byte[1024 * 4];
    private bool m_bConnect = false;
    public Login m_loginClass;

    public playUserInfo player;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Send()
    {
        this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
        this.m_networkStream.Flush();

        for(int i=0; i<1024; i++)
        {
            this.sendBuffer[i] = 0;
        }
    }

    public void connect()
    {
        this.m_client = new TcpClient();
        try
        {
            this.m_client.Connect("127.0.0.1", 8000);
        }
        catch
        {
            Debug.Log("접속 에러");
        }

        this.m_bConnect = true;
        this.m_networkStream = this.m_client.GetStream();
    }

    public void nameSend()
    {
        if(!this.m_bConnect)
        {
            return;
        }

        Login login = new Login();
        login.Type = (int)PacketType.접속;
        login.userName = player.userName;

        Packet.Serialize(login).CopyTo(this.sendBuffer, 0);
        this.Send();
    }

}
