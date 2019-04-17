using SelectPdf;
using System;

namespace Common.Persistence.PdfManagement
{
    public class SelectPdfService : IPdfService
	{
		private readonly string _baseUrl;
		public SelectPdfService(string baseUrl)
		{
			_baseUrl = baseUrl;
			GlobalProperties.EnableRestrictedRenderingEngine = true;
			GlobalProperties.EnableFallbackToRestrictedRenderingEngine = true;
		}

		public Byte[] ConvertHtmlCodeToPdf(string html, string footerHml)
		{
			int webPageWidth = 1050;
			int webPageHeight = 0;


		
			// instantiate a html to pdf converter object
			HtmlToPdf converter = new HtmlToPdf();

			// set converter options
			converter.Options.PdfPageSize = PdfPageSize.A4;
			converter.Options.MarginLeft = 0;
			converter.Options.MarginRight = 0;
			converter.Options.MarginTop = 0;
			converter.Options.MarginBottom = 0;
			converter.Options.DisplayFooter = true;
			// BuildMyString.com generated code. Please enjoy your string responsibly.

			if (!string.IsNullOrEmpty(footerHml))
			{

				PdfHtmlSection footerHtml = new PdfHtmlSection(footerHml, "");
				converter.Footer.Add(footerHtml);
				converter.Footer.Height = 50;
				footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
			}


			converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
			converter.Options.WebPageWidth = webPageWidth;
			converter.Options.WebPageHeight = webPageHeight;

			// create a new pdf document converting an url
			SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html, _baseUrl);

			// save pdf document
			byte[] pdf = doc.Save();

			// close pdf document
			doc.Close();

			return pdf;
		}
	}
}
