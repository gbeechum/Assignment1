'------------------------------------------------------------
'-              File Name: Form1.vb                         -
'-              Part of Project: Assignment 1               -
'------------------------------------------------------------
'-              Written By: Graham Beechum                  -
'-              Written On: 01/27/2018                      -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This File contains the entire application form where the -
'- user will input new inventory items and browse existing  -
'- items.                                                   -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program starts with an empty list of inventory items-
'- where the user must enter at least one valid entry.      -
'- Upon entering a valid entry, the user can calculate the  -
'- value of the inventory item or save it. The user can add -
'- multiple entries and navigate through them. Exiting the  -
'- program saves the entries to be viewed the next time the -
'- user opens the program.                                  -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- intCurrentItem - Keeps track of the item being viewed.   -
'- lstItems - List that holds IventoryItem structures that  -
'-  contain the ID, Description, Quantitiy, Price, and      -
'-  whether the items has a flat price, all as strings.     -
'------------------------------------------------------------
Public Class frmMain

    ' Creates the list of InventoryItems and populates from file.
    Public lstItems As List(Of InventoryItem) = ReadsFile()
    ' Sets the current item to be the last item.
    Dim intCurrentItem As Integer = lstItems.Count - 1

    Public Structure InventoryItem
        Public strID As String
        Public strDescription As String
        Public strQuantity As String
        Public strPrice As String
        Public strFlat As String
        '------------------------------------------------
        '-            Subprogram Name: New              -
        '------------------------------------------------
        '-            Written By: Graham Beechum        -
        '-            Written On: 01/23/2018            -
        '------------------------------------------------
        '- Subprogram Purpose:                          -
        '-                                              -
        '- Constructor for new InventoryItem.           -
        '------------------------------------------------
        '- Parameter Dictionary (in parameter order)    -
        '- strIdIn - String for the ID of the new item  -
        '- strDescriptionIn - Description of new item   -
        '- strQuantityIn - Quantity of the new item     -
        '- strPriceIn - Unit price of new the item      -
        '- strFlatIn - Indicates if the item has a flat -
        '-              price                           -
        '------------------------------------------------
        '- Local Variable Dictionary (alphabetically):  -
        '- (none)                                       -
        '------------------------------------------------
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
    '----------------------------------------------------
    '-              Subprogram Name: Main               -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/23/2018              -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- This subroutine is called on load time, and      -
    '- determines if the list of items has anything in  -
    '- it. If it does have something in it, it shows the-
    '- last item. If it doesn't, then it shows the new  -
    '- item screen.                                     -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub Main(sender As Object, e As EventArgs) Handles MyBase.Load
        If (lstItems.Count = 0) Then
            ' Shows the add new screen if the list is empty.
            AddNewScreen()
        Else
            ' Shows the last inventory item if the list is not empty.
            ViewInventory()
        End If
    End Sub

    '----------------------------------------------------
    '-              Subprogram Name: WritesFile         -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/26/2018              -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- This subroutine is called when the program is    -
    '- closed. It opens (or creates) the file input.txt -
    '- and loops through lstItems, making a string with -
    '- ";" as a splitter, then writes that string as a  -
    '- line to the file.                                -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '-  (none)                                          -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '- StreamWriter - Used to write to file and create  -
    '-                the file if it doesn't exist      -
    '- strStringToSave - stores the string that will be -
    '-                   written to the file            -
    '----------------------------------------------------
    Sub WritesFile()
        ' StreamWriter that writes to file and creates the file if it does not exist.
        Dim StreamWriter As System.IO.StreamWriter = System.IO.File.CreateText("input.txt")
        ' Loops through lstItems and creates string with ";" between each part of the string.
        For Each item In lstItems
            Dim strStringToSave As String
            strStringToSave = item.strID & ";"
            strStringToSave &= item.strDescription & ";"
            strStringToSave &= item.strQuantity & ";"
            strStringToSave &= item.strPrice & ";"
            strStringToSave &= item.strFlat
            ' Writes the string to the file
            StreamWriter.WriteLine(strStringToSave)
        Next
        ' Closes the StreamWriter because it is no longer needed.
        StreamWriter.Close()
    End Sub

    '----------------------------------------------------
    '               Funtion Name: ReadsFile             -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/26/2018              -
    '----------------------------------------------------
    '- Function Purpose:                                -
    '-                                                  -
    '- This function creates a list of InventoryItems   -
    '- and populates it from the input.text file.       -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '-  (none)                                          -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '- arrSplitTemp - Single dimension array that holds -
    '-                the values read from file split by-
    '-                ";"                               -
    '- ReadList - List of InventoryItems that holds the -
    '-            values of what is read from the file  -
    '- StreamReader - Used to read from input.txt       -
    '----------------------------------------------------
    '- Returns:                                         -
    '- List - containing all the records read from file.-
    '-        Returns empty if the file doesn't exist.  -
    '----------------------------------------------------
    Function ReadsFile() As List(Of InventoryItem)
        ' Creates new list of InventoryItems.
        Dim ReadList = New List(Of InventoryItem)
        Try
            ' Opens file input.txt
            Dim StreamReader As System.IO.StreamReader = System.IO.File.OpenText("input.txt")

            ' Loops until the end of file.
            Do Until (StreamReader.EndOfStream())
                ' Splits the line read from file into an array.
                Dim arrSplitTemp() As String = StreamReader.ReadLine().Split(";")
                ' Adds entry into list.
                ReadList.Add(New InventoryItem(arrSplitTemp(0),
                                            arrSplitTemp(1),
                                            arrSplitTemp(2),
                                            arrSplitTemp(3),
                                            arrSplitTemp(4)))
            Loop
            ' Closes StreamReader because it is no longer needed.
            StreamReader.Close()
            ' Returns populated list to be stored in global variable.
            Return ReadList
        Catch ex As Exception
            ' Writes the exception to the console.
            Console.Write(ex)
            ' Returns empty list so we can still add entries later.
            Return ReadList
        End Try
    End Function
    '----------------------------------------------------
    '-              Function Name: ValidateNum          -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/26/2018              -
    '----------------------------------------------------
    '- Function Purpose:                                -
    '-                                                  -
    '- This function checks to see if the text boxes    -
    '- have valid entries and notifies the user which   -
    '- boxes must be changed via message box            -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '-  (none)                                          -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '- blDescription - Boolean value to tell if the     -
    '-                 description is empty.            -
    '- blID - Boolean value that tells if the ID is not -
    '-        a number.                                 -
    '- blQuantity - Boolean value that tells if the     -
    '-              quantity is not a number.           -
    '- blUnitPrice - Boolean value that tells if the    -
    '-               unit price is not a number.        -
    '- strStringToShow - String that holds the value to -
    '-                   be shown via message box if    -
    '-                   any entries are incorrect.     -
    '----------------------------------------------------
    '- Returns:                                         -
    '- Boolean - True if all the text boxes are valid,  -
    '-           false otherwise.                       -
    '----------------------------------------------------
    Function ValidateNum() As Boolean
        Dim blID As Boolean
        Dim blDescription As Boolean
        Dim blQuantity As Boolean
        Dim blUnitPrice As Boolean
        Dim strStringToShow As String = ""
        ' Each If-Else statement checks the boxes to see if they are invalid.
        ' If invalid, they set the corresponding boolean to false and adds the
        ' corresponding message to strStringToShow. The corresponding boolean is
        ' set to true if the entry is valid.
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
        ' If any of the values are invalid, it shows a message box indicating which are invalid.
        If Not (blID And blQuantity And blUnitPrice And blDescription) Then
            MessageBox.Show(strStringToShow)
        End If

        ' Returns true if all text boxes are valid.
        Return (blID And blQuantity And blUnitPrice And blDescription)
    End Function

    '----------------------------------------------------
    '-              Subprogram Name: CalculateTotal     -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/25/2018              -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- This subroutine checks if the text in the text   -
    '- boxes for quantity and unit price are both       -
    '- numeric, then checks if the flat rate checkbox is-
    '- checked. Calculations are made and shown         -
    '- accordingly.                                      -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '- strTotal - string that holds a value to be put   -
    '-            into a label.                          -
    '----------------------------------------------------
    Private Sub CalculateTotal(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim strTotal As String = "Total Inventory Value on this item : "
        ' Checks if the text boxes are numeric.
        If (IsNumeric(txtQuantity.Text) And IsNumeric(txtUnitPrice.Text)) Then
            ' If the flat price is checked.
            If (cbFlatPrice.Checked) Then
                ' Add the value of unit price in currency format then show it
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text))
                lblTotal.Show()
            Else
                ' Multiply the unit price by quantity then show it
                lblTotal.Text = strTotal & FormatCurrency(Val(txtUnitPrice.Text) * Val(txtQuantity.Text))
                lblTotal.Show()
            End If
        End If
    End Sub
    '----------------------------------------------------
    '-          Subprogram Name: AddNewScreen           -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- This Subroutine shows the add new item screen by -
    '- hiding and showing certain controls, and allowing-
    '- textboxes and the checkbox to be edited.         -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '-  (none)                                          -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically)       -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub AddNewScreen()
        ' Lets the text boxes and checkbox be edited
        ' and sets them to be empty.
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

        ' Hides the buttons for adding new items
        ' and navigating left and right.
        btnAddNew.Hide()
        btnLeft.Hide()
        btnRight.Hide()

        ' Shows the save and cancel buttons.
        btnSave.Show()
        btnCancel.Show()

        ' Clears the calculated total.
        lblTotal.Text = Nothing

        ' Sets the forms header text.
        Me.Text = "Inventory System - Add New"
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: ViewInventory          -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- This subroutine disables the text boxes and check-
    '- box, sets the values of those to be that of the  -
    '- current item's, and shows and hides certain      -
    '- controls.                                        -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '-  (none)                                          -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically)       -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub ViewInventory()
        ' Disables the controls and fills them with
        ' the current items values.
        txtId.Enabled = False
        txtId.Text = lstItems(intCurrentItem).strID
        txtDescription.Enabled = False
        txtDescription.Text = lstItems(intCurrentItem).strDescription
        txtQuantity.Enabled = False
        txtQuantity.Text = lstItems(intCurrentItem).strQuantity
        txtUnitPrice.Enabled = False
        txtUnitPrice.Text = lstItems(intCurrentItem).strPrice
        cbFlatPrice.Enabled = False
        cbFlatPrice.Checked = Convert.ToBoolean(lstItems(intCurrentItem).strFlat)

        ' Shows the buttons for adding new items
        ' and navigating left and right.
        btnAddNew.Show()
        btnLeft.Show()
        btnRight.Show()

        ' Clears the label that shows the calculated title.
        lblTotal.Text = Nothing

        ' Hides the save and cancel buttons.
        btnSave.Hide()
        btnCancel.Hide()

        ' Sets the forms header text to show the index of the current item out of the total amount of items.
        Me.Text = "Inventory System - Item " & Convert.ToString(intCurrentItem + 1) & "/" & Convert.ToString(lstItems.Count)
    End Sub

    '----------------------------------------------------
    '-              Subprogram Name: AddNew             -
    '----------------------------------------------------
    '-              Written By: Graham Beechum          -
    '-              Written On: 01/26/2018              -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- Handles the clicking of the Add New button and   -
    '- calls the AddNewScreen subroutine.               -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub AddNew(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddNewScreen()
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: PreviousItem           -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- Checks to see if the user is allowed to progress -
    '- further towards the beginning of the list and    -
    '- stops them if they cannot. Shows the previous    -
    '- item if they are allowed.                        -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub PreviousItem(sender As Object, e As EventArgs) Handles btnLeft.Click
        ' If they are not at the first item, let them procede.
        If (intCurrentItem > 0) Then
            intCurrentItem -= 1
            ViewInventory()
        Else
            ' If they are at the first item, don't let them procede
            ' and tell them why they cannot.
            MessageBox.Show("You cannot move past the first record!")
        End If
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: NextItem               -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- Checks to see if the user is allowed to progress -
    '- further towards the end of the list and stops    -
    '- them if they cannot. Shows the next item if they -
    '- are allowed.                                     -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub NextItem(sender As Object, e As EventArgs) Handles btnRight.Click
        ' If they are not at the end of the list, let them continue.
        If (intCurrentItem < lstItems.Count - 1) Then
            intCurrentItem += 1
            ViewInventory()
        Else
            ' If they are at the end of the list, stop them
            ' from continuing and tell them why they are stopped.
            MessageBox.Show("You cannot move past the last record!")
        End If
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: CancelEntry            -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- Checks if there is at least one entry. If there  -
    '- are no entries, tell the user that they cannot   -
    '- cancel this entry. If there is at least one entry-
    '- prompt the user if they are sure they wish to    -
    '- cancel. If they do, show them the last screen.   -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub CancelEntry(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' If there is at least one item in the list.
        If (lstItems.Count > 0) Then
            ' Ask the user if they actually want to cancel and cancel if they do.
            If MessageBox.Show("Do you wish to cancel entry?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                ViewInventory()
            End If
        Else
            MessageBox.Show("At least one entry must be entered")
        End If
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: SaveEntry              -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- If the values are valid, save them as a new entry-
    '- in the list. Send them to the inventory screen   -
    '- showing the new last item.                       -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub SaveEntry(sender As Object, e As EventArgs) Handles btnSave.Click
        ' If the entries are valid, add them to the list.
        If ValidateNum() Then
            lstItems.Add(New InventoryItem(txtId.Text,
                                        txtDescription.Text,
                                        txtQuantity.Text,
                                        txtUnitPrice.Text,
                                        Convert.ToString(cbFlatPrice.Checked)))
            ' Set the current item to be the new last item.
            intCurrentItem = lstItems.Count - 1
            ' Show the inventory of the new last item.
            ViewInventory()
        End If
    End Sub

    '----------------------------------------------------
    '-          Subprogram Name: SaveAndClose           -
    '----------------------------------------------------
    '-          Written By: Graham Beechum              -
    '-          Written On: 01/26/2018                  -
    '----------------------------------------------------
    '- Subprogram Purpose:                              -
    '-                                                  -
    '- calls the subroutine to write the list to file   -
    '- and closes the program.                          -
    '----------------------------------------------------
    '- Parameter Dictionary (in parameter order):       -
    '- sender - Identifies which particular control     -
    '-          raised the load event                   -
    '- e - Holds the EventArgs object sent to the       -
    '-     routine                                      -
    '----------------------------------------------------
    '- Local Variable Dictionary (alphabetically):      -
    '-  (none)                                          -
    '----------------------------------------------------
    Private Sub SaveAndClose(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        WritesFile()
    End Sub
End Class