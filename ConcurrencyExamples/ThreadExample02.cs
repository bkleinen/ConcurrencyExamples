using System;

using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample02
	{
		public ThreadExample02 ()
		{
		}

		public static int loops = 4000;
		
		public static void LoopMethod (Object output)
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
			//	Console.WriteLine (output + " - " + i);
				
				Console.WriteLine (output + " - " + i);
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
			foreach (String output in outputs){
				Thread aThread =
    				new Thread (new ParameterizedThreadStart(LoopMethod));	
				aThread.Name = output;
				aThread.Start (output);
			}
			
			//newThread.Abort();
			
			Console.WriteLine ("Finished");
		}
	}
}

