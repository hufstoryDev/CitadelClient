using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Aegis.Net;

namespace EchoClient
{
	public static class Protocol
	{
		public const UInt16 CS_Hello_Ntf = 0x1000;
		//public const UInt16 클라이언트 테스트를 위해 임시적으로 주석처리함
	};
	
	
	
	class Program
	{
		private AegisClient _aegisClient;
		
		
		public void Start()
		{
			//  AegisClient 초기화
			_aegisClient = new AegisClient();
			_aegisClient.Initialize();
			
			
			//  서버연결 설정
			_aegisClient.ConnectionAliveSec = 0;        //  연결을 자동으로 끊지 않도록 설정
			_aegisClient.HostAddress = "127.0.0.1";
			_aegisClient.HostPortNo = 10100;
			
			
			//  네트워크 이벤트 설정
			_aegisClient.OnConnect += OnConnect;
			_aegisClient.OnDisconnect += OnDisconnect;
			_aegisClient.OnReceive += OnReceive;
			
			
			//  서버연결
			_aegisClient.Connect();
		}
		
		
		private static void Output(String format, params object[] args)
		{
			Debug.Log(String.Format(format, args));
		}
		
		
		private void OnConnect(bool isConnected)
		{
			if (isConnected == false)
				Output("Cannot connect to server.");
			else
			{
				Output("Connected.");
				_aegisClient.EnableSend = true;
			}
		}
		
		
		private void OnDisconnect()
		{
			Output("Connection closed.");
		}
		
		
		private void OnReceive(PacketReader packet)
		{
			//when message recived, separate out using method.
			switch (packet.PID)
			{
			case Protocol.CS_Hello_Ntf: OnCS_Hello_Ntf(packet); break;
			}
		}
		
		
		private void OnCS_Hello_Ntf(PacketReader packet)
		{
			Output("recv: CS_Hello_Ntf");
			
			/* 클라이언트 테스트를 위해 임시적으로 주석처리함
			PacketWriter reqPacket = new PacketWriter(Protocol.CS_Echo_Req, 128);
			reqPacket.PutInt32(0);
			reqPacket.PutStringAsUtf16("가나다라asdf@#$");
			_aegisClient.SendPacket(reqPacket);*/
		}

	}
}



public class NetworkModule : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		EchoClient.Program pro = new EchoClient.Program ();
		pro.Start ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
