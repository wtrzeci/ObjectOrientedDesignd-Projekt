using ObjectOrientedDesigndProject.classes_Base;
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
        static Queue<String> messageQueue = new Queue<string>(); 
    

        public static void GetCommands(Bitflix bitflix)
        {
            Console.WriteLine("Please input commands:");
            while(true)
            {
                var line = Console.ReadLine();
                if (line == "queue commit")
                    ProcessCommands(bitflix);
                else if (line == "EXIT")
                    break;
                else if (line == "queue print")
                    PrintQueue();
                else
                    addMessagesToTheQueue(line);
                Console.WriteLine("Awaiting next command");
            }
        }
        private static void PrintQueue()
        {
            foreach(var command in messageQueue)
            {
                Console.WriteLine(command);
            }
        }
        private static void ProcessCommands(Bitflix bitflix)
        {
            foreach (var line in messageQueue)
            {
                string[] parsed = line.Split(' ');
                string command = parsed[0];
                string[] args = parsed.Skip(1).ToArray();
                switch (command)
                {
                    case "list":
                        Console.WriteLine("PRINTING LIST:");
                       
                        PrintListOfType(args[0], bitflix);
                        break;
                    case "find":
                        Console.WriteLine("FINDING");
                        if ((args.Length - 1) % 3 != 0) { throw new Exception("List of Args has to be divisible by 3"); }
                        PrintListWithRequaierments(args, bitflix);
                        break;
                    case "EXIT":
                        return;
                        break;
                    case "add":
                        Console.WriteLine("ADDING OBJECT");
                        AddObjectToList(args, bitflix);
                        break;
                    case "edit":
                        Console.WriteLine("EDITING OBJECT");
                        UpdateRecordsWithGivenRequierment(bitflix, args);
                        break;
                    default:
                        Console.WriteLine(line + " unrecognized command");
                        break;
                }

            }
            messageQueue.Clear();

        }
        private static void addMessagesToTheQueue(string line)
        {
            messageQueue.Enqueue(line);
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
        private static void UpdateRecordsWithGivenRequierment(Bitflix bitflix,string[] args)
        {

            dynamic obj = bitflix.GetTableOfName(args[0]);
            Func<object, object, bool> func = bitflix.GetFuncOfName(args[2]);

            for (int i=0; i < obj.Count; i++)
            {
                object tmp = obj[i];
                InterfaceBasse temp = tmp as InterfaceBasse;
                if (temp.Properties()[args[1]] is int)
                {
                    if (func(temp.Properties()[args[1]], int.Parse(args[3])))
                    {
                        tmp= UpdateObject(ref temp, bitflix);
                    }
                }
                else if (temp.Properties()[args[1]] is string)
                {
                    if (func(temp.Properties()[args[1]], args[3]))
                    {
                        tmp= UpdateObject(ref temp, bitflix);
                    }
                }
                
                obj[i] = tmp as dynamic;
            }

        }
        private static object UpdateObject(ref InterfaceBasse temp, Bitflix bitflix)
        {
            int i = 0;
            var values = new List<string>();
            foreach (var temp2 in temp.Properties().Values)
            {
                if (temp2 is string)
                     values.Add((string)temp2);
                else
                {
                    values.Add(temp2.ToString());
                }

            }

        for (; ; )
            {
                foreach (string temp2 in temp.Properties().Keys)
                {
                    Console.Write(temp2 + ": ");
                    string value = Console.ReadLine();

                    if (value == "EXIT")
                    {
                        return null;
                    }
                    else if (value == "DONE")
                    {
                        goto Done;
                    }
                    else if (value != null)
                    {
                        
                        Console.WriteLine(i % temp.Properties().Keys.Count);
                        values[i % temp.Properties().Keys.Count] = value;
                        
                    }
                    i++;
                }
               
            }
            Done:
            var final = temp as ListInnitializable;
            final.SetValuesWithList(values, bitflix);
            return final;
        }
        private static void AddObjectToList(string[] args, Bitflix bitflix)
        {
            string _tableName = args[0];
            if (args[0]!= "series")
            {
                _tableName += "s";
            }
            
            dynamic obj,second;
            if (args[1] == "secondary")
            {
                second = bitflix.GetTableOfName(_tableName);
                obj = bitflix.GetTableSecondaryOfName(_tableName);
            }
            else
            {
                second = bitflix.GetTableSecondaryOfName(_tableName);
                obj = bitflix.GetTableOfName(_tableName);
            }
            dynamic temp = obj[0];
            List<string> values = new List<string>();
            Type type = temp.GetType();
            int i = 0;
            for (;;)
            {
                foreach (string temp2 in temp.Properties().Keys)
                { 
                    Console.Write(temp2 + ": ");
                    string value = Console.ReadLine();
                    
                     if (value == "EXIT")
                    {
                        return;
                    }
                    else if (value == "DONE")
                    {
                        goto Done;
                    }
                    else if (value != null)
                    {
                        if (i < temp.Properties().Keys.Count)
                            values.Add(value);
                        else
                        {
                            Console.WriteLine(i % temp.Properties().Keys.Count );
                            values[i % temp.Properties().Keys.Count ] = value;
                        }
                    }
                    i++;
                }
            }
            Done:
            while (values.Count <= temp.Properties().Keys.Count)
            {
                values.Add("-1");
            }
            dynamic instance = Activator.CreateInstance(type);
            instance.SetValuesWithList(values,bitflix);
            if (args[1] == "secondary")
            {
                dynamic baseRep = instance.ChangeToBase(instance);
                second.Add(baseRep);
            }
            obj.Add(instance);
        }
    }
   
}
