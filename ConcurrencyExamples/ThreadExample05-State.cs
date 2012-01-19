using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample05
	{
		public ThreadExample05 ()
		{
		}

		public static int loops = 4000;
		
		public static void LoopMethod ()
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				Console.WriteLine (Thread.CurrentThread.Name + " - " + i + " " + Thread.CurrentThread.ThreadState);
				//Thread.Sleep(5);
			}		
		}

		public static void ThreadStates (List<Thread> threads,int times)
		{
			for (int i=0; i<times; i++) {
				String result = "";
				foreach (Thread thread in threads) {
					result += thread.Name +": "+thread.ThreadState +" ";
				}
			    Console.WriteLine(result);
			}
			
		}
		
		public static void runExample (int ploops)
		{
			
			loops = ploops;
			Console.WriteLine ("Hello World!");
			List<String> outputs = new List<String> ();
			outputs.Add ("A      ");
			outputs.Add ("   B   ");
			outputs.Add ("      C");
			List<Thread> threads = new List<Thread> ();
			foreach (String output in outputs) {
				Thread aThread =
    			new Thread (LoopMethod);		
				aThread.Name = output;
				threads.Add (aThread);
			}
			ThreadStates (threads,1);
			foreach (Thread aThread in threads) {
			
				aThread.Start ();
			}
			
			ThreadStates (threads,ploops);
			//Thread.Sleep(10000);
			Console.WriteLine ("Finished");
		}
	}
}


