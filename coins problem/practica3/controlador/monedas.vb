Namespace controlador

    Public Class monedas
        Private _devolver As Integer
        Private _tecnica As String
        Private valores As List(Of Integer)

        Public Sub New(ByVal devolver As Integer, ByVal tecnica As String)
            _devolver = devolver
            _tecnica = tecnica

            valores = New List(Of Integer)
        End Sub

        'Propiedad devolver
        Public Property devolver() As Integer
            Get
                Return _devolver
            End Get
            Set(ByVal value As Integer)
                _devolver = value
            End Set
        End Property


        'Propiedad tecnica
        Public Property tecnica() As String
            Get
                Return _tecnica
            End Get
            Set(ByVal value As String)
                _tecnica = value
            End Set
        End Property


        'Devuelve la lista de valores
        Public Function getValores() As List(Of Integer)
            Return valores
        End Function


        'Define los elementos de valores  con los que interactua  
        ' a través del parametro de entrada del datagridview
        Public Sub setElementos(ByVal datos As DataGridView)

            'Limpio los valores previos
            valores.Clear()

            'Recorro las filas del datagridview
            For i = 0 To datos.Rows.Count - 1
                'añado los valores y pesos en las listas
                valores.Add(datos.Rows(i).Cells(0).Value)
            Next
        End Sub

    End Class
End Namespace
