/*Purpose: Array
 *Author: Mahjabin Sajadi
 *Date: 7 April 2021
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4MahjabinSajadi3
{
    class Program
    {
        // search operation  
        static void Main(string[] args)
        {
            // Variables Definitions
            string[] Mechanics_Name = { "Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-" };// Employee's Name
            string[] Cars = { "1","2","3","4"};     // Toyota:1, Mercedes:2, LandRover:3, Ferrari:4
            string flag_Option = "";                // input user data from main menu
            string Name ="", Car="", job="", edited_job="";
            string[] work = new string[] { "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE" }; // For Saving a work
            string[] Register;
            string key = "NONE"; //Searching key word
            int position;  // Find the empty array
            int spot = -1 , Spot_Edit=-1;   // wrong position
            string Edit_data="" , Edition="", Edition_1="", what_to_Edit="", what_to_del=""; //Edition Info
            char Edit_car=' ';//Edition Info
            bool flag_Name, flag_Cars;
            bool flag; //whole of program
            bool flag_error, flag_spot, falg_Case_A, flag_Edit, flag_Edit_error, falg_Case_B, flag_what_to_edit, flag_what_to_del;
            bool falg_Case_D;
            string answer="";
            //Initials:
            flag = true;
            falg_Case_A = true;
            falg_Case_B = true;
            falg_Case_D = true;
            flag_Name = true;
            flag_Cars = true;
            flag_error = false;   // check the first entrance work
            flag_spot = true;       // check the pepeatetive
            flag_Edit = true;     // Check Edition
            flag_Edit_error = false;
            flag_what_to_edit = true;

            /************ Process*************************/
            /*********** Show The Mechanics Name******************/
            for (int i = 0; i < Mechanics_Name.Length; i++)
            {
                Console.WriteLine("Mechanic number " + (i + 1) + ", Name is: " + Mechanics_Name[i]);
            }
            do
            {
                try
                {
                    
                    Console.WriteLine("\n");
                    Console.WriteLine("Main Menu \n");
                    Console.WriteLine("Enter\"A\" if you want to Assign a new Vehicle to a Employee");
                    Console.WriteLine("Enter\"B\" if you want to Edit Employee Name and Brand Number");
                    Console.WriteLine("Enter\"C\" if you want to List all Vehicle that Repairing/ed");
                    Console.WriteLine("Enter\"D\" if you want to Delete registration Info");
                    Console.WriteLine("Enter\"E\" if you want to Exit Program");
                    flag_Option = Console.ReadLine();
                    flag_Option = flag_Option.ToUpper();
                    falg_Case_A = true;
                    
                }
                catch (FormatException fEx)
                
                {
                    
                   Console.WriteLine("The input is incorrect,Enter number again");
                   
                }

                switch (flag_Option)
                {
                    
                    case "A":
                    case "a":               

                        while (falg_Case_A) 
                        {
                            flag_Name = true;      //check name that user enter
                            flag_Cars = true;       //check number brand that user enter
                            flag_error = false;      // check the first entrance work
                            flag_spot = true;         // check the pepeatetive
                            //Assign work for employees
                            /* Assign Employees' Name*/

                            while (flag_Name)
                            {
                                try
                                {
                                    Console.WriteLine("Please Enter Number From 1 to 4 for selecting Mechanics Man/Woman");
                                    for (int i = 0; i < Mechanics_Name.Length; i++)
                                    {
                                        Console.WriteLine("Mechanic number " + (i + 1) + ", Name is: " + Mechanics_Name[i]);
                                    }

                                    Name = Console.ReadLine();
                                    int Name_int = int.Parse(Name);
                                    if (Name_int >= 1 && Name_int < 5)
                                    {
                                        flag_Name = false;
                                    }
                                    else 
                                        Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                }
                                catch (FormatException fEx)
                                {
                                    Console.WriteLine("The input is incorrect,Enter number again");
                                    //Console.ReadKey();
                                    //Console.Clear();
                                }
                                catch (OverflowException oEx)
                                {
                                    Console.WriteLine("the number should be smaller");
                                    //Console.ReadKey();
                                }

                            }
                            /*Assign Employees' Cars*/
                            while (flag_Cars)
                            {
                                try
                                {
                                    Console.WriteLine("Please Enter Number 1 , 2 , 3 , 4 for Setting the Cars assessments");
                                    Console.WriteLine("Please Enter One of these Companey Numbers: Toyota:1, Mercedes:2, LandRover:3, Ferrari:4");

                                    Car = Console.ReadLine();
                                    if (Car == "Done" || Car == "done")
                                    {
                                        falg_Case_A = false;
                                        break;
                                    }
                                    
                                    int Car_int = int.Parse(Car);   // conver string to intiger car brand input
                                    if (Car_int >= 1 && Car_int < 5)
                                    {
                                        flag_Cars = false;
                                    }
                                    else
                                        Console.WriteLine("Error! The number smaller or larger limitation");

                                }
                                catch (FormatException fEx)
                                {
                                    Console.WriteLine("The input is incorrect,Enter number again");
                                    //Console.ReadKey();
                                    //Console.Clear();
                                }
                                catch (OverflowException oEx)
                                {
                                    Console.WriteLine("the number should be smaller");
                                    //Console.ReadKey();
                                }

                            }
                            /*Check the previous Entrance Data for Employees*/
                            job = Name + Car;   // work assign for each employee
                            //Console.WriteLine("tttttttttttttttttttttttttttttttest   " + work.Length);
                            if (falg_Case_A == true)
                            {
                                spot = -1;    // check empty work place
                                for (int Count = 0; Count < work.Length; Count++)
                                {
                                    if (work[Count] == key && flag_spot == true)
                                    {
                                        spot = Count; //Find the first empty spot
                                        flag_spot = false;
                                    }
                                    if (work[Count] == job)
                                    {
                                        flag_error = true;/*Avoid to repeatative*/
                                    }
                                   
                                }

                                if (flag_error == true)
                                {
                                    Console.WriteLine("Error vehicle already registered to employee");
                                }
                                else if (spot != -1)
                                {
                                    work[spot] = job;
                                    Console.WriteLine("Your Registration is Done! the job located in position " + spot + " in array. " + " The job was " + Mechanics_Name[(int)Char.GetNumericValue(work[spot][0]) - 1] + work[spot][1] +"\n");
                                }
                                else
                                {
                                    Console.WriteLine("We can not accept because the array is full!");
                                    falg_Case_A = false;
                                }
                            }
                            else
                                Console.WriteLine("We do not save because word \"Done\" entered !");
                        }
                        break;
                    case "B":
                    case "b":
                        falg_Case_B = true;   //check part B
                        while (falg_Case_B)
                        {
                            flag_Edit = true; // check edit part
                            //Option B, Edit registration
                            Console.WriteLine("Please Enter the Name and Number of Brand number you want to edit like Liz StaceyBA-1");
                            Console.WriteLine("Please Enter One of these Names: Liz StaceyBA- , Orville BaileyBA- ,Mark RajkumarBA- ,Jim EdwardsBA- ");
                            Console.WriteLine("Please Enter One of these Companey Numbers: Toyota:1, Mercedes:2, LandRover:3, Ferrari:4");
                            try
                            {
                                Edit_data = Console.ReadLine();
                                Edit_data= Edit_data.ToLower();
                                Edit_data = Edit_data.TrimEnd ();
                                string[] spliting = Edit_data.Split('-');
                                if (spliting[1].Length != 1)
                                {
                                    Console.WriteLine("the format is wrong , we anticipate one number after \"-\"");
                                    int m = spliting[1].Length / 0;
                                }
                                Edit_data = spliting[0];
                                Edit_car = Convert.ToChar(spliting[1]);
                                Console.WriteLine(Edit_car);
                            }
                            catch (FormatException fEx)
                            {
                                Console.WriteLine("The input is incorrect,Enter number again");
                            }
                            catch (OverflowException oEx)
                            {
                                Console.WriteLine("the number should be smaller");
                            }
                            catch (DivideByZeroException oEx)
                            {
                                Console.WriteLine("Change format");
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Console.WriteLine("needed \"-\" in the string");
                            }

                            Console.WriteLine(Edit_data);
                            switch (Edit_data)
                            {/*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "liz staceyba":
                                    {

                                        Edition = "1" + Edit_car;
                                        Name = "1";
                                        Car = Edit_car.ToString();
                                        Console.WriteLine(Edition);
                                        Spot_Edit = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == Edition && flag_Edit == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_Edit = k;
                                                flag_Edit = false;
                                            }

                                        }
                                        if (flag_Edit == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            flag_what_to_edit = true;

                                            while (flag_what_to_edit)
                                            {
                                                Console.WriteLine("If you want to change mechanics name please enter \"1\", \n if you want to change car brand please select \"2\", \n if you want t change both please enter \"3\"");
                                                what_to_Edit = Console.ReadLine();
                                                if (what_to_Edit == "1")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;

                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Finding your Mechanics Man/Woman: ");
                                                            for (int i = 0; i < Mechanics_Name.Length; i++)
                                                            {
                                                                Console.WriteLine("The mechanic number " + (i + 1) + ", Name is: " + Mechanics_Name[i]);
                                                            }
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                            //Console.ReadKey();
                                                            //Console.Clear();
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                            //Console.ReadKey();
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "2")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments");
                                                            Console.WriteLine("Please Enter One of these Companey Numbers: Toyota:1, Mercedes:2, LandRover:3, Ferrari:4");

                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                            //Console.ReadKey();
                                                            //Console.Clear();
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                            //Console.ReadKey();
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "3")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;
                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Finding your Mechanics Man/Woman");
                                                            for (int i = 0; i < Mechanics_Name.Length; i++)
                                                            {
                                                                Console.WriteLine("The mechanic number " + (i + 1) + ", Name is: " + Mechanics_Name[i]);
                                                            }
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                            //Console.ReadKey();
                                                            //Console.Clear();
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                            //Console.ReadKey();
                                                        }

                                                    }
                                                    /*Assign Employees' Cars*/

                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                            //Console.ReadKey();
                                                            //Console.Clear();
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                            //Console.ReadKey();
                                                        }

                                                    }

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Your Option should be between 1 to 3, Please try again");
                                                }
                                            }
                                            edited_job = Name + Car;
                                            if (falg_Case_A == true)
                                            {

                                                for (int Count = 0; Count < work.Length; Count++)
                                                {

                                                    if (work[Count] == edited_job)
                                                    {
                                                        flag_error = true;/*Avoid to repeatative*/
                                                    }

                                                }

                                                if (flag_error == true)
                                                {
                                                    Console.WriteLine("Error vehicle already registered to employee");
                                                }
                                                else
                                                {
                                                    work[Spot_Edit] = edited_job;
                                                    falg_Case_B = false;
                                                    Console.WriteLine("Your Registration is Done! the job located in position " + spot + " in array. " + " The job was " + Mechanics_Name[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1] + "\n");
                                                }

                                            }
                                            //Console.WriteLine("Your Registration is Done! the job located in position " + Spot_Edit + " in array. " + " The job was " + Edition[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1]);


                                            Console.ReadLine();

                                        }

                                    }break;

                                     case "orville baileyba":
                                    {

                                        Edition = "2" + Edit_car;
                                        Name = "2";
                                        Car = Edit_car.ToString();
                                        Console.WriteLine(Edition);
                                        Spot_Edit = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == Edition && flag_Edit == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_Edit = k;
                                                flag_Edit = false;
                                            }

                                        }
                                        if (flag_Edit == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            flag_what_to_edit = true;

                                            while (flag_what_to_edit)
                                            {
                                                Console.WriteLine("If you want to change mechanics name please enter \"1\", \n if you want to change car brand please select \"2\", \n if you want t change both please enter \"3\"");
                                                what_to_Edit = Console.ReadLine();
                                                if (what_to_Edit == "1")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;

                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Finding your Mechanics Man/Woman: ");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again: ");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                        
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                      
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "2")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments: ");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                       
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                    
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "3")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;
                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Finding your Mechanics Man/Woman: ");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                          
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                           
                                                        }

                                                    }
                                                    /*Assign Employees' Cars*/

                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                       
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                         
                                                        }

                                                    }

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Your Option should be between 1 to 3, Please try again");
                                                }
                                            }
                                            edited_job = Name + Car;
                                            if (falg_Case_A == true)
                                            {

                                                for (int Count = 0; Count < work.Length; Count++)
                                                {

                                                    if (work[Count] == edited_job)
                                                    {
                                                        flag_error = true;/*Avoid to repeatative*/
                                                    }

                                                }

                                                if (flag_error == true)
                                                {
                                                    Console.WriteLine("Error vehicle already registered to employee");
                                                }
                                                else
                                                {
                                                    work[Spot_Edit] = edited_job;
                                                    falg_Case_B = false;
                                                    Console.WriteLine("Your Registration is Done! the job located in position " + spot + " in array. " + " The job was " + Mechanics_Name[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1] + "\n");
                                                }

                                            }
                                            //Console.WriteLine("Your Registration is Done! the job located in position " + Spot_Edit + " in array. " + " The job was " + Edition[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1]);


                                            Console.ReadLine();

                                        }
                                    }
                                    break;

                                /*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "mark rajkumarba":
                                    {

                                        Edition = "3" + Edit_car;
                                        Name = "3";
                                        Car = Edit_car.ToString();
                                        Console.WriteLine(Edition);
                                        Spot_Edit = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == Edition && flag_Edit == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_Edit = k;
                                                flag_Edit = false;
                                            }

                                        }
                                        if (flag_Edit == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            flag_what_to_edit = true;

                                            while (flag_what_to_edit)
                                            {
                                                Console.WriteLine("If you want to change mechanics name please enter \"1\", \n if you want to change car brand please select \"2\", \n if you want t change both please enter \"3\"");
                                                what_to_Edit = Console.ReadLine();
                                                if (what_to_Edit == "1")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;

                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Finding your Mechanics Man/Woman");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                        
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                       
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "2")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                       
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                        
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "3")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;
                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number 1 , 2, 3, or 4 for Finding your Mechanics Man/Woman");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                     
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                         
                                                        }

                                                    }
                                                    /*Assign Employees' Cars*/

                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number  1 , 2, 3, or 4 for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                         
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                           
                                                        }

                                                    }

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Your Option should be between 1 to 3, Please try again");
                                                }
                                            }
                                            edited_job = Name + Car;
                                            if (falg_Case_A == true)
                                            {

                                                for (int Count = 0; Count < work.Length; Count++)
                                                {

                                                    if (work[Count] == edited_job)
                                                    {
                                                        flag_error = true;/*Avoid to repeatative*/
                                                    }

                                                }

                                                if (flag_error == true)
                                                {
                                                    Console.WriteLine("Error vehicle already registered to employee");
                                                }
                                                else
                                                {
                                                    work[Spot_Edit] = edited_job;
                                                    falg_Case_B = false;
                                                    Console.WriteLine("Your Registration is Done! the job located in position " + spot + " in array. " + " The job was " + Mechanics_Name[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1] + "\n");
                                                }

                                            }
                                            //Console.WriteLine("Your Registration is Done! the job located in position " + Spot_Edit + " in array. " + " The job was " + Edition[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1]);


                                            Console.ReadLine();

                                        }

                                    }
                                    break;

                                /*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "jim edwardsba":
                                    {

                                        Edition = "4" + Edit_car;
                                        Name = "4";
                                        Car = Edit_car.ToString();
                                        Console.WriteLine(Edition);
                                        Spot_Edit = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == Edition && flag_Edit == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_Edit = k;
                                                flag_Edit = false;
                                            }

                                        }
                                        if (flag_Edit == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            flag_what_to_edit = true;

                                            while (flag_what_to_edit)
                                            {
                                                Console.WriteLine("If you want to change mechanics name please enter \"1\", \n if you want to change car brand please select \"2\", \n if you want t change both please enter \"3\"");
                                                what_to_Edit = Console.ReadLine();
                                                if (what_to_Edit == "1")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;

                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number  1 , 2, 3, or 4 for Finding your Mechanics Man/Woman");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                            Console.ReadKey();
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "2")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number From 1 to 4 for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                       
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                      
                                                        }

                                                    }
                                                }
                                                else if (what_to_Edit == "3")
                                                {
                                                    flag_what_to_edit = false;
                                                    flag_Name = true;
                                                    while (flag_Name)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number  1 , 2, 3, or 4 for Finding your Mechanics Man/Woman");
                                                            Name = Console.ReadLine();
                                                            int Name_int = int.Parse(Name);
                                                            if (Name_int >= 1 && Name_int < 5)
                                                            {
                                                                flag_Name = false;
                                                            }
                                                            else
                                                                Console.WriteLine("The input is not between 1 to 4 ,Enter number again");


                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                     
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                           
                                                        }

                                                    }
                                                    /*Assign Employees' Cars*/

                                                    flag_Cars = true;
                                                    while (flag_Cars)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("Please Enter Number  1 , 2, 3, or 4  for Setting the Cars assessments");
                                                            Car = Console.ReadLine();
                                                            if (Car == "Done" || Car == "done")
                                                            {
                                                                falg_Case_A = false;
                                                                break;
                                                            }

                                                            int Car_int = int.Parse(Car);
                                                            if (Car_int >= 1 && Car_int < 5)
                                                            {
                                                                flag_Cars = false;
                                                            }
                                                            else
                                                                Console.WriteLine("Error! The number smaller or larger limitation");

                                                        }
                                                        catch (FormatException fEx)
                                                        {
                                                            Console.WriteLine("The input is incorrect,Enter number again");
                                                      
                                                        }
                                                        catch (OverflowException oEx)
                                                        {
                                                            Console.WriteLine("the number should be smaller");
                                                      
                                                        }

                                                    }

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Your Option should be between 1 to 3, Please try again");
                                                }
                                            }
                                            edited_job = Name + Car;
                                            if (falg_Case_A == true)
                                            {

                                                for (int Count = 0; Count < work.Length; Count++)
                                                {

                                                    if (work[Count] == edited_job)
                                                    {
                                                        flag_error = true;/*Avoid to repeatative*/
                                                    }

                                                }

                                                if (flag_error == true)
                                                {
                                                    Console.WriteLine("Error vehicle already registered to employee");
                                                }
                                                else
                                                {
                                                    work[Spot_Edit] = edited_job;
                                                    falg_Case_B = false;
                                                    Console.WriteLine("Your Registration is Done! the job located in position " + spot + " in array. " + " The job was " + Mechanics_Name[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1] + "\n");
                                                }

                                            }
                                            //Console.WriteLine("Your Registration is Done! the job located in position " + Spot_Edit + " in array. " + " The job was " + Edition[(int)Char.GetNumericValue(work[Spot_Edit][0]) - 1] + work[Spot_Edit][1]);


                                            Console.ReadLine();

                                        }

                                    }
                                    break;

                            }
                        }
                        break;
/*************************************Option  C*****************************************************/

                    case "C":
                    case "c":
                        //Option C
                        Console.WriteLine("The job assigment are as follow: \n");
                        for (int C=0; C < work.Length; C++)
                        {
                            if (work[C] != "NONE")
                            {
                                Console.WriteLine("the " + C + "the position is " + Mechanics_Name[(int)Char.GetNumericValue(work[C][0]) - 1] + work[C][1]);
                            }
                            else
                            {
                                Console.WriteLine("the " + C +"the position is empty");
                            }
                        
                        }
                        Console.WriteLine("press Enter to go to the main menu");
                        Console.ReadLine();
                        break;

/*************************************Option  D*****************************************************/

                    case "D":
                    case "d":
                        falg_Case_D = true;
                        while (falg_Case_D)
                        {
                            bool flag_del = true;
                            //Option B, Edit registration
                            Console.WriteLine("Please Enter the Name and Number of Brand number you want to edit like Liz StaceyBA-1");
                            Console.WriteLine("Please Enter One of these Names: Liz StaceyBA- , Orville BaileyBA- ,Mark RajkumarBA- ,Jim EdwardsBA- ");
                            Console.WriteLine("Please Enter One of these Companey Numbers: Toyota:1, Mercedes:2, LandRover:3, Ferrari:4");
                            string del_data = "";
                            char del_car = ' ';
                            try
                            {
                                del_data = Console.ReadLine();
                                del_data = del_data.ToLower();
                                del_data = del_data.TrimEnd();
                                string[] spliting = del_data.Split('-');
                                Console.WriteLine(spliting[0]);
                                if (spliting[1].Length != 1)
                                {
                                    Console.WriteLine("the format is wrong , we anticipate one number after \"-\"");
                                    int m = spliting[1].Length / 0;
                                }
                                del_data = spliting[0];
                                del_car = Convert.ToChar(spliting[1]);
                                Console.WriteLine(Edit_car);
                            }
                            catch (FormatException fEx)
                            {
                                Console.WriteLine("The input is incorrect,Enter number again");
                            }
                            catch (OverflowException oEx)
                            {
                                Console.WriteLine("the number should be smaller");
                            }
                            catch (DivideByZeroException oEx)
                            {
                                Console.WriteLine("Change format");
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Console.WriteLine("needed \"-\" in the string");
                            }

                            Console.WriteLine(Edit_data);
                            switch (del_data)
                            {/*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "liz staceyba":
                                    {

                                        string delet = "1" + del_car;
                                        Name = "1";
                                        Car = del_car.ToString();
                                        Console.WriteLine(delet);
                                        int Spot_del = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == delet && flag_del == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_del = k;
                                                flag_del = false;

                                            }

                                        }
                                        if (flag_del == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Registration found are you sure you want to delete Y / N?");
                                             answer = Console.ReadLine();
                                            if (answer == "Y" || answer == "y")
                                            { 
                                                work[Spot_del] = "NONE";
                                                Console.WriteLine("Record Successfully Deleted");
                                            }
                                            else 
                                            {
                                                Console.WriteLine("Not deleted, Go to the Main Menu");
                                            }
                                        }

                                    }
                                    break;

                                /*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "orville baileyba":
                                    {

                                        string delet = "2" + del_car;
                                        Name = "2";
                                        Car = del_car.ToString();
                                        Console.WriteLine(delet);
                                        int Spot_del = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == delet && flag_del == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_del = k;
                                                flag_del = false;

                                            }

                                        }
                                        if (flag_del == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Registration found are you sure you want to delete Y / N?");
                                            answer = Console.ReadLine();
                                            if (answer == "Y")
                                            {
                                                work[Spot_del] = "NONE";
                                                Console.WriteLine("Record Successfully Deleted");
                                            }
                                            if (answer == "N")
                                            {
                                                Console.WriteLine("Go to the Main Menu");
                                            }
                                        }

                                    }
                                    break;

                                /*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "mark rajkumarba":
                                    {

                                        string delet = "3" + del_car;
                                        Name = "3";
                                        Car = del_car.ToString();
                                        Console.WriteLine(delet);
                                        int Spot_del = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == delet && flag_del == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_del = k;
                                                flag_del = false;

                                            }

                                        }
                                        if (flag_del == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Registration found are you sure you want to delete Y / N?");
                                            answer = Console.ReadLine();
                                            if (answer == "Y")
                                            {
                                                work[Spot_del] = "NONE";
                                                Console.WriteLine("Record Successfully Deleted");
                                            }
                                            if (answer == "N")
                                            {
                                                Console.WriteLine("Go to the Main Menu");
                                            }
                                        }

                                    }
                                    break;

                                /*"Liz StaceyBA-", "Orville BaileyBA-", "Mark RajkumarBA-", "Jim EdwardsBA-"*/
                                case "jim edwardsba":
                                    {

                                        string delet = "4" + del_car;
                                        Name = "4";
                                        Car = del_car.ToString();
                                        Console.WriteLine(delet);
                                        int Spot_del = -1;
                                        for (int k = 0; k < work.Length; k++) /*check brand*/
                                        {

                                            if (work[k] == delet && flag_del == true)
                                            {
                                                Console.WriteLine("Registration information found");
                                                Spot_del = k;
                                                flag_del = false;

                                            }

                                        }
                                        if (flag_del == true)
                                        {
                                            Console.WriteLine("Employee registration not found for that vehicle");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Registration found are you sure you want to delete Y / N?");
                                            answer = Console.ReadLine();
                                            if (answer == "Y")
                                            {
                                                work[Spot_del] = "NONE";
                                                Console.WriteLine("Record Successfully Deleted");
                                            }
                                            if (answer == "N")
                                            {
                                                Console.WriteLine("Go to the Main Menu");
                                            }
                                        }

                                    }
                                    break;

                            }
                        }
                        break;
/********************** Option E **********************/
                    case "E":
                    case "e":
                        //Option E
                        Console.WriteLine("If you want to exit from program, Please Enter \"E\" ");
                        flag = false;
                        break;

                    case "": 
                        Console.WriteLine("Could not be null, Please select between A, B, C, D, E");
                        break;
                    default:
                        Console.WriteLine("Out of Range Error, Please select between A, B, C, D, E");
                        break;



                }

                
            }while (flag);
            Console.ReadKey();

        }
    }
}
