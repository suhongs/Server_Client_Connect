
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Schema;

namespace UnityNetwork
{
    public enum PacketType
    {
        접속 = 0,
        게임
    }

    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;
        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach(byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class Login : Packet
    {
        public string userName;

        public Login()
        {
            this.userName = null;
        }
    }
}