//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using iTextSharp.tool.xml;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Nhs.Services.PdfManagement
//{
//	public class ITextSharpPdfService : IPdfService
//	{
//		public byte[] ConvertHtmlCodeToPdf_BackUp(string html, string footerHml)
//		{

//			byte[] pdf; // result will be here

//			var cssText = File.ReadAllText(@"D:\css\style.css");

//			using (var memoryStream = new MemoryStream())
//			{
//				var document = new Document(PageSize.A4, 50, 50, 60, 60);
//				var writer = PdfWriter.GetInstance(document, memoryStream);
//				document.Open();

//				using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
//				{
//					using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
//					{
//						XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
//					}
//				}

//				document.Close();

//				pdf = memoryStream.ToArray();
//			}

//			return pdf;
//		}

//		public byte[] ConvertHtmlCodeToPdf(string html, string footerHml)
//		{
//			Document document =  new Document(iTextSharp.text.PageSize.A4, 30f, 30f, 10f, 10f);

//			MemoryStream stream = new MemoryStream();

//			try
//			{
//				PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
//				pdfWriter.CloseStream = false;
//				document.Open();

//				StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
//				styles.LoadTagStyle("div", "font-size", "500px");

//				var hw = new HTMLWorker(document,null, styles);
//				//hw.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
//				hw.Parse(new StringReader(html));

//			}
//			catch (DocumentException de)
//			{
//				Console.Error.WriteLine(de.Message);
//			}
//			catch (IOException ioe)
//			{
//				Console.Error.WriteLine(ioe.Message);
//			}
//			catch (Exception ex)
//			{
//				var hw = new HTMLWorker(document);
//				hw.Parse(new StringReader(ex.Message + " " + ex.StackTrace));
//			}
//			document.Close();

//			stream.Flush(); //Always catches me out
//			stream.Position = 0; //Not sure if this is required
//			return stream.ToArray();
//		}

//	}
//}
