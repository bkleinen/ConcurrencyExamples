using System;
using System.Threading;

class TreadExampleMSDNPriority
{
    public static void Run()
    {
        PriorityTest priorityTest = new PriorityTest();
        ThreadStart startDelegate = 
            new ThreadStart(priorityTest.ThreadMethod);

        Thread threadOne = new Thread(startDelegate);
        threadOne.Name = "ThreadOne";
        Thread threadTwo = new Thread(startDelegate);
        threadTwo.Name = "ThreadTwo";

        threadTwo.Priority = ThreadPriority.Highest;
        threadOne.Start();
        threadTwo.Start();
		    threadTwo.Priority = ThreadPriority.Highest;
    
        // Allow counting for 10 seconds.
        Thread.Sleep(1000);
        priorityTest.LoopSwitch = false;
    }
}

class PriorityTest
{
    bool loopSwitch;

    public PriorityTest()
    {
        loopSwitch = true;
    }

    public bool LoopSwitch
    {
        set{ loopSwitch = value; }
    }

    public void ThreadMethod()
    {
        long threadCount = 0;

        while(loopSwitch)
        {
            threadCount++;
        }
        Console.WriteLine("{0} with {1,11} priority " +
            "has a count = {2,13}", Thread.CurrentThread.Name, 
            Thread.CurrentThread.Priority.ToString(), 
            threadCount.ToString("N0")); 
    }
}

