using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject
{
    internal static class CommandLineUtility
    {
    

        public static void GetCommands(Bitflix bitflix)
        {
            Console.WriteLine("Please input commands:");
            while(true)
            {
                var line = Console.ReadLine();
                string[] parsed = line.Split(' ');
                string command = parsed[0];
                string[] args = parsed.Skip(1).ToArray();
                switch (command)
                {
                    case "list":
                        Console.WriteLine("PRINTING LIST:");
                        if(args.Length != 1) { throw new Exception("wrong numbner of args!"); }
                        PrintListOfType(args[0],bitflix);
                        break;
                    case "find":
                        Console.WriteLine("FINDING");
                        if ((args.Length-1) %3 != 0) { throw new Exception("List of Args has to be divisible by 3"); }
                        PrintListWithRequaierments(args, bitflix);
                        break;
                    case "exit":
                        return;
                        break;
                    case "add":
                        Console.WriteLine("ADDING OBJECT");
                        AddObjectToList(args, bitflix);

                        break;
                    default:
                        throw new Exception("UNRECOGNIZED COMMAND");
                }
                Console.WriteLine("Awaiting next command");
            }
        }
        private static void PrintListOfType(string objectName, Bitflix bitflix)
        {
            dynamic obj =bitflix.GetTableOfName(objectName);
            foreach (var item in obj)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private static void PrintListWithRequaierments(string[] args, Bitflix bitflix)
        {
            dynamic obj = bitflix.GetTableOfName(args[0]);
            Func<object, object, bool> func = bitflix.GetFuncOfName(args[2]);

            foreach (dynamic temp in obj)
            {
                if (temp.Properties()[args[1]] is int)
                {
                    if (func(temp.Properties()[args[1]], int.Parse(args[3])))
                    {
                        Console.WriteLine(temp);
                    }
                }
                else if (temp.Properties()[args[1]] is string)
                {
                    if (func(temp.Properties()[args[1]], args[3]))
                    {
                        Console.WriteLine(temp);
                    }
                }
            }
        }
        private static void AddObjectToList(string[] args, Bitflix bitflix)
        {
            string _tableName = args[0] + "s";
            dynamic obj;
            if (args[0] == "base")
                obj =bitflix.GetTableSecondaryOfName(_tableName);
            else
                obj = bitflix.GetTableOfName(_tableName);
            dynamic temp = obj[0];
            List<string> values = new List<string>();
            Type type = temp.GetType();
            foreach (string temp2 in temp.Properties().Keys)
            {
                Console.Write(temp2 + ": ");
                string value = Console.ReadLine();
                if (value != null)
                {
                    values.Add(value);
                }
                else if ( value == "EXIT" )
                {
                    return;
                }
            }
            dynamic instance = Activator.CreateInstance(type);
            instance.SetValuesWithList(values);
            obj.Add(instance);
        }
    }
   
}
