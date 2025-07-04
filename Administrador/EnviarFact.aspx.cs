using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPetVida.Conexiones;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoPetVida.Administrador
{
    public partial class EnviarFact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carga inicial de datos en el GridView
                CargarDatosIniciales();
            }
        }
        private DataTable dtMascotas
        {
            get
            {
                if (ViewState["Mascotas"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("Dueño");
                    dt.Columns.Add("PrecioConsulta");
                    dt.Columns.Add("MotivoConsulta");
                    ViewState["Mascotas"] = dt;
                }
                return (DataTable)ViewState["Mascotas"];
            }
            set
            {
                ViewState["Mascotas"] = value;
            }
        }
        private void CargarDatosIniciales()
        {
            gvMascotas.DataSource = dtMascotas;
            gvMascotas.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) &&
        !string.IsNullOrEmpty(txtDueño.Text) &&
        !string.IsNullOrEmpty(txtPrecioConsulta.Text) &&
        !string.IsNullOrEmpty(txtMotivoConsulta.Text))
            {
                if (decimal.TryParse(txtPrecioConsulta.Text, out decimal precioConsulta))
                {
                    // Crear nueva fila
                    DataRow row = dtMascotas.NewRow();
                    row["Nombre"] = txtNombre.Text;
                    row["Dueño"] = txtDueño.Text;
                    row["PrecioConsulta"] = precioConsulta.ToString("F2"); // Formatear a dos decimales
                    row["MotivoConsulta"] = txtMotivoConsulta.Text;

                    dtMascotas.Rows.Add(row);

                    // Actualizar GridView
                    gvMascotas.DataSource = dtMascotas;
                    gvMascotas.DataBind();

                    // Calcular el total acumulado
                    decimal totalAcumulado = ViewState["TotalAcumulado"] != null ? (decimal)ViewState["TotalAcumulado"] : 0;
                    totalAcumulado += precioConsulta;
                    ViewState["TotalAcumulado"] = totalAcumulado;

                    // Mostrar el total en la interfaz
                    lblTotalPrecio.Text = $"Total Acumulado: ${totalAcumulado:F2}";

                    // Limpiar campos del formulario
                    txtNombre.Text = "";
                    txtDueño.Text = "";
                    txtPrecioConsulta.Text = "";
                    txtMotivoConsulta.Text = "";
                }
                else
                {
                    lblError.Text = "Por favor, ingrese un precio válido.";
                }
            }
            else
            {
                lblError.Text = "Todos los campos son obligatorios.";
            }
        }
        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            // Crear documento PDF
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                // Encabezado
                PdfPTable headerTable = new PdfPTable(2) { WidthPercentage = 100 };
                headerTable.SetWidths(new float[] { 1f, 3f });

                // Ruta de la imagen local
                string logoPath = Server.MapPath("~/imagenes/logoPetVida.jpg");
                iTextSharp.text.Image logo;
                try
                {
                    logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(60f, 60f);
                }
                catch
                {
                    logo = null;
                }

                PdfPCell logoCell = logo != null
                    ? new PdfPCell(logo) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT }
                    : new PdfPCell(new Phrase("LOGO NO DISPONIBLE", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.RED)))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };

                headerTable.AddCell(logoCell);

                PdfPCell infoCell = new PdfPCell(new Phrase(
                    "PETVIDA VETERINARIA\nDirección: Calle de los Amores 123\nWhatsApp: +503 7597-3202\nTelefono: 2289-4534\nCorreo: contacto@petvida.com",
                    new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                headerTable.AddCell(infoCell);

                pdfDoc.Add(headerTable);

                // Título
                Paragraph titulo = new Paragraph("PetVida", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD, BaseColor.BLUE))
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                pdfDoc.Add(titulo);

                // Tabla de datos
                PdfPTable pdfTable = new PdfPTable(4) { WidthPercentage = 100 };
                pdfTable.SetWidths(new float[] { 3f, 3f, 2f, 2f });

                PdfPCell[] headers = {
            new PdfPCell(new Phrase("Mascota", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE))),
            new PdfPCell(new Phrase("Dueño", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE))),
            new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE))),
            new PdfPCell(new Phrase("Motivo", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.WHITE)))
        };

                foreach (var header in headers)
                {
                    header.BackgroundColor = BaseColor.DARK_GRAY;
                    header.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(header);
                }

                foreach (DataRow row in dtMascotas.Rows)
                {
                    pdfTable.AddCell(new Phrase(row["Nombre"].ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                    pdfTable.AddCell(new Phrase(row["Dueño"].ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                    pdfTable.AddCell(new Phrase(row["PrecioConsulta"].ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                    pdfTable.AddCell(new Phrase(row["MotivoConsulta"].ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                }

                // Agregar fila de total acumulado
                decimal totalAcumulado = ViewState["TotalAcumulado"] != null ? (decimal)ViewState["TotalAcumulado"] : 0;
                PdfPCell totalCell = new PdfPCell(new Phrase($"Total: ${totalAcumulado:F2}", new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD)))
                {
                    Colspan = 4,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    BackgroundColor = BaseColor.LIGHT_GRAY
                };
                pdfTable.AddCell(totalCell);

                pdfDoc.Add(pdfTable);

                // Pie de página
                Paragraph footer = new Paragraph("Gracias por confiar en PETVIDA Veterinaria.\nCuidamos a tus mascotas como si fueran nuestras.",
                    new Font(Font.FontFamily.HELVETICA, 10, Font.ITALIC, BaseColor.GRAY))
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 20f
                };
                pdfDoc.Add(footer);

                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteVeterinaria.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }
    }
}