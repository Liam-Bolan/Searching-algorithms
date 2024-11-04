using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Searching_algorithms
{

    class Program
    {
        
  

	public static void Main()
	{
		//create data
		//2000 random numbers from 1 to 1000 in locations 1..2000
        int[] data = new int[2001];
        int min = 1;
	    int max = 2000;
        Random r= new Random();
        for (int i = 0; i < 2001; i++)
			{
			 data[i]=r.Next(1,1001);
			}

        //sort the array - we need to do this for the binary search to work.
        Array.Sort(data);
        
        //display

        for (int i = 0; i < 2001; i++)
        {
            Console.Write(data[i]+",");
        }
        Console.WriteLine();

        //SEARCH TIME!
		int wanted = 0;
        bool tryagain = true;

            while (tryagain == true)
            {
                Console.Write("\nEnter Number to Locate : ");
                wanted = int.Parse(Console.ReadLine());
                while (wanted > 2000)
                {
                    Console.Write("\nEnter again : ");
                    wanted = int.Parse(Console.ReadLine());
                }

                int BSearch = BinarySearch(data, min, max, wanted);
                int LinSearch = LinearSearch(data, min, max, wanted);
                Console.Write("\nBinary Search search needed {0} searches\nLinear Search needed {1} searches", BSearch, LinSearch);
                Console.Write("\n\nWould you like to search again? (y/n): ");
                string option = Console.ReadLine();
                if(option == "n")
                {
                    return;
                }
                if(option == "y")
                {
                    tryagain = true;
                }
            }
		
	}


	public static int BinarySearch(int[] data, int min, int max, int wanted)
	{
        int NoOfSearchesRequired = 0;
        bool found = false;
        int mid = 0;
        int high = max;
        int low = min;
       
        while(found == false && high >=low)
            {
                NoOfSearchesRequired += 1;
                mid = (high + low) / 2;
                if (data[mid] == wanted)
                {
                    found = true;
                }
                if (data[mid] > wanted)
                {
                    high = mid - 1;
                }
                if (data[mid] < wanted)
                {
                    low = mid + 1;
                }
            }

        
        return NoOfSearchesRequired;

    }

    public static int LinearSearch(int[] data,int min, int max, int wanted)
    {

            int NoOfSearchesRequired = 0;
            bool found = false;
            int count = 0;
            while (found == false && count <= 2000)
            {
                NoOfSearchesRequired += 1;
                if (data[count] == wanted)
                {

                    found = true;
                }
                else
                {

                    count++;
                }
                
            }
            return NoOfSearchesRequired;


            
    }

}

}
  