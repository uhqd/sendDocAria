using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Pdf;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using VMS.TPS.Common.Model.API;
using VMS.OIS.ARIALocal.WebServices.Document.Contracts;
using PdfSharp.Pdf.IO;
using MigraDoc.DocumentObjectModel;
using System.Security.Principal;
namespace SEND_DOCUMENT
{
    public class AriaSender
    {

        //ScriptContext _ctx;
        string _filepath;
        private byte[] _binaryContent;
        public string _patientID;
        private User _appUser;
        private string _templateName;
        private DocumentType _documentType;
        //string _patientID;

        public AriaSender(string path, string patientID) //constructor
        {
            _patientID = patientID;
            //_ctx = ctx;
            _filepath = path;

            GetDocInfo();

            SendToAria();
        }

        private void GetDocInfo()
        {
            //_patientId = patientID;//_ctx.Course.Patient.Id;
            _appUser = null;//System.Security.Principal.WindowsIdentity.GetCurrent().Name; //_ctx.CurrentUser;
            //_appUser.Name = null;
            _templateName = null;// _ctx.ExternalPlanSetup.Id;
            _documentType = new DocumentType
            {
                DocumentTypeDescription = "Dosimétrie"
            };
        }

        private void SendToAria()
        {
            if (_filepath.ToUpper().Contains(".PDF"))
            {
                //Recuperation du pdf et passage en binaire
                PdfDocument doc = PdfReader.Open(_filepath);

                //outputDocument
                MemoryStream stream = new MemoryStream();
                //klskd
                doc.Save(stream, false);

                //outputDocument.Save(stream, false);
                _binaryContent = stream.ToArray();


                CustomInsertDocumentsParameter.PostDocumentData(_patientID, _appUser,
                    _binaryContent, _templateName, _documentType);
            }
            else if (_filepath.ToUpper().Contains(".DOCX"))
            {

                
                byte[] _binaryContent = File.ReadAllBytes(_filepath);

                CustomInsertDocumentsParameter.PostDocumentDataWord(_patientID, _appUser,
                    _binaryContent, _templateName, _documentType);
            }
        }


    }
}
