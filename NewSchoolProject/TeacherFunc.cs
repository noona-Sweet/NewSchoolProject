using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace NewSchoolProject
{
    class TeacherFunc
    {
        private readonly string path;
        StreamWriter writer;
        public TeacherFunc()
        {
            path = @"C:\Users\DELL\Desktop\project_phase1\NewSchoolProject\Teachers.txt";
            if (!File.Exists(path))
            {
                var mfile = File.Create(path);
                mfile.Close();
            }
        }

        public void AddNew(int ID, string Name, string TClass, string TSection)
        {
            // to make writer load file and start adding text
            writer = File.AppendText(path);

            string newTeacher = ID + "," + Name + "," + TClass + "," + TSection;
             //add this newTescher to text file
            writer.Write(newTeacher);

            //display msg after added
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" New Teacher Data added successfully");
            // we have to close the writer after we finish!
            writer.Close();

        }

        // here we want to get all teachers data from file
        // we will use File.ReadAllLine
        // Read all lines help to get all text lines from file and display it
        public string[] GetAll()
        {
            //we will use File.ReadAllLine
            var teachears = File.ReadAllLines(path);
            return teachears;
        }
        //get teacher by id
        //user will send us id from console to make search!
        public TeacherData GetById(int id)
        {
            string[] record = File.ReadAllLines(path);
            foreach (string A in record)
            { 
                string[] oneTec = A.Split(',');
                try
                {

                    if (int.Parse(oneTec[0]) == id)
                    {

                        TeacherData teachers = new  TeacherData
                        {
                            ID = int.Parse(oneTec[0]),
                            Name = oneTec[1],
                            TClass = oneTec[2],
                            TSection = oneTec[3]
                        };
                        return teachers;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return null;
        }
        public void Update(int oldid, int Newid, string Nname, string NClas, string NSec)
        {
            string[] lines = File.ReadAllLines(path);
            bool status = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('-');
                if (int.Parse(line[0]) == oldid)
                {
                    lines[i] = Newid + "-" + Nname + "-" + NClas + "-" + NSec;
                    status = true;
                }
            }
            if (status)
            {
                File.WriteAllLines(path, lines);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" > Teacher data has been Updated");
            }


        }

    }
    }


       
        

          

