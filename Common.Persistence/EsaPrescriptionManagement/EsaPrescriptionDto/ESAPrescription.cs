using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Persistence.EsaPrescriptionManagement.EsaPrescriptionDto
{
    public class ESAPrescription
    {
        public string MessageID { get; set; }

        public string Version { get; set; }

        public string Date { get; set; }

        public string SenderID { get; set; }

        public string AccountID { get; set; }

        public ESAPrescriptionPatientDetail EsaPatientDetail { get; set; }

        public ESAPrescriptionPrescription EsaPrescription { get; set; }

        public string Priority { get; set; }
    }

    public class ESAPrescriptionPatientDetail
    {
        public ESAPrescriptionPatientDetailPatient Patient { get; set; }

        public ESAPrescriptionPatientDetailFamilyDoctor FamilyDoctor { get; set; }
    }

    public class ESAPrescriptionPatientDetailPatient
    {
        public ESAPrescriptionPatientDetailPatientPatientId PatientId { get; set; }

        public ESAPrescriptionPatientDetailPatientPatientName PatientName { get; set; }

        public string DOB { get; set; }

        public string Sex { get; set; }

        public ESAPrescriptionPatientDetailPatientHomeAddress HomeAddress { get; set; }

        public string SaturdayDelivery { get; set; }

        public ESAPrescriptionPatientDetailPatientDeliveryAddress DeliveryAddress { get; set; }

        public string UPSAccessPointDelivery { get; set; }

        public EsaPrescriptionUPSAccessPointAddress UPSAccessPointAddress { get; set; }

        public string Notes { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }

    public class ESAPrescriptionPatientDetailPatientPatientId
    {
        public string ReferenceNumber { get; set; }
        public string UserId { get; set; }
    }

    public class ESAPrescriptionPatientDetailPatientPatientName
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Title { get; set; }
    }

    public class ESAPrescriptionPatientDetailPatientHomeAddress
    {
        public string CountryCode { get; set; }

        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }
    }

    public class ESAPrescriptionPatientDetailPatientDeliveryAddress
    {
        public string CountryCode { get; set; }

        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }
    }

    public class EsaPrescriptionUPSAccessPointAddress
    {
        public string UPSAccessPointID { get; set; }

        public string CompanyOrName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string CityOrTown { get; set; }

        public string PostCode { get; set; }

        public string CountryCode { get; set; }

        public string APNotificationEmail { get; set; }

        public string APNotificationCountryTerritory { get; set; }

        public string APNotificationPhoneCountryCode { get; set; }
    }

    public class ESAPrescriptionPatientDetailFamilyDoctor
    {
        public string Organisation { get; set; }


        public string Title { get; set; }


        public string FirstName { get; set; }


        public string MiddleName { get; set; }


        public string Surname { get; set; }


        public string AddressLine1 { get; set; }


        public string AddressLine2 { get; set; }


        public string AddressLine3 { get; set; }


        public string AddressLine4 { get; set; }

        public string PostCode { get; set; }


        public string CountryCode { get; set; }
    }

    public class ESAEnglishProductDetail
    {
        public string Name { get; set; }
        public List<Dosage> Dosages { get; set; }
    }

    public class ESAPrescriptionPrescription
    {
        public string Guid { get; set; }


        public string PrescriptionNotes { get; set; }


        public string CommercialInvoiceValue { get; set; }


        public ESAPrescriptionPrescriptionPrescriber Prescriber { get; set; }


        public ESAPrescriptionPrescriptionProduct Product { get; set; }


        public ESAPrescriptionPrescriptionQuestionnaire Questionnaire { get; set; }


        public ESAPrescriptionPrescriptionCcCheck ccCheck { get; set; }


        public ESAPrescriptionPrescriptionCOD COD { get; set; }
    }

    public class ESAPrescriptionPrescriptionPrescriber
    {
        public ESAPrescriptionPrescriptionPrescriberDoctor Doctor { get; set; }
    }

    public class ESAPrescriptionPrescriptionPrescriberDoctor
    {
        public string GMCNO { get; set; }


        public string DoctorName { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ESAPrescriptionPrescriptionProduct
    {
        public string Guid { get; set; }


        public string ProductCode { get; set; }


        public string Description { get; set; }


        public ESAPrescriptionPrescriptionProductProductQuantity ProductQuantity { get; set; }


        public string Instructions { get; set; }
        public string Instructions2 { get; set; }
    }

    public class ESAPrescriptionPrescriptionProductProductQuantity
    {
        public string Quantity { get; set; }


        public string Units { get; set; }


        public string Dosage { get; set; }
    }

    public class ESAPrescriptionPrescriptionQuestionnaire
    {
        [System.Xml.Serialization.XmlElementAttribute("Answer", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Question", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName { get; set; }
    }

    public enum ItemsChoiceType
    {
        Answer,
        Question,
    }

    public class ESAPrescriptionPrescriptionCcCheck
    {
        public string ccNumber { get; set; }
    }

    public class ESAPrescriptionPrescriptionCOD
    {
        public string CashOnly { get; set; }
        public string AddShippingChargesToCODIndicator { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class ESATracking : ESAReporting
    {
        public ESATracking()
        {

        }
        public string DeliveryCompany { get; set; }
        public string TrackingLink { get; set; }
        public string TrackingCode { get; set; }
        public string RefID { get; set; }
        public string TrackingRef { get; set; }
        public object Username { get; set; }
        public object Password { get; set; }
        public string Priority { get; set; }
        public decimal Version { get; set; }
    }

    public class ESAReporting
    {
        public ESAReporting()
        {

        }

        public string OrderID { get; set; }
        public string User { get; set; }
        public string OrderStatus { get; set; }
        public string Message { get; set; }
        public string NewDate { get; set; }
    }

    /// <summary>
    /// dosage classs is as product
    /// </summary>
    public class Dosage
    {
        public int? DosageId { get; set; }
        public int UmbracoId { get; set; }
        public string VariantName { get; set; }
        public string VariantNameForMostSearch { get; set; }
        public string PrescriptionName { get; set; }

        public string DosageName { get; set; } // Dosage 10 mg
        public string Amount { get; set; } // Dosage 10 mg
        public int AmountInt { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        [BsonIgnore]
        public string EnDescription { get; set; }
        public string DosagePILUrl { get; set; }
        public string DoctorDescription { get; set; }
        [BsonIgnore]
        public string EnDoctorDescription { get; set; }
        public string Pip { get; set; }
        public string Barcode { get; set; }
        public string Type { get; set; } //Pill / Injection / Tablet / Capsule
        public string Severity { get; set; }
        public List<Pricing> Pricing { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Questions { get; set; }
        public RecommendedQtyQuestion RecommendedQtyQuestion { get; set; }
        public bool isOutOfStock { get; set; }
        public bool NoUPSAPDelivery { get; set; }
        public bool IsDeleted { get; set; }
        public int DosageOrderNo { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDefault { get; set; }
        [BsonIgnore]
        public string EngType { get; set; }
        [BsonIgnore]
        public string EngPrescriptionName { get; set; }
        [BsonIgnore]
        public bool IsNonEnDosage { get; set; }
        public bool IsRefrigerated { get; set; }
        public bool IsTestKitDosage { get; set; }
        public int Gender { get; set; } //0-both,1-male,2-female
        public bool WarnTransgender { get; set; }
        public string FDBSingleId { get; set; }
    }
    /// <summary>
    /// dosage priceing is declared
    /// </summary>
    public class Pricing
    {
        public int? PricingId { get; set; }
        public int UmbracoId { get; set; }
        //public string Name { get; set; }
        public string Sku { get; set; }
        public string DisplayName { get; set; }
        public double Quantity { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        public decimal PricePerUnit { get; set; }

        [BsonIgnore]
        public string PricePerUnitLocale { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        //public decimal Cost { get; set; }        
        public decimal Vat { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        public decimal PriceWithoutVAT { get; set; }
        public bool isMostSearched { get; set; }
        public bool isMostPopular { get; set; }
        public bool isOutOfStock { get; set; }
        public int ReOrderReminderDays { get; set; }
        public int SignPostingDays { get; set; }
        public bool IsPublished { get; set; }
        public List<string> Questions { get; set; }
        //Added new fields for Natcol Profit report
        [BsonRepresentation(BsonType.Double)]
        public decimal Cost { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public decimal MerchantFees { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public decimal Commision { get; set; }
        //Added new fields for Natcol Profit report
        // used in response. not in DB.
        public bool IsDeleted { get; set; }
        public int Save { get; set; }
        public string PriceFormatted { get; set; }
        public List<GroupQuestionItem> GroupedQuestions { get; set; }
        public string PriceFormattedWithDecimals { get; set; }
        public string SaveFormatted { get; set; }
        //public List<Question> QtyQuestions { get; set; }
        public bool CanReOrder { get; set; }
        public string BPQuestion { get; set; }
        public string CanReorderAfter { get; set; }
        public string CanReorderTimes { get; set; }
        [BsonIgnore]
        public int Index { get; set; }
    }

    /// <summary>
    /// recommended questions of dosage
    /// </summary>
    public class RecommendedQtyQuestion
    {
        public int RecommendedQty { get; set; }
        public List<string> Questions { get; set; }
    }

    public class GroupQuestionItem
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public List<EsaQuestionItem> QuestionItems { get; set; }
    }

    public class EsaQuestionItem
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
    }

    public class EsaQuestionAnswer
    {
        public string value { get; set; }
        public string date { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string unit { get; set; }
        public string feet { get; set; }
        public string inch { get; set; }
        public string centimeter { get; set; }
        public string selectedOption { get; set; }
        public string kg { get; set; }
        public string st { get; set; }
        public string lb { get; set; }
    }
}
