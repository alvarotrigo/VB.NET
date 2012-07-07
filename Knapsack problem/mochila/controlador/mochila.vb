'******************************************************
'Algoritmia - Practica 2- Algoritmos voraces
'Álvaro Trigo López
'******************************************************

Namespace controlador
    Public Class mochila

        'Declaración de variables 
        Private _capacidad As Integer
        Private _numElementos As Integer
        Private _enfoque As String
        Private valores As List(Of Integer)
        Private pesos As List(Of Integer)

        'Constructor por defecto
        'Asigna las caracteristicas de la mochila: capacidad y enfoque
        Public Sub New(ByVal capacidad As Integer, ByVal enfoque As String)
            _capacidad = capacidad
            _enfoque = enfoque

            valores = New List(Of Integer)
            pesos = New List(Of Integer)
        End Sub

        'Propiedad capacidad
        Public Property capacidad() As Integer
            Get
                Return _capacidad
            End Get
            Set(ByVal value As Integer)
                _capacidad = value
            End Set
        End Property

        'Propiedad enfoque
        Public Property enfoque() As String
            Get
                Return _enfoque
            End Get
            Set(ByVal value As String)
                _enfoque = value
            End Set
        End Property

        'Propiedad numElementos
        Public Property numElementos() As Integer
            Get
                Return _numElementos
            End Get
            Set(ByVal value As Integer)
                _numElementos = value
            End Set
        End Property

        'Devuelve la lista de valores
        Public Function getValores() As List(Of Integer)
            Return valores
        End Function

        'Devuelve la lista de pesos
        Public Function getPesos() As List(Of Integer)
            Return pesos
        End Function


        'Define los elementos de valores y pesos con los que interactua la mochila 
        ' a través del parametro de entrada del datagridview
        Public Sub setElementos(ByVal datos As DataGridView)

            'Limpio los valores previos
            valores.Clear()
            pesos.Clear()

            'Recorro las filas del datagridview
            For i = 0 To datos.Rows.Count - 1
                'añado los valores y pesos en las listas
                valores.Add(datos.Rows(i).Cells(0).Value)
                pesos.Add(datos.Rows(i).Cells(1).Value)
            Next
        End Sub
    End Class
End Namespace