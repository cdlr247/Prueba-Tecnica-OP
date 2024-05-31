using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Registro
{
    [JsonProperty("cliente")]
    public string Cliente { get; set; }

    [JsonProperty("clave pedimento")]
    public string ClavePedimento { get; set; }

    [JsonProperty("tipo operacion")]
    public string TipoOperacion { get; set; }

    [JsonProperty("referencia")]
    public string Referencia { get; set; }

    [JsonProperty("pedimento")]
    public string Pedimento { get; set; }

    [JsonProperty("remesa")]
    public string Remesa { get; set; }

    [JsonProperty("caja")]
    public string Caja { get; set; }

    [JsonProperty("sello")]
    public string Sello { get; set; }

    [JsonProperty("DODA")]
    public string DODA { get; set; }

    [JsonProperty("CP folios")]
    public string CPFolios { get; set; }

    [JsonProperty("cruce/SOIA")]
    public string CruceSOIA { get; set; }

    [JsonProperty("usuario")]
    public string Usuario { get; set; }

    [JsonProperty("TIEMPO RECIBO BGTS")]
    public DateTime? TiempoReciboBGTS { get; set; }

    [JsonProperty("TIEMPO ACG CONFIRMADO")]
    public DateTime? TiempoACGConfirmado { get; set; }

    [JsonProperty("FECHA CCP")]
    public DateTime? FechaCCP { get; set; }

    [JsonProperty("Fecha de remesa")]
    public DateTime? FechaRemesa { get; set; }
}