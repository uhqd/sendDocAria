using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
//using VMS.TPS.Common.Model.Interface;
//using System.Windows;
using SEND_DOCUMENT;

using System.Drawing;



namespace VMS.TPS
{
    class Program
    {

        [STAThread]
        
        static void Main(string[] args)
        {
            string mypatientID = args[0];
            string fullPathOfTheFile = args[1];
            try
            {
                using (Application app = Application.CreateApplication())
                {
                    Execute(app,mypatientID,fullPathOfTheFile);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        static void Execute(Application app,string ID,string path)
        {


       
            string WORKBOOK_TEMPLATE_DIR = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //A MODIFIER POUR MODIFIER LE CHEMIN PAR DEFAUT
            string WORKBOOK_RESULT_DIR = System.IO.Path.GetTempPath();


            string filepath = @"\\srv015\SF_COM\SIMON_LU\dd.pdf";
            string patientID = ID;// "202204584";
            Console.WriteLine("patient ID "  +patientID);
            Console.ReadLine();
//            AriaSender asender = new AriaSender(filepath, patientID);
            AriaSender asender = new AriaSender(filepath, patientID);



        }

    }
}

