using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrencyExamples
{
	public class ThreadExample08
	{
		public ThreadExample08 ()
		{
		}
		
		static int cycleWatch1 = 0;
		static int cycleWatch2 = 0;
		static readonly object locker1 = new object ();
		static readonly object locker2 = new object ();
		public static int loops = 4000;
		
		public static void LoopMethod ()
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				lock (locker1) {
					int temp = cycleWatch1;
					cycleWatch1 = temp + 1;
					lock(locker2){
						cycleWatch2++;
					}
				}
				Console.WriteLine (Thread.CurrentThread.Name + " - " + i + " " + cycleWatch1 + " " + cycleWatch2);
				//Thread.Sleep(5);
			}		
		}
		public static void LoopMethod2 ()
		
		{
			Console.WriteLine ("Hello World from Thread!");
			for (int i=0; i<loops; i++) {
				lock (locker2) {
					int temp = cycleWatch2;
					cycleWatch2 = temp + 1;
					lock(locker1){
						cycleWatch1++;
					}
				}
				Console.WriteLine (Thread.CurrentThread.Name + " - " + i + " " + cycleWatch1 + " " + cycleWatch2);
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
			List<Thread> threads = new List<Thread> ();
			int i = 0;
			foreach (String output in outputs) {
				Thread aThread;
				if (i++ % 2 == 0){
					aThread = new Thread (LoopMethod);
				} else {				
					aThread = new Thread (LoopMethod);
				}
				aThread.Name = output;
				threads.Add (aThread);
				aThread.Start ();
				Thread.Sleep(10);
			}
			
			foreach(Thread thread in threads){
				thread.Join();
			}
			Console.WriteLine ("Finished");
			Console.WriteLine ("cycleWatch1: " + cycleWatch1);
			Console.WriteLine ("cycleWatch2: " + cycleWatch2);
			
		}
	}
}


