using System;
namespace Notes
{
    public class DataTypes
    {
        public DataTypes()
        {

            Console.WriteLine("Hello World!");


//ARRAYS
            string[] stringArr = new string[4];
            int[] intArr;
            intArr = new int[6];                                   
            bool[] boolArr = { true, false, true, false, true };   // 0 based, index starts at 0


// LISTS
            // essentially just ArrayLists
            List<int> intList = new List<int>();   
            intList.Add(5);
            intList.Add(20);
            intList.Remove(5);     //looks for value        
            intList.RemoveAt(0);    //looks for index

            // Lists auto rebase (automatically shift numbers if you remove)
            //you can easily convert a list to an array


// DICTIONARIES
            // Associative Arrays
            // mix & match data types
            Dictionary<int, string> newDict = new Dictionary<int, string>();
            newDict.Add(5, "Bob");              
            newDict.Add(-1, "Chris");           
            newDict.Remove(5);   // Remove() only takes the key


//LOOPS
            // i++ --> post processor
            // ++i --> pre processor
            // doesn't matter in for loops, just use the first one
            // i-- --> decrement (less efficient?)
            // break; --> breaks a loop no matter what
            for (int i=0; i<5; i++)
            {
                // iterate over a specified number of loops
            }

            int sum = 0;
            foreach (int number in intList) 
            {
                sum += number;
                Console.WriteLine(number);
                // iterate over every item in a collection
            }
            Console.WriteLine(sum);
            Console.ReadLine();
            
            foreach(KeyValuePair<int, string> item in newDict)
            {
                Console.WriteLine("(0) - (1)", item.Key, item.Value);    // how to format key value pairs???
            }

            Console.ReadLine();

//STRINGS
            // array of chars
            string words = "Hello world";
            foreach (char c in words)
            {
                Console.WriteLine((char)(c+1));    // you can add to a character
            }

            byte littleNum = 5;
            long bigNum = (long)littleNum;  //if you get casting wrong your code will c r a s h 

            Console.ReadLine();
        }
    }
}
