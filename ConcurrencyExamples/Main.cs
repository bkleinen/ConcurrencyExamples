using System;


namespace ConcurrencyExamples
{
	class MainClass
	{
		public static void runAll(){
			int loops = 3;
			ThreadExample01.runExample(loops);
			ThreadExample02.runExample(loops);
			ThreadExample03.runExample(loops);
			ThreadExample04.runExample(loops);
			ThreadExample05.runExample(loops);
			ThreadExample06.runExample(loops);
			ThreadExample07.runExample(loops);
			ThreadExample08.runExample(loops);
			ThreadExample09.runExample(loops);

		}
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			
			//runAll ();
			int zwei = 2000;
			//ThreadExample01.runExample(zwei);
			//ThreadExample02.runExample(zwei);
			//ThreadExample03.runExample(zwei);
			//ThreadExample04.runExample(zwei);
			//ThreadExample05.runExample(zwei);
			//ThreadExample06.runExample(20);
			//ThreadExample07.runExample(zwei);
			//ThreadExample08.runExample(zwei);
			ThreadExample09.runExample(20);
			
			//TreadExampleMSDNPriority.Run();
			//ThreadExample_MSDN_Semaphore.runExample();
			//TestEvents.Test.runExample();
	
		}
	}
}
// http://msdn.microsoft.com/en-us/library/ms173178.aspx