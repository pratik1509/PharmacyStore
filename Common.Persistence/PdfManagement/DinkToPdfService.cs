using DinkToPdf;

namespace Nhs.Services.PdfManagement
{
    public class DinkToPdfService : IPdfService
	{
		public byte[] ConvertHtmlCodeToPdf(string html, string footerHml)
		{
			var converter = new BasicConverter(new PdfTools());

			var doc = new HtmlToPdfDocument()
			{
				GlobalSettings = {
		ColorMode = ColorMode.Color,
		Orientation = Orientation.Portrait,
		PaperSize = PaperKind.A4Plus,
	},
				Objects = {
		new ObjectSettings() {
			PagesCount = true,
			HtmlContent = html,
			WebSettings = { DefaultEncoding = "utf-8" },
			FooterSettings= { Center = footerHml, Line = true, Spacing = 2.812 },
		}
	}
			};
			byte[] pdf = converter.Convert(doc);

			return pdf;
		}
	}
}
