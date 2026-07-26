using System;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

public class PdfReader
{
    public static string ReadPdfFromStream(MemoryStream memoryStream)
    {
        memoryStream.Position = 0;

        StringBuilder sb = new();
        using (PdfDocument pdfDocument = PdfDocument.Open(memoryStream))
        {
            foreach (Page page in pdfDocument.GetPages())
            {
                sb.AppendLine($"--- Page: {page.Number} ---");
                sb.AppendLine(page.Text);
            }
        }

        return sb.ToString();
    }
}