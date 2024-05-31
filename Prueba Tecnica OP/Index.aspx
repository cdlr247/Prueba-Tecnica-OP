<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="server">
    <div class="container-fluid">
        <div class="row">
                <h2 class="display-6" style="font-weight: 400;">Monitor Buckland</h2>
        </div>
        
        <div class="row filtros">
            <!--filtros-->
            <div class="col-2 d-flex flex-column">
                <label for="fechaInicio">Fecha Inicio:</label>
                <input class="form-control" type="date" id="fechaInicio" name="fechaInicio" runat="server">
            </div>

            <div class="col-2 d-flex flex-column">
                <label for="fechaFin">Fecha Fin:</label>
                <input class="form-control" type="date" id="fechaFin" name="fechaFin" runat="server">
            </div>
            
            <div class="col-2 form-check form-switch">
                <input class="form-check-input" type="checkbox" id="autoUpdate">
                <label class="form-check-label" for="autoUpdate">Auto Update</label>
            </div>
            <!--botones busqueda/descarga-->
            <div class="col-6 d-flex justify-content-end">
                <button type="button" class="btn btn-outline-primary me-1 align-self-start" id="btnBuscar" runat="server" onserverclick="Buscar">Buscar</button>
                <button type="button" class="btn btn-outline-primary align-self-start" runat="server" onclick="exportToExcel()">Descargar</button>
            </div>
        </div>

        <div class="row mt-5">
            <!--tabla con resultados/mensaje-->
            <div class="table-responsive">
                <table class="table table-hover table-bordered" id="tblRegistros" runat="server" ClientIDMode="static">
                    <tbody>
                        <tr>
                            <td class="text-primary" style="text-align:center;">Aplique los filtros requeridos y haga click en buscar</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row">
            <!--label con numero de registros en tabla-->
            <div class="col-md-12">
                <label class="text-secondary" id="lblCantidadRegistros" runat="server">Registros: 0</label>
            </div>
        </div>
    </div>
</asp:Content>

