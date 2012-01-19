using System;

using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample03
	{
		public ThreadExample03 ()
		{
		}

		public static int loops = 4000;
		
		private static void LoopMethod (Object output)
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				Console.WriteLine (output + " - " + i + " P "+Thread.CurrentThread.Priority);
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
				new Thread (new ParameterizedThreadStart(LoopMethod));		
				aThread.Start (output);
				aThread.Name = output;
				threads.Add (aThread);
				aThread.Priority = ThreadPriority.AboveNormal;
				Console.WriteLine("Thread "+output + " P "+ aThread.Priority);
			}
			threads[0].Priority=ThreadPriority.AboveNormal;
			threads[1].Priority=ThreadPriority.Normal;
			threads[2].Priority=ThreadPriority.BelowNormal;
			
			//newThread.Abort();
			
			Console.WriteLine ("Finished");
		}
	}
}

