using System;
using System.Threading;

namespace NewSchoolProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // we have to call class to extract functions
            TeacherFunc teacherFunc = new TeacherFunc ();
            Console.WriteLine("\n \n > Welcome To RainBow School System For Teachers Data Like :\n\t\t\t\t\t\t\t> Create\n\t\t\t\t\t\t\t > Search\n\t\t\t\t\t\t\t> GET\n\t\t\t\t\t\t\t> Update\n");
            bool BoolValue = true;
            while (BoolValue)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n     Select Number  ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n 1- Get All Teachers \n 2- Add Teacher \n 3- Search for Teacher \n 4- Update Teacher informations  \n 5- Exit");

               
                int? select = null;
                try
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("                > ");
                    int SelectedService = int.Parse(Console.ReadLine());
                    select = SelectedService;
                }
                catch (Exception C0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(C0.Message.ToString());

                }
                switch (select)
                {
                    case 2:

                        try
                        {
                            Console.Write("Enter ID : ");
                            int Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter teacher Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Class Name : ");
                            string _class = Console.ReadLine();
                            Console.Write("Section Name : ");
                            string _section = Console.ReadLine();
                            teacherFunc.AddNew(Id, name, _class, _section);

                        }
                        catch (Exception C1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(C1.Message.ToString());

                        }
                        break;

                    case 3:
                        Console.Write(" Search By ID  >");
                        int isearch = int.Parse(Console.ReadLine());
                        TeacherData tsearch = teacherFunc.GetById(isearch);

                        if (tsearch != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("> Teacher Data Retrived Successfully");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($" ID :{tsearch.ID}\n > Name:{tsearch.Name} \n > Class:{tsearch.TClass}\n > Section: {tsearch.TSection}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n inserted ID: {isearch} Wrong ID Try Again !");
                        }
                        break;

                    case 4:
                        Console.Write("Insert ID to Update > ");
                        int oID = int.Parse(Console.ReadLine());
                        TeacherData upteacher = teacherFunc.GetById(oID);
                        if (upteacher != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(" > Data Retrived To Updates");
                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine($"> ID: {upteacher.ID}\n> Name: {upteacher.Name}\n> Class: {upteacher.TClass}\n> Section: {upteacher.TSection}");
                            Console.WriteLine("\n> Insert New informations : ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            int oldi = upteacher.ID;
                            Console.Write("\n>  new ID : ");
                            int new_i = int.Parse(Console.ReadLine());
                            Console.Write(">  New Name : ");
                            string newN = Console.ReadLine();
                            Console.Write("> New Class : ");
                            string newC = Console.ReadLine();
                            Console.Write("> New Section : ");
                            string NewSec = Console.ReadLine();
                            teacherFunc.Update(oldi, new_i, newN, newC, NewSec);
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\n Wrong ID:{ oID} Try Again");
                        }
                        break;
                        case 5:
                        BoolValue = false;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n >>>> Thank U am Here For Your Service <<<< ");
                        Thread.Sleep(1000);
                        break;

                    case 1:

                        var AllT = teacherFunc.GetAll();
                        if (AllT != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("> Teacher Data Retrived Successfully");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            if (AllT.Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Empty Record Add Teacher !");
                            }
                            else
                            {
                                foreach (var T in AllT)
                                {

                                    Console.WriteLine(T);
                                }
                            }


                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Hi There What Should I Do To Help U ? ");
                        break;


                }
            }
        }
    }
}