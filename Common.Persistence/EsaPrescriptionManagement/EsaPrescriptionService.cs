using Common.Persistence.EsaPrescriptionManagement.EsaPrescriptionDto;
using RestSharp.Serializers;
using System;
using System.Net;

namespace Common.Persistence.EsaPrescriptionManagement
{
    public class EsaPrescriptionService : IEsaPrescriptionService
    {

        private readonly string _url;
        private readonly DotNetXmlSerializer _serializer;
        //private readonly Serilog.ILogger _logger;
        public EsaPrescriptionService(EsaPrescriptionSettings settings)
        {
            _url = settings.EsaPrescriptionUrl;
            _serializer = new DotNetXmlSerializer();
            //_logger = logger;
        }

        public void Send(ESAPrescription prescription)
        {
            var ordernumber = prescription.EsaPatientDetail.Patient.PatientId.ReferenceNumber;
            using (var wb = new WebClient())
            {
                try
                {
                    var xml = _serializer.Serialize(prescription);
                   // _logger.Information("Sending XML ESA - {OrderNumber} {xml}", ordernumber, xml);
                    //xml = "<ESAPrescription><MessageID>11cd251c-0399-403d-bd33-7290021c3bbb</MessageID><Version>V1.0</Version><Date>171113110024</Date><SenderID>42</SenderID><AccountID>1</AccountID><PatientDetail><Patient><PatientId><ReferenceNumber>13131835</ReferenceNumber></PatientId><PatientName><FirstName>Simon</FirstName><Surname>Powell</Surname><MiddleName /><Title>Mr.</Title></PatientName><DOB>05/09/1972</DOB><Sex>1</Sex><HomeAddress><CountryCode>GB</CountryCode><PostCode>DY8 1BY</PostCode><AddressLine1>19 Park Street</AddressLine1><AddressLine2>Stourbridge</AddressLine2><AddressLine3>West Midlands</AddressLine3></HomeAddress><SaturdayDelivery>N</SaturdayDelivery><DeliveryAddress><CountryCode>GB</CountryCode><PostCode>DY8 1BY</PostCode><AddressLine1>19 Park Street</AddressLine1><AddressLine2>Stourbridge</AddressLine2><AddressLine3>West Midlands</AddressLine3></DeliveryAddress><UPSAccessPointDelivery>N</UPSAccessPointDelivery><Notes /><Telephone>07910123999</Telephone><Mobile>07910123999</Mobile><Email>expert.recsimon@gmail.com</Email></Patient><FamilyDoctor><Organisation /><Title /><FirstName /><MiddleName /><Surname /><AddressLine1 /><AddressLine2 /><AddressLine3 /><AddressLine4 /><PostCode /><CountryCode /></FamilyDoctor></PatientDetail><Prescription><Guid>5a06fe93c85a80c6981412f9</Guid><Repeats>0</Repeats><Prescriber><Doctor><GMCNO>6162948</GMCNO><DoctorName>Dr Khalid Efleih Hassan</DoctorName></Doctor></Prescriber><Product><Guid>888282112</Guid><ProductCode>8882821</ProductCode><Description>Sildenafil 25mg</Description><ProductQuantity><Quantity>1</Quantity><Units>Tablets</Units><Dosage>12</Dosage></ProductQuantity><Instructions>Take one tablet 1 hour before sexual activity. Do not take more than one tablet per day. Do not use any other type of medication for erectile dysfunction within 72 hours of taking sildenafil.</Instructions><Instructions2 /></Product><Questionnaire><Question>Do you need help completing this questionnaire?</Question><Answer>No</Answer><Question>Are you:</Question><Answer>Male</Answer><Question>Are you pregnant, breastfeeding or trying to get pregnant?</Question><Answer /><Question>Date of birth:</Question><Answer>6,9,1972</Answer><Question>Would you prefer a male or female doctor to review your answers?</Question><Answer>I don't mind</Answer><Question>Height (in feet and inches or metres and centimetres):</Question><Answer>ft,6,3</Answer><Question>Weight (in stones or kilograms):</Question><Answer>st,18,2</Answer><Question>Have you had your blood pressure checked in the last 6 months?</Question><Answer>Yes</Answer><Question>Is your blood pressure:</Question><Answer>Normal</Answer><Question>Do you know your exact blood pressure?</Question><Answer>No</Answer><Question>Tick the appropriate boxes to show whether you have, or have ever been diagnosed with, any of the following.</Question><Answer /><Question>Do you currently take any other medication (prescribed or bought over the counter)?</Question><Answer>0</Answer><Question>Are you allergic to any foods or drugs?</Question><Answer>No</Answer><Question>Have you ever had any major surgery?</Question><Answer>0</Answer><Question>Do you have a family history of any medical problems?</Question><Answer>0</Answer><Question>Do you drink alcohol or smoke?</Question><Answer>Yes</Answer><Question>Do you take, or intend to take, any recreational drugs during or before sexual activity?</Question><Answer>No</Answer><Question>Do you have persistent problems getting or keeping an erection when sexually aroused?</Question><Answer>Yes</Answer><Question>Have you seen a doctor or nurse about your erectile dysfunction?</Question><Answer>No</Answer><Question>Have you used [ProductName] before?</Question><Answer>What dose were you given?</Answer><Question>What treatment(s) have you tried?</Question><Answer>Which dose did you take?</Answer><Question>Please explain why you want to order [ProductName].</Question><Answer>Since you haven't taken treatment for erectile dysfunction before, we need to ask you a few extra questions and give you some important information.</Answer><Question>True</Question><Answer>Because erectile dysfunction treatments can lower blood pressure, we need to ask you some detailed questions about your heart and circulation.</Answer><Question>No</Question><Answer>Have you ever experienced tightness or heaviness in the chest with a feeling of breathlessness?</Answer><Question>No</Question><Answer>Have you ever had to stop any exercise or strenuous activity because you feel too breathless or become clammy or sweaty?</Answer><Question>No</Question><Answer>Have you ever been prescribed a ‘nitrate’ medication for angina or heart disease, such as GTN (glyceryl tri-nitrate) spray, tablets or other type of nitrate medication?</Answer><Question>No</Question><Answer>Erectile dysfunction treatments can cause a fatal interaction with medicines from the \"nitrates\" family used to help with angina or heart disease. If you are ever prescribed a GTN (glyceryl tri-nitrate) spray, tablets or other type of nitrate medication, you must NOT take erectile dysfunction treatments. </Answer><Question>True</Question><Answer>Do you ever experience dizziness or lightheadedness immediately after standing up?</Answer><Question>No</Question><Answer>Some men with erectile dysfunction may be tempted try \"herbal\" remedies to help with their symptoms. However, many herbal remedies contain prescription only medicines and are sold by unregulated manufacturers. Taking them, particularly at the same time as prescription erectile dysfunction treatments, can often be very dangerous. You must therefore NOT take any herbal treatments whilst taking erectile dysfunction treatments.</Answer><Question>True</Question><Answer>Are your erections sometimes fine (for example, first thing in the morning or when watching pornography)?</Answer><Question>No</Question><Answer>Are you currently having any emotional or psychological problems?</Answer><Question>No</Question><Answer>Has a doctor advised you to avoid strenuous exercise?</Answer><Question>No</Question><Answer>Do you need to urinate frequently or have any problems urinating?</Answer><Question>No</Question><Answer>Do you consider yourself to have a disability?</Answer><Question>No</Question><Answer>Is there anything else you would like to mention to the doctor or which you think might be relevant?</Answer><Question>No</Question><Answer>Have you read the patient information leaflet for [ProductName] and understood:</Answer><Question>Yes</Question><Answer>We recommend that you tell your GP about any medication you buy through our site.</Answer><Question>No</Question></Questionnaire><ccCheck><ccNumber /></ccCheck></Prescription></ESAPrescription>";
                    var response = wb.UploadString(_url, xml);
                    var reponsexml = _serializer.Serialize(response);

                   // if (!response.Contains("Success"))
                        //_logger.Information("Failed XML ESA - {OrderNumber} {Response}", ordernumber, reponsexml);
                   // else
                        //_logger.Information("Success XML ESA - {OrderNumber}", ordernumber);
                }
                catch (Exception ex)
                {
                   //_logger.Error("Esa Error {error}", ex.Message);
                }

            }
        }
    }
}
