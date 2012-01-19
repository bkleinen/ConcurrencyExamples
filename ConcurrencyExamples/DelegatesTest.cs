
using System;
using NUnit.Framework;

namespace ConcurrencyExamples
{
	[TestFixture()]
	public class DelegatesTest
	{
		
		[Test()]
		public void SimpleLambda ()
		{
			//given
			String parameter = "the parameter";
			String expected =  "Hi. I'm a Delegate and received " + parameter + " as a Parameter";
			Func<string,string> myFunc =  var1 => "Hi. I'm a Delegate and received " + var1 + " as a Parameter";
			//when
			String result = myFunc(parameter);
			//then
			Assert.AreEqual(expected,result);
		}
		[Test()]
		public void SimpleDelegate ()
		{
			//given
			String parameter = "the parameter";
			String expected =  "Hi. I'm a Delegate and received " + parameter + " as a Parameter";
			Func<string,string> myFunc = delegate(string var1)
			{
				return "Hi. I'm a Delegate and received " + var1 + " as a Parameter";
			};
			//when
			String result = myFunc(parameter);
			//then
			Assert.AreEqual(expected,result);
		}
		
		Func<String,String> createClosure(){
			String localValue = "the bound value";
			Func<string,string> myFunc = var1 => "Hi. I'm a Delegate and received " + var1 + " as a Parameter" 
				+ " and add a local variable: " + localValue;
			return myFunc;					
		}
		
		[Test]
		public void SimpleLambdaActingAsClosure ()
		{
			//given
			String parameter = "the parameter";
			String expected =  "Hi. I'm a Delegate and received " + parameter + " as a Parameter";
			expected += " and add a local variable: the bound value";
			Func<string,string> myFunc = createClosure();
			//when
			String result = myFunc(parameter);
			//then
			Assert.AreEqual(expected,result);
		}
		
	}
}

