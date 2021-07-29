using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace FSSCustomList 
{
    /// <summary>
    /// This class is an implementation of IMyList interface. 
    /// It contains methods relating to a list like add,remove,
    /// contains,index of,sort and inserting at a particular position in the list.
    /// </summary>

    public class MyList<T> : IMyList<T>, IEnumerable, IEnumerator where T : IComparable<T>, IEquatable<T>
    {
        private T[] MyArray;                     //Array to implement list
        private int MyIndex { get; set; }        // current index of array
        private int position = -1;               //foreach current index
        private const int SIZE = 5;              // size of array

        //Overriding IEnumerator property
        Object IEnumerator.Current { get { return MyArray[position]; } } 

        //constructor
        public MyList()
        {
            MyArray = new T[SIZE];
            MyIndex = 0;
        }

        // Indexer
        public T this[int key]  
        {
      
               get{
                    if (key < MyIndex && key>-1)
                        return MyArray[key];
                    else
                        throw new Exception("invalid index");
                  }

               set{
                    if (key < MyIndex && key>-1)
                        MyArray[key] = value;
                   else
                      throw new Exception("invalid index");
                  }
        }

        // Resizes the array when arrays max capacity is reached
        private void ResizeArray( int size)
        {
            T[] newArray= new T[ MyArray.Length + size];
            //Copying elemnts of array to the new array 
            for (int iterator = 0; iterator < MyArray.Length; iterator++)
            {
                newArray[iterator] = MyArray[iterator];
            }

            MyArray = newArray;
        }

        // Recieves an object and adds to the end of the list
        public void Add(T inputObj)
        {
            if (inputObj == null)
                throw new InvalidOperationException("Invalid: Can not pass null");

            //checks max capacity of array prior adding
            if (MyIndex == MyArray.Length)     
                ResizeArray(SIZE);

            MyArray[MyIndex] = inputObj;
            MyIndex++;
        }
         
        //Checks whether the element is present in list or not. 
        public bool Contains(T inputObj)
        {
            if (inputObj == null)
                throw new InvalidOperationException("Invalid: Can not pass null");

            for (int iterator =0; iterator <MyIndex;iterator ++)
            {
                if (MyArray[iterator ].Equals(inputObj))
                    return true;  // element found
            }

            return false; // element not found
        }

        // method returns the index of the input object 
        public int IndexOf(T inputObj)
        {
            if (inputObj == null)
                throw new InvalidOperationException("Invalid: Can not pass null");

            for (int iterator = 0; iterator < MyIndex; iterator++)
            {
                if (MyArray[iterator].Equals(inputObj))
                    return iterator;
            }
            return -1;     // element not present 
        }

        // The passed object gets inserted at the specified index.
        public void InsertAt(int index, T inputObj)
        {
            if ((index <0 || index>=MyIndex))
                throw new IndexOutOfRangeException ("Invalid Index");

            //checking size of array before insertion
            if (MyIndex == MyArray.Length) 
                ResizeArray( SIZE);

            // shifting elements to next index 
            for (int iterator = MyIndex; iterator > index ; iterator--) 
            {
                MyArray[iterator] = MyArray[iterator-1];
            }
            // inserting the object into the list
            MyArray[index] = inputObj; 
            MyIndex++;

        }

        // Removes the object from list
        public void Remove(T inputObj)
        {
           
            if (inputObj == null)
                throw new InvalidOperationException("Invalid: Can not pass null");

            //finding index of the object to be removed
            int index = IndexOf(inputObj);

            // If object is not present in the list
            if (index == -1)
                throw new InvalidOperationException("Object not found");

            for (int iterator = index; iterator < MyIndex-1; iterator++)
            {
                MyArray[iterator] = MyArray[iterator + 1];
            }
           
            MyIndex--; 

        }

        //sorts list according to the flag value (Ascending order=1 / Descending order=-1)
        private void Sort(int flag)
        {
           // using selection sort technique
           
                int minMaxIndex;       
                for (int iterator = 0; iterator < MyIndex - 1; iterator++)
                {
                    minMaxIndex = iterator;
                for (int innerIterator = iterator + 1; innerIterator < MyIndex; innerIterator++)
                {
                    //checks based on flag value passed
                    if (flag == 1 ? (MyArray[minMaxIndex].CompareTo(MyArray[innerIterator]) >= 0) : (MyArray[minMaxIndex].CompareTo(MyArray[innerIterator]) <= 0))
                        minMaxIndex = innerIterator;
                }
                    T temp;
                    temp = MyArray[iterator];
                    MyArray[iterator] = MyArray[minMaxIndex];
                    MyArray[minMaxIndex] = temp;

                }
            
         }

        //sorts list in ascending order
        public void SortAsc()
        {
            //calls sort method with flag value 1.
            Sort(1);                        
        }

        //sorts list in descending order
        public void SortDesc()
        {
            // calls sort method with flag value -1.
            Sort(-1);
        }
                         

        //overriding IEnumerator method.
        public bool MoveNext()
        {
            //moves to the next index
            position++;
            return (position < MyIndex );
        }

        //resets the index for multiple usage of foreach.
        public void Reset()
        {
            position =-1;
        }
        //overriding GetEnumerator method.
        public IEnumerator  GetEnumerator()
        {
            Reset();
            return this;
        }
      
    }
}

