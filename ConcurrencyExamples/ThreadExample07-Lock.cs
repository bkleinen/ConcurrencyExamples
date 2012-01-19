using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample07
	{
		public ThreadExample07 ()
		{
		}
		
		static int cycleWatch = 0;
		static readonly object locker = new object ();
		public static int loops = 4000;
		
		public static void LoopMethod ()
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				lock (locker) {
					int temp = cycleWatch;
					cycleWatch = temp + 1;
				}
				Console.WriteLine (Thread.CurrentThread.Name + " - " + i + " " + cycleWatch);
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
			outputs.Add ("      4");
			outputs.Add ("      5");
			outputs.Add ("      6");
			outputs.Add ("      7");
			outputs.Add ("      8");
			outputs.Add ("      9");
			outputs.Add ("      10");
			outputs.Add ("      11");
			outputs.Add ("      12");
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


