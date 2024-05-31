using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    JSONConverter cargaJSON = new JSONConverter();
    List<Registro> listaRegistros = new List<Registro>();

    public Index()
    {
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            //asignar fecha actual a los controles
            fechaInicio.Value = DateTime.Now.ToString("yyyy-MM-dd");
            fechaFin.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    //funcion para verificar carga datos del data.json
    /*private void LoadData()
    {
        //cargar datos del json
        string filePath = Server.MapPath("~/App_Data/DATA.json"); // Ruta del archivo JSON
        listaRegistros = JSONConverter.DeserializeJson(filePath);

        if (listaRegistros != null)
        {
            string script = "<script>console.log('Clientes:', " + JsonConvert.SerializeObject(listaRegistros) + ");</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "logClientes", script);
        }
        else
        {
            string script = "<script>console.log('Error al cargar los datos del JSON.');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "logError", script);
        }
    }*/

    //funcion para el boton de busqueda
    protected void Buscar(object sender, EventArgs e)
    {
        DateTime dateInicio;
        DateTime dateFin;

        //cargar datos del json
        string filePath = Server.MapPath("~/App_Data/data.json"); // Ruta del archivo JSON
        listaRegistros = JSONConverter.DeserializeJson(filePath);

        // Convertir las fechas de los controles de entrada
        if (DateTime.TryParse(fechaInicio.Value, out dateInicio) && DateTime.TryParse(fechaFin.Value, out dateFin))
        {
            if (listaRegistros != null && listaRegistros.Count > 0)
            {
                var registrosFiltrados = listaRegistros.FindAll(registro => registro.TiempoReciboBGTS >= dateInicio && registro.TiempoReciboBGTS <= dateFin);
                if (registrosFiltrados != null && registrosFiltrados.Count > 0) {
                    // Actualizar la tabla con los registros filtrados
                    ActualizarTabla(registrosFiltrados);
                } else
                {
                    //no se encontraron resultados
                    MostrarMsjVacio();
                    lblCantidadRegistros.InnerText = "Registros: " + registrosFiltrados.Count;
                }
                
            }
            else {
                //mostrar mensaje por resultados vacios
                MostrarMsjVacio();
            }
        }
    }

    private void ActualizarTabla(List<Registro> registrosFiltrados)
    {
        tblRegistros.Rows.Clear();

        // Añadir encabezado de la tabla
        HtmlTableRow headerRow = new HtmlTableRow();
        HtmlTableCell headerCell0 = new HtmlTableCell("th") { InnerText = "#" };
        HtmlTableCell headerCell1 = new HtmlTableCell("th") { InnerText = "CLIENTE" };
        HtmlTableCell headerCell2 = new HtmlTableCell("th") { InnerText = "CLAVE PEDIMENTO" };
        HtmlTableCell headerCell3 = new HtmlTableCell("th") { InnerText = "TIPO OPERACION" };
        HtmlTableCell headerCell4 = new HtmlTableCell("th") { InnerText = "REFERENCIA" };
        HtmlTableCell headerCell5 = new HtmlTableCell("th") { InnerText = "PEDIMENTO" };
        HtmlTableCell headerCell6 = new HtmlTableCell("th") { InnerText = "REMESA" };
        HtmlTableCell headerCell7 = new HtmlTableCell("th") { InnerText = "CAJA" };
        HtmlTableCell headerCell8 = new HtmlTableCell("th") { InnerText = "SELLO" };
        HtmlTableCell headerCell9 = new HtmlTableCell("th") { InnerText = "DODA" };
        HtmlTableCell headerCell10 = new HtmlTableCell("th") { InnerText = "CP FOLIOS" };
        HtmlTableCell headerCell11 = new HtmlTableCell("th") { InnerText = "CRUCE/SOIA" };
        HtmlTableCell headerCell12 = new HtmlTableCell("th") { InnerText = "USUARIO" };
        HtmlTableCell headerCell13 = new HtmlTableCell("th") { InnerText = "TIEMPO RECIBO BGTS" };
        HtmlTableCell headerCell14 = new HtmlTableCell("th") { InnerText = "TIEMPO ACG CONFIRMADO" };
        HtmlTableCell headerCell15 = new HtmlTableCell("th") { InnerText = "FECHA CCP"};
        HtmlTableCell headerCell16 = new HtmlTableCell("th") { InnerText = "FECHA DE REMESA" };
        headerCell0.Attributes.Add("style", "text-align:center;");
        headerCell1.Attributes.Add("style", "text-align:center;");
        headerCell2.Attributes.Add("style", "text-align:center;");
        headerCell3.Attributes.Add("style", "text-align:center;");
        headerCell4.Attributes.Add("style", "text-align:center;");
        headerCell5.Attributes.Add("style", "text-align:center;");
        headerCell6.Attributes.Add("style", "text-align:center;");
        headerCell7.Attributes.Add("style", "text-align:center;");
        headerCell8.Attributes.Add("style", "text-align:center;");
        headerCell9.Attributes.Add("style", "text-align:center;");
        headerCell10.Attributes.Add("style", "text-align:center;");
        headerCell11.Attributes.Add("style", "text-align:center;");
        headerCell12.Attributes.Add("style", "text-align:center;");
        headerCell13.Attributes.Add("style", "text-align:center;");
        headerCell14.Attributes.Add("style", "text-align:center;");
        headerCell15.Attributes.Add("style", "text-align:center;");
        headerCell16.Attributes.Add("style", "text-align:center;");

        headerRow.Cells.Add(headerCell0);
        headerRow.Cells.Add(headerCell1);
        headerRow.Cells.Add(headerCell2);
        headerRow.Cells.Add(headerCell3);
        headerRow.Cells.Add(headerCell4);
        headerRow.Cells.Add(headerCell5);
        headerRow.Cells.Add(headerCell6);
        headerRow.Cells.Add(headerCell7);
        headerRow.Cells.Add(headerCell8);
        headerRow.Cells.Add(headerCell9);
        headerRow.Cells.Add(headerCell10);
        headerRow.Cells.Add(headerCell11);
        headerRow.Cells.Add(headerCell12);
        headerRow.Cells.Add(headerCell13);
        headerRow.Cells.Add(headerCell14);
        headerRow.Cells.Add(headerCell15);
        headerRow.Cells.Add(headerCell16);

        //agregar el estilo de encabezado de la tabla
        headerRow.Attributes.Add("style", "border-bottom: 2px solid #333;");

        tblRegistros.Rows.Add(headerRow);

        // Añadir las filas de datos
        int contador = 0;
        foreach (var registro in registrosFiltrados)
        {
            contador++;
            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell0 = new HtmlTableCell { InnerText =  contador.ToString() };
            HtmlTableCell cell1 = new HtmlTableCell { InnerText = registro.Cliente };
            HtmlTableCell cell2 = new HtmlTableCell { InnerText = registro.ClavePedimento };
            HtmlTableCell cell3 = new HtmlTableCell { InnerText = registro.TipoOperacion };
            HtmlTableCell cell4 = new HtmlTableCell { InnerText = registro.Referencia };
            HtmlTableCell cell5 = new HtmlTableCell { InnerText = registro.Pedimento };
            HtmlTableCell cell6 = new HtmlTableCell { InnerText = registro.Remesa };
            HtmlTableCell cell7 = new HtmlTableCell { InnerText = registro.Caja };
            HtmlTableCell cell8 = new HtmlTableCell { InnerText = registro.Sello };
            HtmlTableCell cell9 = new HtmlTableCell { InnerText = registro.DODA };
            HtmlTableCell cell10 = new HtmlTableCell { InnerText = registro.CPFolios };
            HtmlTableCell cell11 = new HtmlTableCell { InnerText = registro.CruceSOIA};
            HtmlTableCell cell12 = new HtmlTableCell { InnerText = registro.Usuario };
            HtmlTableCell cell13 = new HtmlTableCell { InnerText = registro.TiempoReciboBGTS.ToString()};
            HtmlTableCell cell14 = new HtmlTableCell { InnerText = registro.TiempoACGConfirmado.ToString() };
            HtmlTableCell cell15 = new HtmlTableCell { InnerText = registro.FechaCCP.ToString() };
            HtmlTableCell cell16 = new HtmlTableCell { InnerText = registro.FechaRemesa.ToString() };
            cell0.Attributes.Add("style", "text-align:center;");
            cell0.Attributes.Add("style", "font-weight: bold;");
            cell1.Attributes.Add("style", "text-align:center;");
            cell2.Attributes.Add("style", "text-align:center;");
            cell3.Attributes.Add("style", "text-align:center;");
            cell4.Attributes.Add("style", "text-align:center;");
            cell5.Attributes.Add("style", "text-align:center;");
            cell6.Attributes.Add("style", "text-align:center;");
            cell7.Attributes.Add("style", "text-align:center;");
            cell8.Attributes.Add("style", "text-align:center;");
            cell9.Attributes.Add("style", "text-align:center;");
            cell10.Attributes.Add("style", "text-align:center;");
            cell11.Attributes.Add("style", "text-align:center;");
            cell12.Attributes.Add("style", "text-align:center;");
            cell13.Attributes.Add("style", "text-align:center;");
            cell14.Attributes.Add("style", "text-align:center;");
            cell15.Attributes.Add("style", "text-align:center;");
            cell16.Attributes.Add("style", "text-align:center;");

            row.Cells.Add(cell0);
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);
            row.Cells.Add(cell5); 
            row.Cells.Add(cell6);
            row.Cells.Add(cell7);
            row.Cells.Add(cell8);
            row.Cells.Add(cell9);
            row.Cells.Add(cell10);
            row.Cells.Add(cell11);
            row.Cells.Add(cell12);
            row.Cells.Add(cell13);
            row.Cells.Add(cell14);
            row.Cells.Add(cell15);
            row.Cells.Add(cell16);

            tblRegistros.Rows.Add(row);
        }

        lblCantidadRegistros.InnerText = "Registros: " + registrosFiltrados.Count;
    }

    //funcion mostrar mensaje si no encuentra resultados de busqueda
    private void MostrarMsjVacio()
    {
        tblRegistros.Rows.Clear();
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell
        {
            InnerText = "No hay datos disponibles",
            ColSpan = 16,
        };
        cell.Attributes.Add("class", "text-danger");
        cell.Attributes.Add("style", "text-align:center;");
        row.Cells.Add(cell);
        tblRegistros.Controls.Add(row);
    }
}