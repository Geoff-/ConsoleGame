using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Matrix
    {
        //statics
        protected static int MAXROWS {get{return 10;}}
        protected static int MAXROWS {get{return 10;}}
        private static int DEFAULTRETURNVALUE = 0;
        //vars
        private int _columns;
        private int _rows;
        public int columns { get { return _columns; } }
        public int rows { get { return _rows; } }
        public int nItems { get { return _columns * _rows; } }
        public int[] matrix;

        public int this[int c, int r]
        {
            get
            {
                int index = (r * columns + c);
                if (index > nItems)
                {
                    Console.WriteLine("Out of bounds array index given (Get matrix item)!!!!! \nReturning default value {0}", DEFAULTRETURNVALUE);
                    return DEFAULTRETURNVALUE;
                }
                return matrix[index];
            }
            set
            {
                int index = (r * columns + c);
                if (index > nItems)
                {
                    Console.WriteLine("Out of bounds array index given (Set matrix item)!!!!! \nNothing was changed");
                }
                matrix[index] = value;
            }
        }
        public int[] Column(int c)
        {
            //define the size of the array that will be returned
            int returnSize = rows;
            int[] returnArray = new int[returnSize];
            for (int i = c * rows; i < c * rows; i++)
            {
                //......................
            }
        }

        //define Row class to return row also

        //define multiplication

        //define inverse / det / divide

        public Matrix(int nCols,int nRows)
        {
            _columns = nCols;
            _rows = nRows;
            Array.Resize(ref matrix, nItems);

            for (int i = 0; i < nItems; i++)
            {
                matrix[i] = 0;
            }

        }
    }
}
