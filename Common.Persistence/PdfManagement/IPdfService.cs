using System;

namespace Common.Persistence.PdfManagement
{
    public interface IPdfService
	{
		Byte[] ConvertHtmlCodeToPdf(string html, string footerHml);
	}
}
