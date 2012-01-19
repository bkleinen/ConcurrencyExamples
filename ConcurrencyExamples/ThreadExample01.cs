using System;

using System.Collections;

namespace ConcurrencyExamples
{
	public class ThreadExample01
	{
		public ThreadExample01 ()
		{
		}

		public static int loops = 4000;
		
		public static void LoopMethod ()
		{
			// just to create an example w/o parameters
			LoopMethod ("A");
		}

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
			// an example without parameters
			System.Threading.Thread cThread =
    			new System.Threading.Thread (LoopMethod);
			cThread.Start ();
	
			
			Console.WriteLine ("Finished");
		}
	}
}

