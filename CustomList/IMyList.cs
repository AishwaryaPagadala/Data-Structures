using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSCustomList
{
    public interface IMyList<T>
    {
        /// <summary>
        ///This is an interface containing functionalities of a list.
        /// </summary>
       
        void Add(T inputObject);
        void Remove(T inputObject);

        void InsertAt(int index,T inputObject);

        void SortAsc();

        void SortDesc();

        bool Contains(T inputObject);

        int IndexOf(T inputObject);



    }
}
