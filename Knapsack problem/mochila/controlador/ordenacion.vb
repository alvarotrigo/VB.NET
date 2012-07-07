'******************************************************
'Algoritmia - Practica 2- Algoritmos voraces
'Álvaro Trigo López
'******************************************************

Namespace controlador
    Public Class ordenacion

        'Declaracion de variables 
        Private visitados As List(Of Integer) = New List(Of Integer) 'array de elementos visitados

        'Constructor por defecto
        Public Sub New()

        End Sub

        'Función que se encarga de seleccionar los objetos que entrarán en la mochila según 
        'el algoritmo de la mochila.
        Public Function mochila(ByVal datos As mochila) As List(Of Decimal)

            Dim solucion As New List(Of Decimal)
            Dim p As Integer = 0
            Dim pesos As List(Of Integer) = datos.getPesos
            Dim valores As List(Of Integer) = datos.getValores
            Dim capacidad As Integer = datos.capacidad
            Dim i As Integer

            'Inicializacion del vector solucion a 0 
            For i = 0 To pesos.Count - 1
                solucion.Add(0)
            Next

            'Si aún caben cosas en la mochila...
            While p < capacidad

                'Seleccion del mas prometedor según el enfoque escogido 
                Select Case (datos.enfoque)
                    Case "Más valioso"
                        i = masValioso(valores)
                    Case "Menos peso"
                        i = menosPeso(pesos)
                    Case "Más beneficioso"
                        i = masBeneficioso(valores, pesos)
                End Select


                'Si el objeto cabe tal cual en la mochila....
                If (p + pesos.Item(i) <= capacidad) Then

                    'meto el objeto entero
                    solucion.Item(i) = 1
                    p = p + pesos.Item(i)


                Else 'si hay que cojer una parte del objeto...
                    solucion.Item(i) = (capacidad - p) / pesos.Item(i)
                    p = capacidad
                End If
            End While

            Return solucion
        End Function


        'Selecciona el objeto más prometedor según el criterio "Primero el más valiso"
        Public Function masValioso(ByVal valores As List(Of Integer))
            Dim max As Integer = 0
            Dim index As Integer = 0

            'Recorre los valores
            For i = 0 To valores.Count - 1

                'Si existe un valor mayor que el anterior maximo
                If valores.Item(i) > max Then

                    'No lo he visitado antes?
                    If (visitados.Contains(i) = False) Then

                        'El valor maximo es ahora este valor
                        max = valores.Item(i)
                        index = i

                        'Lo añadimos a la lista de visitados
                        visitados.Add(index)
                    End If
                End If
            Next

            Return index
        End Function


        'Selecciona el objeto más prometdor según el criterio "Primero el que menos pese"
        Public Function menosPeso(ByVal pesos As List(Of Integer))

            'Defino el mínimo al primer peso
            Dim min As Integer = pesos.Item(0)

            'Defino el indice a 0
            Dim index As Integer = 0

            'Recorre los pesos
            For i = 0 To pesos.Count - 1

                'Si existe un peso menor que el anterior minimo
                If pesos.Item(i) < min Then

                    'No lo he visitado antes?
                    If (visitados.Contains(i) = False) Then

                        'El valor mínimo es ahora est valor
                        min = pesos.Item(i)
                        index = i

                        'Lo añadimos a la lista de visitados
                        visitados.Add(index)
                    End If
                End If
            Next

            Return index
        End Function


        'Selecciona el objeto más prometedor según el criterio "Primero el más beneficioso por unidad de peso"
        Public Function masBeneficioso(ByVal valores As List(Of Integer), ByVal pesos As List(Of Integer))

            'Definio el valor mínimo a la división de los primeros valores y pesos
            Dim min As Integer = valores.Item(0) / pesos.Item(0)

            'Defino el indice a 0
            Dim index As Integer = 0

            'Recorro valores y pesos
            For i = 0 To pesos.Count - 1

                'Existe un objeto más beneficioso que el anterior?
                If (valores.Item(i) / pesos.Item(i)) < min Then

                    'No lo he vistado antes?
                    If (visitados.Contains(i) = False) Then

                        'El valor mínimo ahora este valor
                        min = pesos.Item(i)
                        index = i

                        'Lo añado a la lista de visitados
                        visitados.Add(index)
                    End If
                End If
            Next

            Return index
        End Function

    End Class
End Namespace