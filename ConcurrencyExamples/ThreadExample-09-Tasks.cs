// http://msdn.microsoft.com/en-us/library/dd460717.aspx
using System;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Generic;


namespace ConcurrencyExamples 
{
	public class ThreadExample09
	{
		public ThreadExample09 ()
		{
		}

		public static int loops = 4000;
		
		public static string LoopMethod (Object output)
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				Console.WriteLine (output + " - " + i);
			} 
			return output + " is DONE.";
		}

		public static void runExample (int ploops)
		{
			loops = ploops;
			Console.WriteLine ("###############################");
			Console.WriteLine ("Hello World!");
			
			Task t1 = new Task<string>(() => {return LoopMethod("A      ");});
			Task t2 = new Task<string>(() => LoopMethod("   B   "));
			Task t3 = new Task<string>(() => LoopMethod("      C"));
		
			t1.Start();
			t2.Start();
			t3.Start();
			//Thread.Sleep(10);
			t1.Wait();
			t2.Wait();
			t3.Wait();
			
			Task.Factory.StartNew<int>(()=> 1)
				.ContinueWith(task => task.Result +2)
				.ContinueWith(task => task.Result +3)
				.ContinueWith(task => Console.WriteLine("task result: "+task.Result));
		
			Thread.Sleep(10000);
			  
			Task.Factory.StartNew<string>(()=>LoopMethod("A"))
				.ContinueWith(task => task.Result + LoopMethod ("B"))
				.ContinueWith(task => Console.WriteLine("task result: "+task.Result));
			Thread.Sleep(1000000);
			Console.WriteLine ("Finished");
		
			                                          }
	}
}

