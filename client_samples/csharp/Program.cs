using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using SocketIOClient;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello");       
        var client = new SocketIO("http://localhost:3000");

        //THE GOAL IS TO ACCESS THE SOUND FROM MICROPHONE AND SEND IT DIRECTLY AS BYTES
        //SAVE THE FILE IN THE MOBILE AND THE READ IS NOT ALLOWED
        //THIS IS JUST A SAMPLE
        var bytes = File.ReadAllBytes("/foo/bar/sample.wav");

        client.OnConnected += async (sender, e) =>
        {
            Console.WriteLine("Connected");
            //TODO: RESEARCH HOW TO SEND CUSTOM HEADERS 
            await client.EmitAsync("audio", new
            {
                timeMillis = DateTime.Now,
                data = bytes
            });      
            Console.WriteLine("After send");      
        };


        await client.ConnectAsync();
        Console.ReadKey();
    }

}


