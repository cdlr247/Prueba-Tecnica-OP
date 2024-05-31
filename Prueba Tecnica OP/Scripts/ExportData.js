
function exportToExcel() {
    var table = document.getElementById('tblRegistros');

    if (!table) {
        console.error('Element with ID tblRegistros not found.');
        return;
    } 

    //obtener todas las filas de la tabla
    var rows = table.getElementsByTagName('tr');

    //verificar si hay datos que exportar en la tabla
    if (rows.length < 2) {
        console.warn('No hay registros que exportar.');
        return;
    }

    var tableHTML = table.outerHTML;

    var htmlTemplate = `
        <html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">
        <head>
            <meta charset="UTF-8">
            <style>
                .text-primary { color: #007bff; }
                .table { border-collapse: collapse; width: 100%; }
                .table, .table td, .table th { border: 1px solid black; }
                .table th, .table td { padding: 8px; text-align: left; }
                .table th { background-color: #f2f2f2; }
            </style>
            <!--[if gte mso 9]>
            <xml>
                <x:ExcelWorkbook>
                    <x:ExcelWorksheets>
                        <x:ExcelWorksheet>
                            <x:Name>Sheet1</x:Name>
                            <x:WorksheetOptions>
                                <x:DisplayGridlines/>
                            </x:WorksheetOptions>
                        </x:ExcelWorksheet>
                    </x:ExcelWorksheets>
                </x:ExcelWorkbook>
            </xml>
            <![endif]-->
        </head>
        <body>
            ${tableHTML}
        </body>
        </html>`;

    var dataType = 'application/vnd.ms-excel;charset=utf-8';
    var filename = '1716417755841.xls';

    //convertir el HTML a una URI de datos
    var blob = new Blob([htmlTemplate], { type: dataType });
    var downloadLink = document.createElement("a");

    if (navigator.msSaveOrOpenBlob) {
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        var url = URL.createObjectURL(blob);
        downloadLink.href = url;
        downloadLink.download = filename;

        document.body.appendChild(downloadLink);
        downloadLink.click();
        document.body.removeChild(downloadLink);

        //liberar el objeto URL
        URL.revokeObjectURL(url);
    }
}

