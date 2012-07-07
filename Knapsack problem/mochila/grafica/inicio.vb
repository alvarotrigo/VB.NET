'******************************************************
'Algoritmia - Practica 2- Algoritmos voraces
'Álvaro Trigo López
'******************************************************

Imports WindowsApplication1.controlador

Public Class inicio

    'Definición de variables
    Private mydatatable As New DataTable

    'Acciones a llevar a cabo durante la carga del formulario de inicio
    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Creo columnas para la tabla interna...
        Dim column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "valor"
        mydatatable.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "peso"
        mydatatable.Columns.Add(column)
    End Sub


    'Cuando se hace click en el botón añadir se añade un nuevo objeto en el programa con  los valores
    'de peso y valor definidos en los campos del formulario
    Private Sub añadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles añadir.Click
        Dim fila As String()
        fila = New String() {numero.Text, valorPeso.Text}

        'Añado un nueva fila en el datagridview con las caracteristicas del nuevo objeto.
        DataGridView1.Rows.Add(fila)

        'Los campos peso y valor se quedan vacios de nuevo
        numero.Text = ""
        valorPeso.Text = ""
    End Sub


    'Al presionar el botón calcular se realizan los calculos a través del algoritmo de la mochila 
    'y teniendo en cuenta las características de la misma definidas en el formulario.
    Private Sub calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcular.Click

        'Se crea la mochila con las caracterisiticas definidas en el formulario
        Dim mochila As New mochila(Val(capacidad.Text), enfoque.Text)

        'Se definene los valores y datos obtenidos del datagridview
        mochila.setElementos(DataGridView1)

        Dim ordena As New ordenacion()
        Dim solucion As New List(Of Decimal)

        'Obtenemos la solución
        solucion.AddRange(ordena.mochila(mochila))

        'Se muestran los datos en el datagridview
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Cells(2).Value = solucion.Item(i)
        Next
    End Sub


End Class
