using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class TCP : MonoBehaviour
{
	#region private members 	
	private TcpClient socketConnection;
	private Thread clientReceiveThread;
	#endregion
	// Use this for initialization 	
	void Start()
	{
		socketConnection = new TcpClient("192.168.2.245", 6743);
		ConnectToTcpServer();
	}

	public void ConnectToTcpServer()
	{
		clientReceiveThread = new Thread(new ThreadStart(ListenForData));
		clientReceiveThread.IsBackground = true;
		clientReceiveThread.Start();
	}
	/// Runs in background clientReceiveThread; Listens for incomming data. 	  
	public void ListenForData()
	{
		Byte[] bytes = new Byte[1024];
		while (true)
		{
			//Get a stream object for reading 				
			using (NetworkStream stream = socketConnection.GetStream())
			{
				int length;
				//Read incomming stream into byte arrary 					
				while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
				{
					var incommingData = new byte[length];
					Array.Copy(bytes, 0, incommingData, 0, length);
					// Convert byte array to string message. 						
	     			string serverMessage = Encoding.ASCII.GetString(incommingData);
					Debug.Log("server message received as: " + serverMessage);
				}
			}
			}
	}
	/// Send message to server using socket connection. 	
	public void SendMessage(string message)
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream();
			if (stream.CanWrite)
			{
				string clientMessage = message + "\n";
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				Debug.Log("Client sent his message - should be received by server");
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}

	public void join()
    {
		SendMessage("{\"type\":8, \"name\": \"ben\"}");
    }

	public void quit()
    {
		SendMessage("{\"type\":9, \"name\": \"ben\"}");
    }

	public void oncollide()
    {
		SendMessage("{\"type\":7, \"name\": \"bob\"}");
    }
}