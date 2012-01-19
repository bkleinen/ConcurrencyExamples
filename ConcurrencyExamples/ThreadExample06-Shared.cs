using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample06
	{
		public ThreadExample06 ()
		{
		}
		
		static int cycleWatch =0;
			
		public static int loops = 4000;
		
		public static void LoopMethod ()
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				
				//int temp = cycleWatch;
				//cycleWatch = temp + 1;
				cycleWatch++;
				Console.WriteLine (Thread.CurrentThread.Name + " - " + i + " " +cycleWatch);
				//Thread.Sleep(5);
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
				aThread.Start ();
			}

			Console.WriteLine ("Finished");
		}
	}
}


