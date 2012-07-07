Namespace controlador

    Public Class solucion
        Dim coins As List(Of Integer)
        Dim cantidad As List(Of Integer)
        Dim _falta As Integer

        Public Sub New(ByVal falta As Integer)
            coins = New List(Of Integer)
            cantidad = New List(Of Integer)
            _falta = falta
        End Sub

        Public Sub addCoin(ByVal valor As Integer)
            coins.Add(valor)
        End Sub
        Public Sub clear()
            coins.Clear()
            cantidad.Clear()
        End Sub

        Public Sub addCantidad(ByVal valor As Integer)
            cantidad.Add(valor)
        End Sub

        Public Function getCoins()
            Return coins
        End Function


        Public Function getCantidad() As List(Of Integer)
            Return cantidad
        End Function

        Public Function getNumMonedas() As Integer
            Dim numMonedas As Integer = 0

            For i = 0 To cantidad.Count - 1
                numMonedas = numMonedas + cantidad.Item(i)
            Next

            Return numMonedas
        End Function

        Public Function getValorTotal() As Integer
            Dim valor As Integer = 0

            For i = 0 To coins.Count - 1
                valor = valor + coins.Item(i) * cantidad.Item(i)
            Next

            Return valor

        End Function

        Public Function esSolucion() As Boolean
            Return getValorTotal() = _falta
        End Function

    End Class

End Namespace
