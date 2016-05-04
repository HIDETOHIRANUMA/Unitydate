using UnityEngine;
using System.Net.Sockets;
using System.Text;
using UnityEngine.VR;
using System;

public class UDPClient : MonoBehaviour
{
	// broadcast address
	public string host = "133.10.79.255";
	public int port = 61000;
	private UdpClient client;
	
	void Start ()
	{
		client = new UdpClient();
		client.Connect(host, port);

	}


	float time = 0.0f;

	//60Hzでudp通信
	void Update () 
	{
		Quaternion rotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
		
		//Unity上に位置と角度記録
		Debug.Log (rotation);

		byte[] dgram = Encoding.UTF8.GetBytes (rotation.y.ToString ()); //角度情報送信　x,y,z,w座標
		client.Send (dgram, dgram.Length);

		time =time+ Time.deltaTime;


		if((0.0f<=time)&&(time<6.0f))
		{
			Debug.Log("パケット1送信中");

			byte[] dgram1 = Encoding.UTF8.GetBytes ("1"); //．人力車

			if(dgram1==Encoding.UTF8.GetBytes ("1"))
			{
				client.Send(dgram1, dgram1.Length);
			}

		
		}

		if((13.0f<=time)&&(time<13.1f))
		{

			Debug.Log("パケット7送信中");
			byte[] dgram8 = Encoding.UTF8.GetBytes ("7"); //待ちシーン7

			if(dgram8==Encoding.UTF8.GetBytes ("7"))
			{
				client.Send(dgram8, dgram8.Length);

			}

		}

		if((47.0f<=time)&&(time<48.0f)){


			Debug.Log("パケット2送信中");
			byte[] dgram2 = Encoding.UTF8.GetBytes ("2"); //．「シーン２」静止，見回し時間（動作なし）  ３秒

			if(dgram2==Encoding.UTF8.GetBytes ("2"))
			{
				client.Send(dgram2, dgram2.Length);
			}
								
		}

		if((58.0f<=time)&&(time<80.0f )){
			
			
			Debug.Log("パケット3送信中");
			byte[] dgram3 = Encoding.UTF8.GetBytes ("3"); //．「シーン３」階段上昇歩行,

			if(dgram3==Encoding.UTF8.GetBytes ("3"))
			{
				client.Send(dgram3, dgram3.Length);
			}

			
		}

		if((80.0f<=time)&&(time<108.6f)){
			
			
			Debug.Log("パケット4送信中");
			byte[] dgram4 = Encoding.UTF8.GetBytes ("4"); //．「シーン４」踊場（的)運動，右回旋

			if(dgram4==Encoding.UTF8.GetBytes ("4"))
			{
				client.Send(dgram4, dgram4.Length);
			}


			
		}

		if((109.0f<=time)&&(time<150.0f )){
			
			
			Debug.Log("パケット5送信中");
			byte[] dgram5 = Encoding.UTF8.GetBytes ("5"); //．「シーン５」静止，見回し時間（動作なし）２秒
			if(dgram5==Encoding.UTF8.GetBytes ("5"))
			{
				client.Send(dgram5, dgram5.Length);
			}

		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			Debug.Log ("パケット9送信中");
			byte[] dgram6 = Encoding.UTF8.GetBytes ("9"); //．「シーン6」静止，見回し時間（動作なし）２秒

			if(dgram6==Encoding.UTF8.GetBytes ("9"))
			{
				client.Send (dgram6, dgram6.Length);
			}

		}
		//if (Input.GetKeyDown (KeyCode.Escape)) break;


		
	}

	//終了作業
	void OnApplicationQuit()
	{
		client.Close();
	}
}

