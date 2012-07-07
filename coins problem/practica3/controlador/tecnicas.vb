Namespace controlador

    Public Class tecnicas

        Private _devolver As Integer
        Private _tecnica As String
        Private valores As List(Of Integer)
        Private opciones As New List(Of solucion)

        'Constructor por defecto
        Public Sub New(ByVal datos As monedas)
            _devolver = datos.devolver
            _tecnica = datos.tecnica
            valores = datos.getValores
        End Sub

        Public Function getSolucion(ByVal datos As monedas) As List(Of Integer)
            Dim matriz As List(Of Integer)
            Dim sol As solucion
            Dim copiaValores As New List(Of Integer)

            For i = 0 To valores.Count - 1
                copiaValores.Add(valores.Item(i))
            Next

            'Seleccion del mas prometedor según el enfoque escogido 
            Select Case (datos.tecnica)
                Case "Programación dinámica"
                    'matriz = programacionDinamica()
                    sol = pepeMod()
                    matriz = New List(Of Integer)
                    For i = 0 To datos.getValores.Count - 1
                        matriz.Add(0)
                    Next

                    If Not sol.esSolucion Then
                        For i = 0 To opciones.Count - 1
                            opciones.Item(i).clear()
                        Next
                    End If

                    'MessageBox.Show("tmp valores:" + datos.getValores.Count().ToString + "sol.getCoins.count():" + sol.getCoins.count().ToString)
                    For i = 0 To valores.Count() - 1
                        For j = 0 To sol.getCoins.count() - 1
                            ' MessageBox.Show("compara: " + sol.getCoins.item(j).ToString + " = " + valores.Item(i).ToString)
                            If sol.getCoins.item(j) = valores.Item(i) Then
                                ' MessageBox.Show("ale")
                                matriz.Item(i) = sol.getCantidad.Item(j)
                            End If
                        Next
                    Next
                    'sparta()
                    'matriz = dinamico()
                    'matriz = pepe2()
                    'MessageBox.Show("pepe: " + pepe.ToString)
                Case "Vuelta atrás"
                    'epa()
                    sol = vueltaAtras2(copiaValores, devolver)

                    If Not sol.esSolucion Then
                        For i = 0 To opciones.Count - 1
                            opciones.Item(i).clear()
                        Next
                    End If

                    matriz = New List(Of Integer)
                    For i = 0 To datos.getValores.Count - 1
                        matriz.Add(0)
                    Next

                    'MessageBox.Show("tmp valores:" + datos.getValores.Count().ToString + "sol.getCoins.count():" + sol.getCoins.count().ToString)
                    For i = 0 To valores.Count() - 1
                        For j = 0 To sol.getCoins.count() - 1
                            ' MessageBox.Show("compara: " + sol.getCoins.item(j).ToString + " = " + valores.Item(i).ToString)
                            If sol.getCoins.item(j) = valores.Item(i) Then
                                ' MessageBox.Show("ale")
                                matriz.Item(i) = sol.getCantidad.Item(j)
                            End If
                        Next
                    Next
            End Select

            Return matriz
        End Function


        'Public Function getSolucion()
        '    Return matriz
        'End Function

        'Propiedad devolver
        Public Property devolver() As Integer
            Get
                Return _devolver
            End Get
            Set(ByVal value As Integer)
                _devolver = value
            End Set
        End Property

        Public Function dinamica()
            Dim d As List(Of Integer) = valores
            Dim k As Integer = d.Count
            Dim n As Integer = devolver
            Dim C As New List(Of Integer)
            Dim S As New List(Of Integer)
            Dim min As Integer
            Dim coin As Integer
            Dim matriz(0 To k, 0 To k) As Integer

            For i = 0 To n - 1
                C.Add(0)
                S.Add(0)
            Next

            For p = 0 To n - 1
                min = 99999
                For i = 0 To k - 1
                    If d.Item(i) <= p Then
                        If 1 + C.Item(p - d.Item(i)) < min Then
                            min = 1 + C.Item(p - d.Item(i))
                            coin = i
                        End If
                    End If
                Next
                MessageBox.Show("min:" + min.ToString + " coin:" + coin.ToString)
                C.Item(p) = min
                S.Item(p) = coin
            Next

            For i = 0 To C.Count - 1
                MessageBox.Show("esto: " + C.Item(i).ToString)
            Next

            Return S
        End Function

        Public Function dinamico()
            Dim coins As List(Of Integer) = valores
            Dim differentCoins As Integer = coins.Count
            Dim maxChange As Integer = devolver
            Dim coinsUsed As New List(Of Integer)
            Dim lastCoin As New List(Of Integer)
            Dim minCoins As Integer
            Dim newCoin As Integer

            For i = 0 To maxChange
                coinsUsed.Add(0)
                lastCoin.Add(0)
            Next

            coinsUsed.Item(0) = 0
            lastCoin.Item(0) = 1

            For cents = 1 To maxChange - 1
                minCoins = cents
                newCoin = 1
                For j = 0 To differentCoins - 1
                    If coins.Item(j) < cents Then
                        If coinsUsed.Item(cents - coins.Item(j)) + 1 Then
                            newCoin = coins.Item(j)
                        End If
                    End If
                Next
                coinsUsed.Item(cents) = minCoins
                lastCoin.Item(cents) = newCoin
            Next

            For i = 0 To coinsUsed.Count - 1
                MessageBox.Show(lastCoin.Item(i).ToString)
            Next

            Return coinsUsed
        End Function

        Public Function programacionDinamica()
            Dim d As List(Of Integer) = valores
            Dim n = d.Count
            Dim matriz(0 To n, 0 To devolver) As Integer

            For i = 0 To n - 1
                matriz(i, 0) = 0
            Next

            For i = 0 To n - 1
                For j = 0 To devolver - 1

                    If i = 0 And j < d.Item(i) Then
                        matriz(i, j) = 100000
                        ' MessageBox.Show("--1")
                    Else

                        If i = 0 Then
                            matriz(i, j) = 1 + matriz(1, j - d.Item(0))
                            '    MessageBox.Show("--2")
                        Else
                            If j < d.Item(i) Then
                                matriz(i, j) = matriz(i - 1, j)
                                '       MessageBox.Show("--3")
                            Else
                                matriz(i, j) = minimo(matriz(i - 1, j), 1 + matriz(i, j - d.Item(i)))
                                '      MessageBox.Show("--4")
                            End If
                        End If
                    End If
                Next
            Next

            MessageBox.Show("resultado:" + matriz(n, devolver).ToString)

            For i = n To 0 Step -1
                For j = devolver To 0 Step -1
                    MessageBox.Show(matriz(i, j))
                Next
            Next
            MessageBox.Show("salgo")
            Return matriz
        End Function

        Function minimo(ByVal num1 As Integer, ByVal num2 As Integer)
            If num1 < num2 Then
                Return num1
            Else
                Return num2
            End If
        End Function


        Public Function pepe()
            Dim d As List(Of Integer) = valores

            For i = 0 To d.Count - 1
                MessageBox.Show("valores " + d.Item(i).ToString)
            Next

            Dim n = d.Count
            Dim matriz(0 To n + 1, 0 To devolver + 1) As Integer
            Dim min As Integer = 0

            For i = 0 To n - 1
                matriz(i, 0) = 0
            Next

            For i = 1 To devolver - 1
                matriz(0, i) = 999999
            Next

            For i = 1 To n
                For j = 1 To devolver
                    If d.Item(i - 1) > j Then
                        matriz(i, j) = matriz(i - 1, j)
                    Else
                        min = 0
                        If matriz(i - 1, j) < matriz(i, j - d.Item(i - 1)) + 1 Then
                            min = matriz(i - 1, j)
                        Else
                            min = matriz(i, j - d.Item(i - 1)) + 1
                        End If
                        matriz(i, j) = min
                    End If
                Next
            Next

            For i = 0 To valores.Count - 1
                For j = 0 To devolver - 1
                    MessageBox.Show("------" + matriz(i, j).ToString)
                Next
            Next

            Return matriz(n, devolver)

        End Function


        Public Function pepe2()
            Dim coins As List(Of Integer) = valores
            Dim numMonedas = coins.Count
            Dim matriz As New List(Of Integer)
            Dim change As Integer
            Dim value As Integer = devolver
            Dim str As String = String.Empty
            Dim count As Integer = 0
            Dim entro As Integer = 0
            'Dim maxCoin As Integer = 0
            'coins.Sort()
            'Dim c As Integer

            While value > 0

                Dim maxCoin As Integer = 0

                For Each c As Integer In coins
                    If c > maxCoin Then
                        maxCoin = c
                    End If
                Next

                coins.Remove(maxCoin)

                change = Math.Floor(value / maxCoin)
                value -= change * maxCoin

                matriz.Add(change)

                'str &= change & " Coin(s) of value " & maxCoin & " (Remaining = " & value & ")" & vbCrLf
                count += change

            End While



            MessageBox.Show("Total number of coins = " + count.ToString)
            'For i = 0 To numMonedas - 1
            '    MessageBox.Show("result" + matriz.Item(i).ToString)
            'Next

            Return matriz

        End Function

        Public Function pepeMod()
            Dim coins As New List(Of Integer)
            Dim numMonedas = valores.Count
            Dim matriz As New List(Of Integer)
            Dim change As Integer
            Dim value As Integer = devolver
            Dim str As String = String.Empty
            Dim count As Integer = 0
            Dim entro As Integer = 0

            Dim posibles As solucion
            'Dim maxCoin As Integer = 0

            'Dim c As Integer

           

            For i = 0 To numMonedas - 1

                For j = 0 To valores.Count - i - 1
                    coins.Add(valores.Item(j))
                Next

                coins.Sort()


                posibles = New solucion(devolver)
                While value > 0 And coins.Count > 0


                    Dim maxCoin As Integer = 0

                    For Each c As Integer In coins
                        If c > maxCoin Then
                            maxCoin = c
                        End If
                    Next

                    coins.Remove(maxCoin)

                    change = Math.Floor(value / maxCoin)
                    value -= change * maxCoin

                    matriz.Add(change)
                    'MessageBox.Show("meeto moneda: " + maxCoin.ToString + " cantidad:" + change.ToString)
                    posibles.addCoin(maxCoin)
                    posibles.addCantidad(change)

                    'str &= change & " Coin(s) of value " & maxCoin & " (Remaining = " & value & ")" & vbCrLf
                    count += change

                End While
                opciones.Add(posibles)
                value = devolver
            Next

           
            'MessageBox.Show("Total number of coins = " + getMinimo().ToString)
            'For i = 0 To numMonedas - 1
            '    MessageBox.Show("result" + matriz.Item(i).ToString)
            'Next



            Return getMinimo()

        End Function

        Public Function vueltaAtras2(ByVal solucion As List(Of Integer), ByVal falta As Integer)
            Dim candidato As Integer
            Dim monedas As List(Of Integer) = solucion
            Dim numMonedas = monedas.Count
            Dim vez As Integer = 0
            Dim cuantas As Decimal
            Dim posibles As solucion
            Dim numEliminados As Integer = 0
            Dim faltaTmp As Integer = falta

            posibles = New solucion(falta)
            While vez < numMonedas

                opciones.Add(posibles)

                candidato = siguienteCandidato(monedas, faltaTmp, vez)
                'MessageBox.Show("candidato" + candidato.ToString + "---faltan:" + faltaTmp.ToString + "--vez:" + vez.ToString)
                If candidato <= faltaTmp Then
                    ' MessageBox.Show(faltaTmp.ToString + "/" + candidato.ToString)

                    cuantas = Math.Floor(faltaTmp / candidato)
                    faltaTmp = faltaTmp - (cuantas * candidato)
                    posibles.addCoin(candidato)
                    posibles.addCantidad(cuantas)
                    'MessageBox.Show("meto la moneda " + candidato.ToString + "---cantidad: " + cuantas.ToString)
                    'MessageBox.Show("resultado=" + posibles.getNumMonedas().ToString)
                End If
                vez += 1
            End While
            ' MessageBox.Show("borro la moneda")

            monedas.Remove(siguienteCandidato(monedas, faltaTmp, 0))

            If monedas.Count > 0 Then
                vueltaAtras2(monedas, falta)
            End If


            Return getMinimo()
        End Function

        Function getMinimo() As solucion
            Dim minimo As Integer = 10000
            Dim x As Integer
            ' MessageBox.Show("numero de veces:" + opciones.Count.ToString)
            For i = 0 To opciones.Count - 1
                ' MessageBox.Show("-------------------------es solucion:" + opciones.Item(i).getNumMonedas.ToString)
                If opciones.Item(i).esSolucion Then

                    If opciones.Item(i).getNumMonedas() < minimo Then

                        'MessageBox.Show("i: " + i.ToString + " numMonedas =========" + opciones.Item(i).getNumMonedas().ToString)
                        minimo = opciones.Item(i).getNumMonedas()
                        x = i
                    End If
                End If
            Next

            Return opciones.Item(x)
        End Function

        Public Function vueltaAtras(ByVal solucion As List(Of Integer), ByVal falta As Integer)
            Dim candidato As Integer
            Dim monedas As List(Of Integer) = valores
            Dim numMonedas = monedas.Count
            Dim numMonedasAct = monedas.Count
            Dim vez As Integer = 0
            Dim cuantas As Integer
            Dim posibles As solucion
            Dim opciones As New List(Of solucion)
            Dim numEliminados As Integer = 0

            While numEliminados < numMonedas

                While vez < numMonedasAct
                    posibles = New solucion(falta)
                    opciones.Add(posibles)

                    candidato = siguienteCandidato(monedas, falta, vez)
                    MessageBox.Show("candidato" + candidato.ToString + "---faltan:" + falta.ToString + "--vez:" + vez.ToString)
                    If candidato <= falta Then

                        cuantas = falta / candidato
                        falta = falta - (cuantas * candidato)
                        posibles.addCoin(candidato)
                        posibles.addCantidad(cuantas)
                        MessageBox.Show("meto la moneda " + candidato.ToString + "---cantidad: " + cuantas.ToString)

                    End If
                    vez += 1
                End While
                MessageBox.Show("borro la moneda")
                monedas.Remove(siguienteCandidato(monedas, falta, 0))
                vez = 0
                numMonedasAct -= 1
                numEliminados += 1
            End While

            Dim minimo As Integer

            minimo = opciones.Item(0).getNumMonedas

            For i = 0 To opciones.Count - 1
                If opciones.Item(i).esSolucion Then
                    MessageBox.Show("numMonedas =========" + opciones.Item(i).getNumMonedas().ToString)
                    If opciones.Item(i).getNumMonedas() < minimo Then
                        minimo = opciones.Item(i).getNumMonedas()
                    End If
                End If


            Next

            MessageBox.Show("minimo" + minimo.ToString)

            Return 0
        End Function

        Public Function epa()
            Dim sum As Integer = devolver
            Dim d As List(Of Integer) = valores
            Dim minCoins As New List(Of Integer)
            Dim oneCoin As New List(Of Integer)
            Dim ncoins As Integer
            Dim coins As New List(Of Integer)
            Dim change As Integer
            Dim a As Integer

            minCoins.Add(0)

            For i = 1 To sum
                minCoins.Add(999999)
            Next

            For i = 0 To sum
                oneCoin.Add(0)
            Next

            For i = 1 To sum - 1
                For j = 1 To (d.Count - 1)
                    If d.Item(j) <= i Then
                        a = d.Item(j)
                        a = minCoins.Item(i - d.Item(j))
                        a = minCoins.Item(i)

                        If minCoins.Item(i - d.Item(j)) + 1 < minCoins.Item(i) Then
                            minCoins.Item(i) = minCoins.Item(i - d.Item(j)) + 1
                            oneCoin.Item(i) = d.Item(j)
                        End If
                    End If
                Next
            Next
            ncoins = minCoins(sum - 1)
            change = sum

            MessageBox.Show("bbbbbbbbbb" + minCoins(sum).ToString)

            For i = 1 To ncoins
                coins.Add(0)
            Next

            For i = 1 To ncoins
                coins.Item(i) = oneCoin(change)
                change = change - coins(i)
                MessageBox.Show("result" + coins.Item(i).ToString)
            Next


        End Function

        Function sparta()
            Dim money As Integer = devolver
            Dim coins As List(Of Integer) = valores
            Dim maxCoins As New List(Of Integer)
            Dim lista As New List(Of Integer)
            Dim posibles As solucion
            Dim opciones As New List(Of solucion)
            Dim numero As Integer = 0
            For i = 0 To money
                maxCoins.Add(99999)
            Next

            maxCoins.Item(0) = 0
            posibles = New solucion(devolver)
            For i = 0 To money
                For j = 0 To coins.Count - 1
                    If i >= coins.Item(j) Then
                        If maxCoins(i - coins.Item(j)) + 1 < maxCoins(i) Then
                            'MessageBox.Show("numero:" + i.ToString)
                            maxCoins.Item(i) = maxCoins.Item(i - coins.Item(j)) + 1
                            'MessageBox.Show("al loro:" + coins.Item(j).ToString)
                            numero = coins.Item(j)

                            posibles.addCoin(numero)

                            posibles.addCantidad(maxCoins.Item(i))
                        End If
                    End If

                Next
            Next

            MessageBox.Show("resultado: " + maxCoins.Item(money).ToString)


            For i = 0 To posibles.getCoins.count - 1
                MessageBox.Show("cantidad:" + posibles.getCantidad().Item(i).ToString)
                MessageBox.Show("moneda:" + posibles.getCoins().item(i).ToString)
            Next

        End Function

        Public Function siguienteCandidato(ByVal monedas As List(Of Integer), ByVal falta As Integer, ByVal vez As Integer)
            Dim max As Integer = monedas.Item(0)
            Dim coins As List(Of Integer) = monedas

            'MessageBox.Show("esto es monedas" + monedas.Count.ToString + "--" + coins.Count.ToString)
            coins.Sort()

            For i = coins.Count - 1 To 0 Step -1
                'MessageBox.Show("salgo")
                Return coins.Item(i - vez)
            Next



        End Function

    End Class
End Namespace