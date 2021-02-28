using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Data_Structure_Exercise
{
    class PrintReverse {

        public void Start() {
            Input inputCondition1 = new Input("First you must type the number of values you want to input.\n");
            Input inputObject1;
            string inputString;
            int valueCount;

            Console.Clear();
            Console.WriteLine("This program prints the values you input, in the reverse order of your input sequence.\n");

            inputCondition1.DisplayInputConditions();
            do {
                inputString = Console.ReadLine();
                inputObject1 = new Input(inputCondition1.inputConditions, inputString, @"^[1-9][0-9]*$");
            }
            while (inputObject1.TestInputSyntax() == false);
            valueCount = short.Parse(inputObject1.inputString);
            Print(valueCount);
        }

        public void Print(int valueCount) {
            Input numberTest = new Input();
            numberTest.inputConditions = "You must now type a number; any in the set of Real numbers.\n";
            int neededNumbers = 0;

            NumberValue[] NV =  new NumberValue[valueCount];
            Stack myStack = new Stack();
            do {
                Console.Clear();
                Console.WriteLine(numberTest.inputConditions + "\n");
                Console.WriteLine("You have input " + neededNumbers + " out of " + valueCount + "\n");
                numberTest.inputString = Console.ReadLine();
                numberTest.regExString = @"^[+|-]?\d*\.?\d*$";

                if (numberTest.TestInputSyntax()) {
                    float acceptedFloat = float.Parse(numberTest.inputString);
                    NV[neededNumbers].index = neededNumbers;
                    NV[neededNumbers].value = acceptedFloat;
                    myStack.Push(NV[neededNumbers].value);
                    neededNumbers++;
                }

            }
            while (neededNumbers < valueCount);

            Console.Clear();
            Console.WriteLine("Reverse output:\n");

            while (myStack.Count > 0) {
                Console.WriteLine("Value-" + (myStack.Count-1) + " =\t" + myStack.Peek());
                myStack.Pop();
            } 


        }

        public struct NumberValue {
            public int index;
            public float value;
            //public Dictionary<int, float> myFloats;

            public NumberValue (int ii, float ff ) {
                index = ii;
                value = ff;
            }

        }


    }
}
