Imports practica3.controlador

Public Class inicio


    Private Sub añadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles añadir.Click
        Dim fila As String()
        fila = New String() {TextBox2.Text}

        'Añado un nueva fila en el datagridview con las caracteristicas del nuevo objeto.
        DataGridView1.Rows.Add(fila)

        'Los campos peso y valor se quedan vacios de nuevo
        TextBox2.Text = ""
    End Sub

    Private Sub calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcular.Click
        Dim startTime As DateTime
        Dim endTime As TimeSpan

        'Se crea la mochila con las caracterisiticas definidas en el formulario
        Dim monedas As New monedas(Val(TextBox1.Text), tecnica.Text)

        'Se definene los valores y datos obtenidos del datagridview
        monedas.setElementos(DataGridView1)

        Dim tecnicas As New tecnicas(monedas)
        Dim solucion As New List(Of Integer)
        Dim sol As List(Of Integer)
        Dim numero As Integer = 0

        'Obtenemos la solución
        startTime = DateTime.Now
        sol = tecnicas.getSolucion(monedas)
        endTime = DateTime.Now - startTime

        solucion.AddRange(sol)

        tiempo.Text = endTime.TotalMilliseconds.ToString + "ms"

        For i = 0 To sol.Count - 1
            numero = numero + sol.Item(i)
        Next
        numMonedas.Text = numero
        Label5.Text = "monedas"

        If solucion.Count < DataGridView1.Rows.Count Then
            solucion.Add(0)
        End If

        ''Se muestran los datos en el datagridview
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Cells(1).Value = solucion.Item(i)
        Next
    End Sub

    Private Sub tecnica_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tecnica.SelectedIndexChanged
        calcular.Enabled = True
    End Sub

    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numMonedas.Text = ""
        tiempo.Text = ""
        Label5.Text = ""
    End Sub
End Class
