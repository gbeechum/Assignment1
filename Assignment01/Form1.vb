Public Class frmMain
    Public Structure InventoryItem
        Public strID As String
        Public strDescription As String
        Public strQuantity As String
        Public strPrice As String
        Public strFlat As String
        Public Sub New(strIdIn As String,
                       strDescriptionIn As String,
                       strQuantityIn As String,
                       strPriceIn As String,
                       strFlatIn As String)
            strID = strIdIn
            strDescription = strDescriptionIn
            strQuantity = strQuantityIn
            strPrice = strPriceIn
            strFlat = strFlatIn
        End Sub
    End Structure

    Public Items As List(Of InventoryItem) = ReadsFile()
    Dim intCurrentItem As Integer = Items.Count - 1
    Private Sub Main(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Items.Count = 0) Then
            AddNewScreen()
        Else
            ViewInventory()
        End If
    End Sub

    Sub WritesFile()
        Dim StreamWriter As System.IO.StreamWriter = System.IO.File.CreateText("input.txt")
        For Each item In Items
            Dim strStringToSave As String
            strStringToSave = item.strID & ";"
            strStringToSave &= item.strDescription & ";"
            strStringToSave &= item.strQuantity & ";"
            strStringToSave &= item.strPrice & ";"
            strStringToSave &= item.strFlat
            StreamWriter.WriteLine(strStringToSave)
        Next
        StreamWriter.Close()
    End Sub

    Function ReadsFile() As List(Of InventoryItem)
        Dim ReadList = New List(Of InventoryItem)
        Try

            Dim StreamReader As System.IO.StreamReader = System.IO.File.OpenText("input.txt")

            Do Until (StreamReader.EndOfStream())
                Dim strTemp As String = StreamReader.ReadLine()
                Dim arrSplitTemp() As String = strTemp.Split(";")
                ReadList.Add(New InventoryItem(arrSplitTemp(0),
                                            arrSplitTemp(1),
                                            arrSplitTemp(2),
                                            arrSplitTemp(3),
                                            arrSplitTemp(4)))
            Loop
            StreamReader.Close()
            Return ReadList
        Catch ex As Exception
            Console.Write(ex)
            Return ReadList
        End Try
    End Function

    Function ValidateNum() As Boolean
        Dim blID As Boolean
        Dim blDescription As Boolean
        Dim blQuantity As Boolean
        Dim blUnitPrice As Boolean
        Dim strStringToShow As String
        If (Not IsNumeric(txtId.Text)) Then
            blID = False
            strStringToShow &= "ID must be a number" & vbCrLf
        Else
            blID = True
        End If
        If (txtDescription.Text = "") Then
            blDescription = False
            strStringToShow &= "Description must be something" & vbCrLf
        Else
            blDescription = True
        End If
        If (Not IsNumeric(txtQuantity.Text)) Then
            blQuantity = False
            strStringToShow &= "Quantity must be a number" & vbCrLf
        Else
            blQuantity = True
        End If
        If (Not IsNumeric(txtUnitPrice.Text)) Then
            blUnitPrice = False
            strStringToShow &= "Unit Price must be a number"
        Else
            blUnitPrice = True
        End If
        If Not (blID And blQuantity And blUnitPrice And blDescription) Then
            MessageBox.Show(strStringToShow)
        End If

        Return (blID And blQuantity And blUnitPrice And blDescription)
    End Function

    Private Sub CalculateTotal(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim strTotal As String = "Total Inventory Value on this item : "
        If (IsNumeric(txtQuantity.Text) And IsNumeric(txtUnitPrice.Text)) Then
            If (cbFlatPrice.Checked) Then
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text))
                lblTotal.Show()

            Else
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text) * Val(txtQuantity.Text))
                lblTotal.Show()
            End If
        End If
    End Sub

    Private Sub AddNewScreen()
        txtId.Enabled = True
        txtId.Text = ""
        txtDescription.Enabled = True
        txtDescription.Text = ""
        txtQuantity.Enabled = True
        txtQuantity.Text = ""
        txtUnitPrice.Enabled = True
        txtUnitPrice.Text = ""
        cbFlatPrice.Enabled = True
        cbFlatPrice.Checked = False

        btnAddNew.Hide()
        btnLeft.Hide()
        btnRight.Hide()

        btnSave.Show()
        btnCancel.Show()

        lblTotal.Text = Nothing

        Me.Text = "Inventory System - Add New"
    End Sub

    Private Sub ViewInventory()
        txtId.Enabled = False
        txtId.Text = Items(intCurrentItem).strID
        txtDescription.Enabled = False
        txtDescription.Text = Items(intCurrentItem).strDescription
        txtQuantity.Enabled = False
        txtQuantity.Text = Items(intCurrentItem).strQuantity
        txtUnitPrice.Enabled = False
        txtUnitPrice.Text = Items(intCurrentItem).strPrice
        cbFlatPrice.Enabled = False
        cbFlatPrice.Checked = Convert.ToBoolean(Items(intCurrentItem).strFlat)

        btnAddNew.Show()
        btnLeft.Show()
        btnRight.Show()

        lblTotal.Text = Nothing

        btnSave.Hide()
        btnCancel.Hide()

        Me.Text = "Inventory System - Item " & Convert.ToString(intCurrentItem + 1) & "/" & Convert.ToString(Items.Count)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddNewScreen()
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        If (intCurrentItem > 0) Then
            intCurrentItem -= 1
            ViewInventory()
        Else
            MessageBox.Show("No More Items")
        End If
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        If (intCurrentItem < Items.Count - 1) Then
            intCurrentItem += 1
            ViewInventory()
        Else
            MessageBox.Show("No More Items")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If (Items.Count > 0) Then
            If MessageBox.Show("Do you wish to cancel entry?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                ViewInventory()
            End If
        Else
            MessageBox.Show("At least one entry must be entered")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateNum() Then
            Items.Add(New InventoryItem(txtId.Text,
                                        txtDescription.Text,
                                        txtQuantity.Text,
                                        txtUnitPrice.Text,
                                        Convert.ToString(cbFlatPrice.Checked)))
            intCurrentItem = Items.Count - 1
            ViewInventory()
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        WritesFile()
    End Sub
End Class