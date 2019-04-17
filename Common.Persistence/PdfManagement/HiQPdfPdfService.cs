using HiQPdf;

namespace Nhs.Services.PdfManagement
{
    public class HiQPdfPdfService : IPdfService
	{
		private readonly string _baseUrl;
		public HiQPdfPdfService(string baseUrl)
		{
			_baseUrl = baseUrl;
		}
		public byte[] ConvertHtmlCodeToPdf(string html, string footerHml)
		{
			// create the HTML to PDF converter
			HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

			// set browser width
			htmlToPdfConverter.BrowserWidth = 1050;

			// set browser height if specified, otherwise use the default
			//if (textBoxBrowserHeight.Text.Length > 0)
			//	htmlToPdfConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

			// set HTML Load timeout
			htmlToPdfConverter.HtmlLoadedTimeout = 400;

			// set PDF page size and orientation
			htmlToPdfConverter.Document.PageSize = PdfPageSize.A4;
			htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;

			// set PDF page margins
			htmlToPdfConverter.Document.Margins = new PdfMargins(0);

			// set a wait time before starting the conversion
			htmlToPdfConverter.WaitBeforeConvert = 10;

			// convert HTML to PDF
			byte[] pdfBuffer = null;


			// convert HTML code

			// convert HTML code to a PDF memory buffer
			pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(html, _baseUrl);

			return pdfBuffer;
		}
	}
}
