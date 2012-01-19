using System;

using System.Collections;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample04
	{
		public ThreadExample04 ()
		{
		}

		public static int loops = 4000;
		
		public static void LoopMethod (String output)
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				Console.WriteLine (output + " - " + i);
			}		
		}

		public static void runExample (int ploops)
		{
			
			loops = ploops;
			Console.WriteLine ("Hello World!");
			ArrayList outputs = new ArrayList ();
			outputs.Add ("A      ");
			outputs.Add ("   B   ");
			outputs.Add ("      C");
			foreach (String output in outputs){
			System.Threading.Thread aThread =
    			new System.Threading.Thread (() => LoopMethod (output));
		    // Background Threads are terminated as soon as the main thread terminates.
		    aThread.IsBackground = true;
			aThread.Start ();
			}
			
			//newThread.Abort();
			Thread.Sleep(10);			
			
			Console.WriteLine ("Finished");
		}
	}
}

